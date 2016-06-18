using System;
using System.Collections.Generic;
using System.Text;
using I200_Quartz.CommonHelpers;
using I200_Quartz.Models;

namespace I200_Quartz.DataManager
{
    public class SynchronizeGoodsDataManager
    {
        public static readonly SynchronizeGoodsDataManager Insatnce;

        static SynchronizeGoodsDataManager()
        {
            Insatnce = new SynchronizeGoodsDataManager();
        }

        /// <summary>
        /// Test
        /// </summary>
        /// <returns></returns>
        public int getInt()
        {
            return 1;
        }

        /// <summary>
        /// 统计单商品库存预警数据
        /// </summary>
        /// <param name="currentTime"></param>
        public int SynchronizeGoodsData(string currentTime)
        {
            var result = 0;

            //1.先获取打开库存预警开关的所有店铺
            var stockSettingList = GetAlertSettings();

            //2.根据店铺的Id获取店铺的商品数据
            foreach (var item in stockSettingList)
            {
                //普通商品
                var goodInfoList = GetGoodsInfo(item.AccId);
                //自定义属性商品
                goodInfoList.AddRange(GetGoodsExtendInfo(item.AccId));

                //3.对比当前的库存数量和库存预警值
                foreach (var oItem in goodInfoList)
                {
                    if (oItem.LimitUpper != null)
                    {
                        if (oItem.GQuantity >= oItem.LimitUpper)
                        {
                            oItem.WarningType = 1;
                            //4.属于超出库存预警上限数据，则记录存入
                            result = SaveSingleGoodsWarningData(item, oItem);
                        }
                    }

                    if (oItem.LimitLower != null)
                    {
                        if (oItem.GQuantity <= oItem.LimitLower)
                        {
                            oItem.WarningType = 0;
                            //5.属于低于库存预警下限数据，则记录存入
                            result = SaveSingleGoodsWarningData(item, oItem);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取打开库存预警的商铺设置数据
        /// </summary>
        /// <returns></returns>
        public List<StockAlertSetting> GetAlertSettings()
        {
            StringBuilder sqlStr = new StringBuilder();
            var stockSettingList = new List<StockAlertSetting>();
            sqlStr.Append(
                "SELECT  m.accId,n.CompanyName,m.alertStatus,m.alertTime,m.isWeb,m.isSms,m.isMob,m.isEmail FROM T_Goods_StockAlertSetting m LEFT JOIN dbo.T_Account n ON m.accId =n.ID WHERE m.alertStatus=1;");
            var dataResult = DapperHelper.Query<dynamic>(sqlStr.ToString());
            foreach (dynamic item in dataResult)
            {
                var stockSetting = new StockAlertSetting();
                stockSetting.AccId = Convert.ToInt32(item.accId);
                stockSetting.UserRealName = item.CompanyName;
                stockSetting.AlertStatus = Convert.ToInt32(item.alertStatus);
                stockSetting.AlertTime = Convert.ToInt32(item.alertTime);
                stockSetting.IsWeb = Convert.ToInt32(item.isWeb);
                stockSetting.IsSms = Convert.ToInt32(item.isSms);
                stockSetting.IsMob = Convert.ToInt32(item.isMob);
                stockSetting.IsEmail = Convert.ToInt32(item.isEmail);
                stockSettingList.Add(stockSetting);
            }

            return stockSettingList;
        }


        /// <summary>
        /// 根据商品Id获取商品的信息
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        private List<GoodsInfoModel> GetGoodsInfo(int accId)
        {
            StringBuilder sqlStr = new StringBuilder();
            var goodInfoList = new List<GoodsInfoModel>();
            sqlStr.Append("select * from dbo.T_GoodsInfo where accID=@accID  AND  IsExtend  is null and isDown <> 1 ; ");
            var dataResult = DapperHelper.Query<dynamic>(sqlStr.ToString(), new {accID = accId});
            if (dataResult != null)
            {
                foreach (var item in dataResult)
                {
                    var goodInfo = new GoodsInfoModel();
                    goodInfo.Gid = Convert.ToInt32(item.gid);
                    goodInfo.AccId = Convert.ToInt32(item.accID);
                    goodInfo.GName = item.gName;
                    goodInfo.GQuantity = Convert.ToDecimal(item.gQuantity);
                    goodInfo.LimitLower = item.LimitLower;
                    goodInfo.LimitUpper = item.LimitUpper;
                    goodInfo.IsExtend = 0;
                    goodInfoList.Add(goodInfo);
                }
            }

            return goodInfoList;
        }

        /// <summary>
        /// 根据商品的Id获取拓展商品的信息
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        private List<GoodsInfoModel> GetGoodsExtendInfo(int accId)
        {
            StringBuilder sqlStr = new StringBuilder();
            var goodInfoExtendList = new List<GoodsInfoModel>();
            sqlStr.Append(
                "SELECT m.gid AS gid,n.gsId as gsId, m.accID AS accID,M.gName AS gName,N.gsQuantity AS gQuantity,N.LimitLower AS LimitLower,N.LimitUpper AS LimitUpper  FROM dbo.T_GoodsInfo m LEFT JOIN dbo.T_Goods_Sku n ON m.gid =n.gid WHERE m.accID=@accID  AND  m.IsExtend =1  AND m.isDown <> 1;");
            var dataResult = DapperHelper.Query<dynamic>(sqlStr.ToString(), new {accID = accId});
            if (dataResult != null)
            {
                foreach (var item in dataResult)
                {
                    var goodInfo = new GoodsInfoModel();
                    goodInfo.Gid = Convert.ToInt32(item.gid);
                    goodInfo.AccId = Convert.ToInt32(item.accID);
                    goodInfo.Gsid = item.gsId;
                    goodInfo.GName = item.gName + "_" + GetAttributeName(Convert.ToInt32(item.gsId));
                    goodInfo.GQuantity = Convert.ToDecimal(item.gQuantity);
                    goodInfo.LimitLower = item.LimitLower;
                    goodInfo.LimitUpper = item.LimitUpper;
                    goodInfo.IsExtend = 1;
                    goodInfoExtendList.Add(goodInfo);
                }
            }
            return goodInfoExtendList;
        }

        /// <summary>
        /// 获取拓展商品的自定义属性名称
        /// </summary>
        /// <param name="gsId"></param>
        /// <returns></returns>
        private string GetAttributeName(int gsId)
        {
            StringBuilder strSql = new StringBuilder();
            var attributeName = string.Empty;
            strSql.Append("  SELECT  gaVName FROM dbo.T_Goods_Relation WHERE gsId=@gsId");
            var dataResult = DapperHelper.Query<dynamic>(strSql.ToString(), new {gsId = gsId});
            if (dataResult != null)
            {
                foreach (var item in dataResult)
                {
                    attributeName += item.gaVName + "_";
                }
            }
            return attributeName.Substring(0, attributeName.Length - 1);
        }

        /// <summary>
        /// 保存库存预警数据
        /// </summary>
        /// <returns></returns>
        private int SaveSingleGoodsWarningData(StockAlertSetting stockalertInfo, GoodsInfoModel goodInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(goodInfo.IsExtend == 1
                ? " if(exists( SELECT id FROM [Sys_I200].[dbo].T_SingleGoodsWaring WHERE  DATEDIFF(DAY,currentDate,@insertDate)=0 AND accId=@accId AND gid=@gid AND gsId=@gsId))"
                : " if(exists( SELECT id FROM [Sys_I200].[dbo].T_SingleGoodsWaring WHERE  DATEDIFF(DAY,currentDate,@insertDate)=0 AND accId=@accId AND gid=@gid AND gsId is null))");
            strSql.Append(" begin");
            strSql.Append("   select 1");
            //strSql.Append("UPDATE T_SingleGoodsWaring SET userRealName=@userRealName,alertStatus=@alertStatus,alertTime=@alertTime,isWeb=@isWeb,isSms=@isSms,isMob=@isMob,isEmail=@isEmail,gQuantity=@gQuantity,limitLower=@limitLower,limitUpper=@limitUpper,operateTime=@operateTime  WHERE DATEDIFF(DAY,currentDate,@insertDate)=0 AND accId=@accId AND gid=@gid AND gsId IS NULL; ");
            strSql.Append(" end");
            strSql.Append(" else");
            strSql.Append("  begin");
            strSql.Append("    INSERT INTO [Sys_I200].[dbo].T_SingleGoodsWaring(currentDate,accid,userRealName,alertStatus,alertTime,isWeb,isSms,isMob,isEmail,gid,gsId,gName,gQuantity,limitLower,limitUpper,warningType,isExtend,remark,operateTime) VALUES(@currentDate,@accId,@userRealName,@alertStatus,@alertTime,@isWeb,@isSms,@isMob,@isEmail,@gid,@gsId,@gName,@gQuantity,@limitLower,@limitUpper,@warningType,@isExtend,@remark,@operateTime);");
            strSql.Append(" end");
            var result = CommonHelpers.DapperHelper.Execute(strSql.ToString(),
                new
                {
                    currentDate= DateTime.Now.AddDays(-1).Date,
                    accId = goodInfo.AccId,
                    insertDate=DateTime.Now.AddDays(-1).Date,
                    userRealName = stockalertInfo.UserRealName,
                    alertStatus = stockalertInfo.AlertStatus,
                    alertTime = stockalertInfo.AlertTime,
                    isWeb = stockalertInfo.IsWeb,
                    isSms = stockalertInfo.IsSms,
                    isMob = stockalertInfo.IsMob,
                    isEmail = stockalertInfo.IsEmail,
                    gid = goodInfo.Gid,
                    gsId = goodInfo.Gsid,
                    gName = goodInfo.GName,
                    gQuantity = goodInfo.GQuantity,
                    limitLower = goodInfo.LimitLower,
                    limitUpper = goodInfo.LimitUpper,
                    warningType= goodInfo.WarningType,
                    isExtend = goodInfo.IsExtend,
                    remark = "",
                    operateTime = DateTime.Now
                });
            return result;
        }
    }
}