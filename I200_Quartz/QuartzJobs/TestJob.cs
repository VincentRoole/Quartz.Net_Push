using I200_Quartz.CommonHelpers;
using I200_Quartz.Helpers;
using log4net;
using Quartz;

namespace I200_Quartz.QuartzJobs
{

    /// <summary>
    /// Job测试实例
    /// </summary>
    public sealed class TestJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TestJob));

        public void Execute(IJobExecutionContext context)
        {
            var strSql = "  INSERT INTO  dbo.zhuchepage( ip_address ,regtime ,number , end_time ,page)VALUES  ( '101' , GETDATE() ,0 ,GETDATE() ,  'liupeng') ";
            var count = DbHelperSQL.ExecuteSql(strSql);
            var result = count == 1 ? "success" : "fail";
            _logger.InfoFormat("生意专家数据同步测试: " + result);
        }
    }
}
