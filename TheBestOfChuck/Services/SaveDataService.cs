using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestOfChuck.Entities;

namespace TheBestOfChuck.Services
{
    public interface ISaveDataService
    {
        public void SaveUniqueChuckJoke(string joke);
    }

    public class SaveDataService : ISaveDataService
    {
        private readonly ChuckJokeDbContext _dbContext;
        private readonly ILogger _logger;
        public SaveDataService(ChuckJokeDbContext dbContext, ILogger<SaveDataService> logger) 
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void SaveUniqueChuckJoke(string joke)
        {
            var repetition = _dbContext.ChuckJokes.FirstOrDefault(chuckJokes => chuckJokes.Joke == joke);

            if (repetition == null)
            {
                var data = new ChuckJoke()
                {
                    Date = DateTime.Now,
                    Joke = joke
                };

                _dbContext.ChuckJokes.Add(data);
                _dbContext.SaveChanges();

                _logger.LogInformation($"{DateTime.Now}|INFORMATION|Data saved succesfully to database");
            }
        }
    }
}
