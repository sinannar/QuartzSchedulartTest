using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace QuartzSchedulartTest
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            MyJobRunner myJobRunner = new MyJobRunner();
            Action<SimpleScheduleBuilder> action = x => x
                            .WithIntervalInSeconds(3)
                            .RepeatForever();

            Action<SimpleScheduleBuilder> dailyAction = x => x
                                        .WithIntervalInHours(24)
                                        .RepeatForever();


            await myJobRunner.InitializeWithSimpleSchedule(typeof(HelloJob), action);
            await myJobRunner.Start();

            while (true) { }
        }
    }
}
