using System;
using System.Runtime.CompilerServices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TheBestOfChuck.Exceptions;
using TheBestOfChuck.Services;

namespace TheBestOfChuck
{
    public class TriggerJokeDownloadFunction
    {
        private readonly ILogger _logger;
        private readonly ICollectDataService _collectDataService;

        public TriggerJokeDownloadFunction(ILoggerFactory loggerFactory, ICollectDataService collectData)
        {
            _logger = loggerFactory.CreateLogger<TriggerJokeDownloadFunction>();
            _collectDataService = collectData;
        }

        [Function("PullChuckJokes")]
        public async Task Run([TimerTrigger("*/10 * * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"{DateTime.Now}|Information|Time trigger function executed");
            await _collectDataService.collectMultipleJokesAsync(5);
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
