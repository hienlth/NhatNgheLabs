using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PassDataFromControllerToView.Models;

namespace PassDataFromControllerToView.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Nhất Nghệ";
            ViewBag.SoDienThoai = 2839322734;
            ViewBag.DiaChi = "105 Bà Huyện Thanh Quan";
            ViewBag.NgayThanhLap = new DateTime(2003, 3, 10);
            return View();
        }

        public IActionResult ChiTiet()
        {
            HangHoa hh = new HangHoa
            {
                MaHH = 1,
                TenHH = "Samsung Note 9",
                DonGia = 22490000,
                SoLuong = 23,
                Hinh = "samsung-note9.jpg"
            };
            ViewBag.HangHoa = hh;
            return View();
        }
        public IActionResult DanhSach()
        {
            List<HangHoa> danhSach = new List<HangHoa>() {
                new HangHoa
                {
                    MaHH = 1, TenHH = "Samsung Note 9 128GB",
                    DonGia = 22490000, SoLuong = 23,
                    Hinh = "samsung-note9.jpg"
                },
                new HangHoa
                {
                    MaHH = 2, TenHH = "IPhone X 128GB",
                    DonGia = 23490000, SoLuong = 12,
                    Hinh = "iphonex.jpg"
                },
                new HangHoa
                {
                    MaHH = 3, TenHH = "IPad 2018 Wifi 32GB",
                    DonGia = 9490000, SoLuong = 20,
                    Hinh = "ipad2018.jpg"
                }
            };
            ViewBag.HangHoa = danhSach;
            return View();
        }

        public IActionResult ReadJson()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("myappsettings.json");
            var config = builder.Build();
            ViewBag.Message = config["Message"];
            ViewBag.Config1 = config["MyConfigs:Config1"];
            ViewBag.Config2 = config["MyConfigs:Config2"];
            ViewBag.Config3 = config["MyConfigs:Config3"];
            ViewBag.ConnectionString = config.GetConnectionString("DefaultConnection");

            return View();
        }

        public IActionResult DemoSession()
        {
            HttpContext.Session.SetString("message", "Trung tâm Đào tạo CNTT Nhất Nghệ");
            HttpContext.Session.SetInt32("year", 2003);

            HangHoa hh = new HangHoa
            {
                MaHH = 1,
                TenHH = "Samsung Note 9 128GB",
                DonGia = 22490000,
                SoLuong = 23,
                Hinh = "samsung-note9.jpg"
            };
            HttpContext.Session.Set("product", hh);

            return View();
        }
    }
}