using System;
using Common.Logging;
using I200_Quartz.Services;
using Quartz;

namespace I200_Quartz.QuartzJobs
{
    /// <summary>
    /// 同步库存预警数据
    /// </summary>
    public sealed class SynchronizeGoodsWarningDataJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(SynchronizeGoodsWarningDataJob));

        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("库存预警数据同步开始：");
            var affectedRows = 0;
            try
            {
                var currentTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                affectedRows = SynchronizeGoodsDataServices.Instance.SynchronizeGoodsData(currentTime);
                _logger.InfoFormat(affectedRows >= 1 ? "单商品库存预警数据同步执行成功！" : "单商品库存预警数据同步执行失败!");
            }
            catch
            {
                affectedRows = -1;
                _logger.InfoFormat("单商品库存预警数据同步执行失败！");
            }
        }
    }
}


