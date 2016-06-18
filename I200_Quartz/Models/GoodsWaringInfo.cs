using System;

namespace I200_Quartz.Models
{
    public class GoodsWaringInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CurrentTime { get; set; }

        /// <summary>
        /// 店铺的Id
        /// </summary>
        public int AccId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 预警时间
        /// </summary>
        public int AlertTime { get; set; }

        /// <summary>
        /// 是否PC端推送
        /// </summary>
        public int IsWeb { get; set; }

        /// <summary>
        /// 是否短信推送
        /// </summary>
        public int IsSms { get; set; }

        /// <summary>
        /// 是否移动端推送
        /// </summary>
        public int IsMob { get; set; }

        /// <summary>
        /// 是否邮件推送
        /// </summary>
        public int IsEmail { get; set; }

        /// <summary>
        /// 商品的Id
        /// </summary>
        public int  GId { get; set; }

        /// <summary>
        /// 自定义属性Id
        /// </summary>
        public int GsId { get; set; }

        /// <summary>
        /// 商品的名称
        /// </summary>
        public string GName { get; set; }

        /// <summary>
        /// 商品的数量
        /// </summary>
        public int GQuantity { get; set; }

        /// <summary>
        /// 预警的下限
        /// </summary>
        public decimal LimitLower { get; set; }

        /// <summary>
        /// 预警的上限
        /// </summary>
        public decimal LimitUpper { get; set; }

        /// <summary>
        /// 是否是拓展商品
        /// </summary>
        public int IsExtend { get; set; }

        /// <summary>
        /// 操作的时间
        /// </summary>
        public DateTime OperateTime { get; set; }

    }
}