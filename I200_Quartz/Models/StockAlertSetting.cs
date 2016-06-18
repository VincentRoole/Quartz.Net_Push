using System;

namespace I200_Quartz.Models
{
    /// <summary>
    /// 库存预警
    /// </summary>
    public class StockAlertSetting
    {
        /// <summary>
        /// 店铺Id
        /// </summary>
        public int AccId { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string UserRealName { get; set; }

        /// <summary>
        /// 提醒功能开关
        /// </summary>
        public int AlertStatus { get; set; }

        /// <summary>
        /// 提醒时间
        /// </summary>
        public int AlertTime { get; set; }

        /// <summary>
        /// 网页推送
        /// </summary>
        public int IsWeb { get; set; }

        /// <summary>
        /// 手机短信
        /// </summary>
        public int IsSms { get; set; }

        /// <summary>
        /// 手机推送
        /// </summary>
        public int IsMob { get; set; }

        /// <summary>
        /// 邮件提醒
        /// </summary>
        public int IsEmail { get; set; }
    }
}
