using System;
using I200_Quartz.DataManager;
using NUnit.Framework;

namespace I200_QuartzTests.DataManager
{
    [TestFixture()]
    public class SynchronizeGoodsDataManagerTests
    {
        [Test()]
        public void GetAlertSettingsTest()
        {
            var alertSettingList = SynchronizeGoodsDataManager.Insatnce.GetAlertSettings();
            Console.WriteLine(alertSettingList.Count > 0 ? "获取库存预警店铺数据成功" : "获取库存预警店铺数据失败");
        }

        [Test]
        public void getInt()
        {
            var num = SynchronizeGoodsDataManager.Insatnce.getInt();
            if (num>0)
            {
                Console.WriteLine("true");
            }
        }
    }
}
