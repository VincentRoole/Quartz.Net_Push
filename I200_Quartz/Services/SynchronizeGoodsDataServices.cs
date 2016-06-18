using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I200_Quartz.DataManager;

// ReSharper disable once CheckNamespace
namespace I200_Quartz.Services
{
    public class SynchronizeGoodsDataServices
    {
        public static readonly SynchronizeGoodsDataServices Instance;

        // ReSharper disable once FunctionRecursiveOnAllPaths
        static SynchronizeGoodsDataServices()
        {
            Instance= new SynchronizeGoodsDataServices();
        }

        /// <summary>
        /// 统计单商品库存预警数据
        /// </summary>
        /// <param name="currentTime"></param>
        public int SynchronizeGoodsData(string currentTime)
        {
            return SynchronizeGoodsDataManager.Insatnce.SynchronizeGoodsData(currentTime);
        }

    }
}