namespace I200_Quartz.Models
{
    public class T_Goods_Relation
    {

        /// <summary>
        /// 属性关联Id
        /// </summary>
        public int GrId { get; set; }

        /// <summary>
        /// 商品扩展Id
        /// </summary>
        public int GsId { get; set; }

        /// <summary>
        /// 自定义属性Id
        /// </summary>
        public int GaId { get; set; }

        /// <summary>
        /// 自定义属性名称
        /// </summary>
        public string GaName { get; set; }

        /// <summary>
        /// 自定义属性Id
        /// </summary>
        public int GaVid { get; set; }

        /// <summary>
        /// 自定义属性内容
        /// </summary>
        public string GaVName { get; set; }


    }
}
