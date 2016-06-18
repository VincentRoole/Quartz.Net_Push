using System.Collections.Generic;

namespace I200_Quartz.Models
{
    /// <summary>
    /// 商品SKU 基本信息
    /// </summary>
    public class T_GoodsSkuBasis
    {
        /// <summary>
        /// SKUID
        /// </summary>
        public int GsId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int Gid { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public decimal GsQuantity { get; set; }
        /// <summary>
        /// 商品折扣
        /// </summary>
        public decimal GsDiscount { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal GsPrice { get; set; }
        /// <summary>
        /// 商品进价
        /// </summary>
        public decimal GsCostPrice { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GsBarcode { get; set; }
        /// <summary>
        /// 属性说明
        /// </summary>
        public List<T_Goods_Relation> SkuRelation { get; set; }
        /// <summary>
        /// 是否计算积分
        /// </summary>
        public int? IsCalculatePoint { get; set; }

        /// <summary>
        /// 库存预警下限
        /// </summary>
        public decimal? LimitLower { get; set; }

        /// <summary>
        /// 库存预警的上限
        /// </summary>
        public decimal? LimitUpper { get; set; }
    }
}
