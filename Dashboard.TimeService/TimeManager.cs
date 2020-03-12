﻿using System;
using System.Threading;
using System.Threading.Tasks;
using CCMS.Infrastructure.MessageQueue.Interfaces;
using Dashboard.TimeService.Events;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Dashboard.TimeService
{
    public class TimeManager : IHostedService
    {
        DateTime _lastCheck;
        CancellationTokenSource _cancellationTokenSource;
        Task _task;
        IMessagePublisher _messagePublisher;

        public TimeManager(IMessagePublisher messagePublisher)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _lastCheck = DateTime.Now;
            _messagePublisher = messagePublisher;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _task = Task.Run(() => Worker(), _cancellationTokenSource.Token);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async void Worker()
        {
            while (true)
            {
                if (DateTime.Now.Subtract(_lastCheck).Days > 0)
                {
                    Log.Information($"Day has passed!");
                    _lastCheck = DateTime.Now;
                    DateTime passedDay = _lastCheck.AddDays(-1);
                    DayHasPassed e = new DayHasPassed(Guid.NewGuid());

                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");
                }
                Thread.Sleep(10000);
            }
        }
    }
}
