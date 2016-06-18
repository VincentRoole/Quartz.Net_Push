using System;
using I200_Quartz.DataManager;

// ReSharper disable once CheckNamespace
namespace I200_Quartz.Services
{
    public class PushGoodsStockWaringMessageServices
    {
        public static readonly PushGoodsStockWaringMessageServices Instance;

        // ReSharper disable once FunctionRecursiveOnAllPaths
        static PushGoodsStockWaringMessageServices()
        {
            Instance=new PushGoodsStockWaringMessageServices();
        }

        /// <summary>
        /// 推送单商品库存预警消息
        /// </summary>
        public int PushGoodsStockWaringMessage(string currentTime)
        {
            var result = 0;
            var currentToday = Convert.ToDateTime(currentTime);

            //1.获取推送的数据信息
            var oRetData = PushGoodsStockWaringMessageManager.Instance.PushGoodsStockWaringMessage(currentTime);
            
            //2.推送数据信息

            return result;
        }
    }
}