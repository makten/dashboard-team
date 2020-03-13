using System.Threading.Tasks;
using AutoMapper;
using CCMS.Infrastructure.MessageQueue.Interfaces;
using Dashboard.MemberManagementAPI.Command;
using Dashboard.MemberManagementAPI.DataAccess;
using Dashboard.MemberManagementAPI.Events;
using Dashboard.MemberManagementAPI.Model;
using Dashboard.MemberManagementAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dashboard.MemberManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly MemberManagementDbContext _dbContext;
        private readonly IMessagePublisher _messagePublisher;
        private readonly IMemberRepository _repository;

        public MembersController(ILogger<MembersController> logger, MemberManagementDbContext dbContext, IMemberRepository repository, IMessagePublisher messagePublisher)
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
        [Route("{memberId}", Name = "GetByMemberId")]
        public async Task<IActionResult> GetByMemberId(int customerId)
        {
            var customer = await _repository.GetByIdAsync(customerId);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterMember command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // insert person
                    Member member = Mapper.Map<Member>(command);
                    _dbContext.Members.Add(member);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    MemberRegistered e = Mapper.Map<MemberRegistered>(command);
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                    // return result
                    return CreatedAtRoute("GetByMemberId", new { memberId = member.MemberId }, member);
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
