using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestOfChuck.Entities;
using TheBestOfChuck.Exceptions;
using TheBestOfChuck.Models;

namespace TheBestOfChuck.Services
{
    public interface ICollectDataService
    {
        public Task collectMultipleJokesAsync(int jokesNumber);
    }

    public class CollectDataService : ICollectDataService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger _logger;
        public readonly ISaveDataService _saveDataService;
        public readonly IServiceHelper _serviceHelper;

        public CollectDataService(ILogger<CollectDataService> logger, IHttpClientService httpClientService, ISaveDataService saveDataService, IServiceHelper serviceHelper) 
        {
            _logger = logger;
            _httpClientService = httpClientService;
            _saveDataService = saveDataService;
            _serviceHelper = serviceHelper;
        }

        public async Task collectMultipleJokesAsync(int jokesNumber)
        {
            if (jokesNumber <= 0)
            {
                throw new InvalidInputDataException("Invalid input data for CollectMultipleJokesAsync method. Please select integer greater than 0");
            } 

            for (int i = 0; i < jokesNumber; i++)
            {
                var joke = await _httpClientService.ReturnChuckJoke();
                if (_serviceHelper.isExceedingLength(joke, 200))
                {
                    _saveDataService.SaveUniqueChuckJoke(joke);
                }
            }

        }

    }
}
