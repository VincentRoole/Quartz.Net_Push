using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    #region ProxyRequestModel 请求参数
    /// <summary>
    /// 请求参数
    /// </summary>
    public class ProxyRequestModel
    {
        /// <summary>
        /// 加密签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int? AccId { get; set; }

        /// <summary>
        /// 登录用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 店铺令牌Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 请求名称
        /// </summary>
        public string RequestName { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string RequestJson { get; set; }
    } 
    #endregion

    #region ProxyResponseModel 响应返回格式
    /// <summary>
    /// 响应返回格式
    /// </summary>
    public class ProxyResponseModel
    {
        /// <summary>
        /// 执行状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string ErrDesc { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int AccId { get; set; }

        /// <summary>
        /// 对象数据Json
        /// </summary>
        public string StrObj { get; set; }
    } 
    #endregion

    #region OpenRequestModel Open请求附加信息
    /// <summary>
    /// Open请求附加信息
    /// </summary>
    public class OpenRequestModel
    {
        /// <summary>
        /// 店铺Id
        /// </summary>
        public int AccId { get; set; }

        /// <summary>
        /// 登录人员Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 登录Token
        /// </summary>
        public String Token { get; set; }

        /// <summary>
        /// 登陆AppKey
        /// </summary>
        public string AppKey { get; set; }
    }
    #endregion

    #region ResponseModel 请求响应(Api)
    /// <summary>
    /// 请求响应(Api)
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// 执行状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// API版本
        /// </summary>
        public string Ver { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 业务Obj
        /// </summary>
        public object Data { get; set; }
    } 
    #endregion

    /// <summary>
    /// 请求参数相关
    /// </summary>
    public class OpenRequest
    {
        #region UserInfo 会员详情
        /// <summary>
        /// 会员详情
        /// </summary>
        public class UserInfo
        {
            /// <summary>
            /// 会员Id
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// 信息类型
            /// </summary>
            public string InfoType { get; set; }

            /// <summary>
            /// 更新内容
            /// </summary>
            public string EditVal { get; set; }
        } 
        #endregion

        #region BaseEdit 基本信息编辑
        public class BaseEdit
        {
            /// <summary>
            /// 信息类型
            /// </summary>
            public string InfoType { get; set; }

            /// <summary>
            /// 更新内容
            /// </summary>
            public string EditVal { get; set; }
        }
        #endregion


        #region 更新店铺密码

        public class UpdatePassword
        {
            /// <summary>
            /// 登录账号的ID
            /// </summary>
            public int uid { get; set; }
            /// <summary>
            /// 店铺ID
            /// </summary>
            public int accid { get; set; }
            /// <summary>
            /// 旧密码
            /// </summary>
            public string oldPassword { get; set; }
            /// <summary>
            /// 新密码
            /// </summary>
            public string newPassword { get; set; }
            /// <summary>
            /// 操作人ID
            /// </summary>
            public int operatorID { get; set; }
            /// <summary>
            /// 操作人IP
            /// </summary>
            public string operatorIP { get; set; }

        }


        #endregion


        #region 提交订单
        /// <summary>
        /// 订单生成提交参数
        /// </summary>
        public class OrderSubmitModel
        {
            public OrderSubmitModel()
            {
                GoodsQuantity = 1;
            }
            /// <summary>
            /// 移动端
            /// </summary>
            public int MobileBusId { get; set; }
            /// <summary>
            /// 原业务数量统一为商品数量
            /// </summary>
            public int GoodsQuantity { get; set; }

            /// <summary>
            /// 支付方式
            /// </summary>
            public int PayType { get; set; }

            /// <summary>
            /// 支付银行id
            /// </summary>
            public string PayBankId { get; set; }

            /// <summary>
            /// 优惠券Code
            /// </summary>
            public string CouponCode { get; set; }

            /// <summary>
            /// 是否开具发票
            /// </summary>
            public int InvoiceVal { get; set; }

            /// <summary>
            /// 发票描述
            /// </summary>
            public string InvoiceDesc { get; set; }

            /// <summary>
            /// 发票姓名
            /// </summary>
            public string InvoiceName { get; set; }

            /// <summary>
            /// 发票收件人
            /// </summary>
            public string InvoiceAddressee { get; set; }

            /// <summary>
            /// 发票手机号码
            /// </summary>
            public string InvoicePhone { get; set; }

            /// <summary>
            /// 发票地址
            /// </summary>
            public string InvoiceAdress { get; set; }

            /// <summary>
            /// 操作员ip  系统获取
            /// </summary>
            public string OperatorIp { get; set; }
            /// <summary>
            /// 备注，或者电话号码
            /// </summary>
            public string Remark { get; set; }

            /// <summary>
            /// 抵值积分
            /// </summary>
            public int CommuteIntegral { get; set; }
        }

        /// <summary>
        /// 订单支付凭证
        /// </summary>
        public class OrderTransactionReceipt
        {
            /// <summary>
            /// 订单ID
            /// </summary>
            public int orderId { get; set; }
            /// <summary>
            /// 订单编号
            /// </summary>
            public string orderNo { get; set; }
            /// <summary>
            /// 订单金额
            /// </summary>
            public decimal orderMoney  { get; set; }
            /// <summary>
            /// 支付状态
            /// </summary>
            public string transactionState { get; set; }
            /// <summary>
            /// 支付凭证
            /// </summary>
            public string transactionReceipt { get; set; }

            /// <summary>
            /// 支付类别 1 IOS 2 支付宝
            /// </summary>		
            public int payType
            {
                get;
                set;
            }
            /// <summary>
            /// 支付类别说明
            /// </summary>		
            public string payTypeDesc
            {
                get;
                set;
            }
        }
        #endregion
    }
}
