using System;
using System.IO;
using log4net.Config;
using Topshelf;

namespace I200_Quartz
{
    static class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            HostFactory.Run(x =>
            {
                x.UseLog4Net();

                x.Service<ServiceRunner>();

                x.SetDescription("库存预警Server");
                x.SetDisplayName("库存预警");
                x.SetServiceName("GoodsWarning");

                x.EnablePauseAndContinue();
            });
        }
    }
}
