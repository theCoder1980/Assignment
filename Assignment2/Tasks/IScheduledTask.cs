using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2.Tasks
{
    /// <summary>
    /// Scheduled Task interface
    /// </summary>
    public interface IScheduledTask
    {
        /// <summary>
        /// Schedule name
        /// </summary>
        string Schedule { get; }
        /// <summary>
        /// Task execution with cancellation token
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
