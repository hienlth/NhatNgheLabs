using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PassDataFromControllerToView.Models;

namespace PassDataFromControllerToView.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //Kiểm tra xem mã người dùng có hợp lệ không?
            if (model.MaKH.Length > 5 && model.MatKhau.Length > 5)
            {
                KhachHang kh = new KhachHang
                {
                    MaKh = model.MaKH,
                    HoTen = model.MaKH,
                    MatKhau = model.MatKhau
                };
                HttpContext.Session.Set("KhachHang", kh);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Loi = "Sai thông tin đăng nhập";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("KhachHang");
            return RedirectToAction("Index", "Home");
        }
    }
}