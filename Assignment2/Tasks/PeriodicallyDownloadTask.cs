﻿using Assignment2.Data;
using Assignment2.Entities;
using Assignment2.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2.Tasks
{
    /// <summary>
    /// Peridically download the photos from the External API
    /// </summary>
   
        internal class PeriodicallyDownloadTask : IHostedService
        {
            private readonly ILogger _logger;
            private Timer _timer;
            private readonly IHttpClientFactory _httpClientFactory;
            private readonly IConfiguration _configuration;
            private readonly IServiceProvider _provider;
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public PeriodicallyDownloadTask(ILogger<PeriodicallyDownloadTask> logger, IHttpClientFactory httpClientFactory,
                IConfiguration configuration, IServiceProvider serviceProvider)
            {
                _logger = logger;
                _httpClientFactory = httpClientFactory;
                _configuration = configuration;
                _provider = serviceProvider;


        }
            /// <summary>
            /// Starting the task
            /// </summary>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public Task StartAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("Timed Background Service is starting.");

                _timer = new Timer(DoWork, null, TimeSpan.Zero,
                    TimeSpan.FromDays(1));

                return Task.CompletedTask;
            }
            /// <summary>
            /// The delegate job
            /// </summary>
            /// <param name="state"></param>
            private async void DoWork(object state)
            {
                _logger.LogInformation("Timed Background Service is working.");
                try
                {

                    using (IServiceScope scope = _provider.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<PhotoDbContext>();
                        var photos = context.Photos.AsNoTracking().Any();

                    if (!photos)
                    {

                        var client = _httpClientFactory.CreateClient();
                        var aPIUrl = _configuration.GetValue<string>("ExternalAPIUrl");
                        _logger.LogInformation("External API Url:{0}", aPIUrl);
                        var jsonObjects = await client.GetStringAsync(aPIUrl);
                        _logger.LogInformation("jsonObjects, {0}", jsonObjects);

                        var Photos = JsonConvert.DeserializeObject<List<Photo>>(jsonObjects);
                        if (Photos.Count <= 0)
                            _logger.LogInformation("Photo json object return 0 count:{0}", Photos);

                        Photos.ForEach(item => context.Photos.Add(item));
                        context.SaveChanges();

                    }
                }
             }
                catch (Exception ex)
                {

                    _logger.LogCritical("Convert json objects and insert into database table error occured.{0}", ex);
                }
            }

            /// <summary>
            /// Stopping the task
            /// </summary>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public Task StopAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("Timed Background Service is stopping.");

                _timer?.Change(Timeout.Infinite, 0);

                return Task.CompletedTask;
            }

            /// <summary>
            /// Dispose the timer
            /// </summary>
            public void Dispose()
            {
                _timer?.Dispose();
            }

           
        }

    
}
