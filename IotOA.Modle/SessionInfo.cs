using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace IotOA.Model
{
    /// <summary>
    /// 非数据库表 用来存放Session信息
    /// </summary>
    public class SessionInfo
    {
        public static  IHttpContextAccessor _httpContextAccessor;
       
      
  
        ////开发环境跳过登录
        ///// <summary>
        ///// 用户ID
        ///// </summary>
        //public static object UserID
        //{
        //    get { return 1; }
        //    set { System.Web.HttpContext.Current.Session["UserID"] = value; }
        //}

        ///// <summary>
        ///// 登录名
        ///// </summary>
        //public static string LoginName
        //{
        //    get { return System.Web.HttpContext.Current.Session["LoginName"].ToString(); }
        //    set { System.Web.HttpContext.Current.Session["LoginName"] = value; }
        //}
        ///// <summary>
        ///// 用户名称
        ///// </summary>
        //public static string UserName
        //{
        //    get { return "系统管理员"; }
        //    set { System.Web.HttpContext.Current.Session["UserName"] = value; }
        //}

        ///// <summary>
        ///// 是否系统管理员
        ///// </summary>
        //public static bool IsAdmin
        //{
        //    get { return true; }
        //    set { System.Web.HttpContext.Current.Session["IsAdmin"] = value; }
        //}

        /// <summary>
        /// 用户ID
        /// </summary>
        public static  object UserID
        {
            get { return GetSession("UserID"); }
            set { SetSession("UserID", value); }
        }
        /// <summary>
        /// 获取session值
        /// </summary>
        /// <param name="key">session的key</param>
        /// <returns></returns>
        private static string GetSession(string key)
        {
            string value = string.Empty;
            byte[] obj = null;
            //在类中使用session通过out byte[],来返回session.
            _httpContextAccessor.HttpContext.Session.TryGetValue(key, out obj);
            return System.Text.Encoding.Default.GetString(obj);//将字节数组转换成字符串
        }
        /// <summary>
        /// 设置session
        /// </summary>
        /// <param name="key">session的key</param>
        /// <param name="obj">要调置的对像</param>
        private static void  SetSession(string key,object obj)
        {
            //System.Text.Encoding.Default.GetBytes(obj.ToString()) 将字符串转换成字节

            _httpContextAccessor.HttpContext.Session.Set(key, System.Text.Encoding.Default.GetBytes(obj.ToString()));
        }

        /// <summary>
        /// 登录名
        /// </summary>
        public static string LoginName
        {
            get { return _httpContextAccessor.HttpContext.Request.Cookies["LoginName"].ToString(); }
            set { _httpContextAccessor.HttpContext.Response.Cookies.Append("LoginName", value,new CookieOptions() {  Expires=System.DateTime.Now.AddDays(1)}); }
        }
        ///// <summary>
        ///// 用户名称
        ///// </summary>
        //public static string UserName
        //{
        //    get { return System.Web.HttpContext.Current.Session["UserName"].ToString(); }
        //    set { System.Web.HttpContext.Current.Session["UserName"] = value; }
        //}

        ///// <summary>
        ///// 是否系统管理员
        ///// </summary>
        //public static bool IsAdmin
        //{
        //    get { return bool.Parse(System.Web.HttpContext.Current.Session["IsAdmin"].ToString()); }
        //    set { System.Web.HttpContext.Current.Session["IsAdmin"] = value; }
        //}
    }
}
