using System.Threading.Tasks;
using AutoMapper;
using CCMS.Infrastructure.MessageQueue.Interfaces;
using Dashboard.HDNManagementAPI.Command;
using Dashboard.HDNManagementAPI.DataAccess;
using Dashboard.HDNManagementAPI.Events;
using Dashboard.HDNManagementAPI.Model;
using Dashboard.MemberManagementAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dashboard.HDNManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HDNController : ControllerBase
    {
        private readonly ILogger<HDNController> _logger;
        private readonly HDNManagementDbContext _dbContext;
        private readonly IMessagePublisher _messagePublisher;
        private readonly IHDNRepository _repository;

        public HDNController(ILogger<HDNController> logger, HDNManagementDbContext dbContext, IHDNRepository repository, IMessagePublisher messagePublisher)
        {
            _logger = logger;
            _dbContext = dbContext;
            _repository = repository;
            _messagePublisher = messagePublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _repository.GetAllAsync();

            return Ok( response );
        }

        [HttpGet]
        [Route("{hdnId}", Name = "GetByHdnId")]
        public async Task<IActionResult> GetByHdnId(int hdnId)
        {
            var hdn = await _repository.GetByIdAsync(hdnId);

            if (hdn == null)
            {
                return NotFound();
            }
            return Ok(hdn);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterHDN command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // insert person
                    HDN hdn = Mapper.Map<HDN>(command);
                    _dbContext.Hdns.Add(hdn);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    HDNRegistered e = Mapper.Map<HDNRegistered>(command);
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                    // return result
                    return CreatedAtRoute("GetByHdnId", new { memberId = hdn.HdnId }, hdn);
                }
                return BadRequest();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists " +
                                             "see your system administrator.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
