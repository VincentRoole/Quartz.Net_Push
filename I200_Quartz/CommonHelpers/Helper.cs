using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Models;
using RestSharp;

namespace I200_Quartz.CommonHelpers
{

  public static class Helper
    {
        /// <summary>
        /// API接口密钥
        /// </summary>
      public static string AuthCode = "XKCE9P34TsqemfITS0W18RX6ewsxPK07MALZJ7Y";

      public static string AppKey = "I200LD02WSUQIRRGYM";

      public static string AppSecret = "WSKXQ896OMDCS7YMWVZFbwPYzlQp33zg";

      public static readonly string SysAuthCode = "YH_B8C29A60A8E2D8670CCA3CE15C3E6486";
      public static readonly string SysSecretKey = "YH_82ABE0DCF6670473D3A532B43A413E18";


        #region RestRequest Http Rest请求
        /// <summary>
        /// Http Rest请求
        /// </summary>
        /// <param name="baseUrl">Host</param>
        /// <param name="resource">RecoureUrl</param>
        /// <param name="method">Method</param>
        /// <param name="parameters">Parameters</param>
        /// <param name="headers">Headers</param>
        /// <returns></returns>
        public static string RestRequest(string baseUrl, string resource, Method method, Dictionary<string, string> parameters, Dictionary<string, string> headers = null)
        {
            string strResult = "";

            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, method);

            request.RequestFormat = DataFormat.Json;
            

            if (headers != null)
            {
                if (headers.Count > 0)
                {
                    foreach (var headItem in headers)
                    {
                        request.AddHeader(headItem.Key, headItem.Value);
                    }
                }
            }

            if (method == Method.POST)
            {
                if (parameters != null)
                {
                    if (parameters.Count > 0)
                    {
                        foreach (var item in parameters)
                        {
                            request.AddParameter(item.Key, item.Value);
                        }
                    }
                }
            }

            if (method == Method.GET)
            {
                if (parameters != null)
                {
                    if (parameters.Count > 0)
                    {
                        foreach (var item in parameters)
                        {
                            request.AddQueryParameter(item.Key, item.Value);
                        }
                    }
                }
            }

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                strResult = response.Content;
            }

            return strResult;
        }
        #endregion

        #region RestPost HttpPost请求
        /// <summary>
        /// HttpPost请求
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="resource"></param>
        /// <param name="parameters"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string RestPost(string baseUrl, string resource, Dictionary<string, string> parameters, Dictionary<string, string> headers = null)
        {
            var method = Method.POST;
            return RestRequest(baseUrl, resource, method, parameters, headers);
        }
        #endregion

        #region RestGet HtppGet请求
        /// <summary>
        /// HtppGet请求
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="resource"></param>
        /// <param name="parameters"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string RestGet(string baseUrl, string resource, Dictionary<string, string> parameters, Dictionary<string, string> headers = null)
        {
            var method = Method.GET;
            return RestRequest(baseUrl, resource, method, parameters, headers);
        }
        #endregion


        #region CreateAuthCode 生成验证信息
        /// <summary>
        /// 生成验证信息
        /// </summary>
        /// <returns></returns>
        public static ProxyRequestModel CreateAuthCode()
        {
            var requestMd = new ProxyRequestModel { Timestamp = GetTimeStamp(), Nonce = GetRandomNum() };

            var strSign = new StringBuilder();
            strSign.Append(AuthCode);
            strSign.Append(requestMd.Timestamp);
            strSign.Append(requestMd.Nonce);
            requestMd.Signature = Md5Hash(strSign.ToString());

            return requestMd;
        }
        #endregion

        #region GetTimeStamp 获取时间戳
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion


        #region GetRandomNum 获得随机数(6位长度)
        /// <summary>
        /// 获得随机数(6位长度)
        /// </summary>
        /// <returns></returns>
        public static string GetRandomNum()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            return r.Next(100000, 999999).ToString();
        }
        #endregion

        #region SHA1_Encrypt SHA1加密函数
        /// <summary>
        /// SHA1加密函数
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string SHA1_Encrypt(string sourceString)
        {
            byte[] strRes = Encoding.UTF8.GetBytes(sourceString);
            HashAlgorithm hashSha = new SHA1CryptoServiceProvider();
            strRes = hashSha.ComputeHash(strRes);
            var enText = new StringBuilder();
            foreach (byte iByte in strRes)
            {
                enText.AppendFormat("{0:x2}", iByte);
            }
            return enText.ToString();
        }
        #endregion

        #region Md5Hash 获取字符串MD5哈希值
        /// <summary>
        /// 获取字符串MD5哈希值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        #endregion


        #region JsonDeserializeObject 反序列化Json对象
        /// <summary>
        /// 反序列化Json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T JsonDeserializeObject<T>(string strJson)
        {
            fastJSON.JSON.Instance.Parameters.SerializeNullValues = true;
            fastJSON.JSON.Instance.Parameters.ShowReadOnlyProperties = true;
            fastJSON.JSON.Instance.Parameters.UseUTCDateTime = false;
            fastJSON.JSON.Instance.Parameters.UsingGlobalTypes = false;
            fastJSON.JSON.Instance.Parameters.EnableAnonymousTypes = true;

            return fastJSON.JSON.Instance.ToObject<T>(strJson);
        }


        #endregion

        #region JsonDeserializeObject 反序列化Json为dynamic对象
        /// <summary>
        /// 反序列化Json为dynamic对象
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static dynamic JsonDeserializeObject(string strJson)
        {
            fastJSON.JSON.Instance.Parameters.SerializeNullValues = true;
            fastJSON.JSON.Instance.Parameters.ShowReadOnlyProperties = true;
            fastJSON.JSON.Instance.Parameters.UseUTCDateTime = false;
            fastJSON.JSON.Instance.Parameters.UsingGlobalTypes = false;
            fastJSON.JSON.Instance.Parameters.EnableAnonymousTypes = true;

            return fastJSON.JSON.Instance.ToDynamic(strJson);
        }
        #endregion

        /// <summary>
        /// 产生范围内的随机小数
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static double GetRandomNumber(double minimum, double maximum, int len)   //Len小数点保留位数
        {
            Random random = new Random();
            return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, len);
        } 
    }
}
