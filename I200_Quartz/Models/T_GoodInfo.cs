using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I200_Quartz.Models
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public partial class GoodsInfoModel
    {
        #region t_goodsInfo 基本信息
        /// <summary>
        /// 商品ID
        /// </summary>
        public int Gid { get; set; }

        /// <summary>
        /// 拓展商品Id
        /// </summary>
        public int? Gsid { get; set; }

        /// <summary>
        /// 所属店铺的Id
        /// </summary>
        public int AccId { get; set; }

        /// <summary>
        /// 大分类名称
        /// </summary>
        public string GMaxName { get; set; }
        /// <summary>
        /// 大分类ID
        /// </summary>
        public int GMaxId { get; set; }
        /// <summary>
        /// 小分类
        /// </summary>
        public string GMinName { get; set; }
        /// <summary>
        /// 小分类ID
        /// </summary>
        public int GMinId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GName { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public decimal GQuantity { get; set; }
        /// <summary>
        /// 商品折扣
        /// </summary>
        public decimal GDiscount { get; set; }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string GSpecification { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal GPrice { get; set; }
        /// <summary>
        /// 商品进价
        /// </summary>
        public decimal GCostPrice { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        public string GRemark { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GBarcode { get; set; }
        /// <summary>
        /// 是否下架
        /// <para>0:正常 1:已下架</para>
        /// </summary>
        public int IsDown { get; set; }
        /// <summary>
        /// 是否服务
        /// <para>0：不是  1：是</para>
        /// </summary>
        public int IsService { get; set; }
        /// <summary>
        /// 是否有扩展
        /// </summary>
        public int IsExtend { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime GAddTime { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public int SupplierId { get; set; }
        /// <summary>
        /// 供应商姓名
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 是否计算积分
        /// 0：不计算 1：计算 空：默认
        /// </summary>
        public int? IsCalculatePoint { get; set; }
        /// <summary>
        /// 是否计算积分汉字
        /// </summary>
        public string IsCalculatePointText { get; set; }

        /// <summary>
        /// 库存预警下限
        /// </summary>
        public decimal? LimitLower { get; set; }

        /// <summary>
        /// 库存预警的上限
        /// </summary>
        public decimal? LimitUpper { get; set; }

        /// <summary>
        /// 库存预警类型（超过上限还是下限）
        /// </summary>
        public int WarningType { get; set; }

        #endregion


        #region SKU 属性

        /// <summary>
        /// 商品SKU
        /// </summary>
        public List<T_GoodsSkuBasis> SkuList { get; set; }

        #endregion

    }
}
