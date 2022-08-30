using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class MemberController : Controller
    {
        //----------------------會員首頁------------------------
        // GET: Member
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        //---------------------會員登出-------------------------
        // GET: Member/Logout
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // 登出授權
            return RedirectToAction("Login", "Home");
        }

        //---------------------會員狀態頁------------------------
        // GET: Member/MemberState
        [Authorize]
        public ActionResult MemberState()
        {
            Console.WriteLine("YOYOOYOYOYOYOOY");
            string UserId = User.Identity.Name; // 取目前授權帳號
            dbManager dbManager = new dbManager(); // db連線物件
            MemberState memberState = dbManager.GetMemberStateByUserId(UserId); // 取用會員狀態方法
            ViewBag.memberState = memberState; // 將meberState記在viewbag
            return View(memberState); // 跳轉至會員狀態頁
        }

        //---------------------修改帳號-----------------------
        [Authorize]
        public ActionResult EditMemberState(int id)
        {
            dbManager dbmanager = new dbManager();
            MemberState memberState = dbmanager.GetMemberStateById(id); // 找出該筆資料
            return View(memberState); // 傳給view顯示該筆資料
        }
        [HttpPost]
        [Authorize]
        public ActionResult EditMemberState(MemberState memberState)
        {
            if (!ModelState.IsValid)
            {
                return View(memberState);
            }
            else
            {
                dbManager dbManager = new dbManager();
                try
                {
                    dbManager.UpdateMember(memberState); // 修改該筆資料
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                return RedirectToRoute("MemberState"); // 返回會員狀態頁
            }
        }

    }
}