using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuartzSchedulartTest
{
    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            // Say Hello to the World and display the date/time
            Console.WriteLine("Hello World! - " + DateTimeOffset.Now);
            return null;
        }
}
}
