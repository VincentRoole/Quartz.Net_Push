using Quartz;
using Quartz.Impl;
using Topshelf;

namespace I200_Quartz
{
    public sealed class ServiceRunner : ServiceControl, ServiceSuspend
    {
        private readonly IScheduler _scheduler;

        public ServiceRunner()
        {
            _scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }

        public bool Start(HostControl hostControl)
        {
            _scheduler.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _scheduler.Shutdown(false);
            return true;
        }

        public bool Continue(HostControl hostControl)
        {
            _scheduler.ResumeAll();
            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            _scheduler.PauseAll();
            return true;
        }


    }
}
