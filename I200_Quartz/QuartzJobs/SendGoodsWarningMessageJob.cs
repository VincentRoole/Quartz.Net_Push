using System;
using I200_Quartz.Services;
using log4net;
using Quartz;

namespace I200_Quartz.QuartzJobs
{
    /// <summary>
    /// 定时发送库存预警数据给PC端和移动端
    /// </summary>
    public class SendGoodsWarningMessageJob : IJob
    {
        //使用log4net.dll日志接口实现日志记录

        private readonly ILog _logger = LogManager.GetLogger(typeof (SendGoodsWarningMessageJob));

        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("生意专家库存预警消息推送");

            try  
            {
                var currentToday = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                var result = PushGoodsStockWaringMessageServices.Instance.PushGoodsStockWaringMessage(currentToday);
                _logger.InfoFormat(result.ToString());
            }
            catch (Exception ex)
            {
                _logger.Error("运行异常", ex);
            }
        }



    }
}