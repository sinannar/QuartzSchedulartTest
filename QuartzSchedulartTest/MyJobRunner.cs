using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuartzSchedulartTest
{
    public class MyJobRunner
    {
        protected ISchedulerFactory sf { get; set; }
        protected IScheduler sched { get; set; }
        protected IJobDetail job { get; set; }
        protected ITrigger trigger { get; set; }
        protected string jobname { get; set; }
        protected string groupname { get; set; }
        protected string triggername { get; set; }


        public async Task InitializeWithSimpleSchedule(Type type, Action<SimpleScheduleBuilder> action)
        {
            jobname = Guid.NewGuid().ToString();
            groupname = Guid.NewGuid().ToString();
            triggername = Guid.NewGuid().ToString();
            sf = new StdSchedulerFactory();
            sched = await sf.GetScheduler();
            job = JobBuilder.Create(type)
                .WithIdentity(jobname, groupname)
                .Build();

            trigger = TriggerBuilder.Create()
                .WithIdentity(triggername, groupname)
                .WithSimpleSchedule(action)
                .Build();

            await sched.ScheduleJob(job, trigger);
        }

        public async Task Start()
        {
            await sched.Start();
        }
    }
}
