using System;
using System.Collections.Generic;
using System.Text;
using I200_Quartz.CommonHelpers;
using Models;

namespace I200_Quartz.DataManager
{
    public class PushGoodsStockWaringMessageManager
    {
        public static readonly PushGoodsStockWaringMessageManager Instance;

        private static readonly string SysAddresss = System.Configuration.ConfigurationManager.AppSettings["SysAddresss"];

        static  PushGoodsStockWaringMessageManager()
        {
            Instance= new PushGoodsStockWaringMessageManager();
        }

        /// <summary>
        /// 推送单商品库存预警消息
        /// </summary>
        /// <param name="currentTime"></param>
        public string PushGoodsStockWaringMessage(string currentTime)
        {
            var requestMd = new ProxyRequestModel { Timestamp = Helper.GetTimeStamp(), Nonce = Helper.GetRandomNum() };
            var strSign = new StringBuilder();
            strSign.Append(Helper.SysAuthCode);
            strSign.Append(requestMd.Timestamp);
            strSign.Append(requestMd.Nonce);
            strSign.Append(Helper.SysSecretKey);
            requestMd.Signature = Helper.Md5Hash(strSign.ToString());
            var headers = new Dictionary<string, string>
                {
                    {"Signature", requestMd.Signature},
                    {"Timestamp", requestMd.Timestamp},
                    {"Nonce", requestMd.Nonce},
                    {"AppKey", Helper.AppKey}
                };
            var strSql = new StringBuilder();
            var oRetData = Helper.RestPost(SysAddresss, "", null, headers);
            var resultMessage = oRetData!= null ? "数据推送完成" : "数据推送失败";

            return resultMessage;
        }
    }
}