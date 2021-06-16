using IotOA.Model;
using IotOA.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IotOA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHttpContextAccessor _iHttpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _iHttpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            SessionInfo._httpContextAccessor = _iHttpContextAccessor;
            SessionInfo.UserID = "123";
            string userid = SessionInfo.UserID.ToString();
            //_iHttpContextAccessor.HttpContext.Session.SetString("UserID","456");
            //在当前控制器里获取session
            string userId1 = System.Text.Encoding.Default.GetString(_iHttpContextAccessor.HttpContext.Session.Get("UserID"));
            string userId2 = _iHttpContextAccessor.HttpContext.Session.GetString("UserID");
            SessionInfo.LoginName = "张三";
            string userName = SessionInfo.LoginName;
            string userName1 = _iHttpContextAccessor.HttpContext.Request.Cookies["LoginName"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
