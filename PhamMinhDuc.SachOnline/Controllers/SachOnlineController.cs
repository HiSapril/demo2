using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhamMinhDuc.SachOnline.Models;

namespace PhamMinhDuc.SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        // Add this line to define the 'data' context
        private SachOnlineEntities data = new SachOnlineEntities();

        // GET: SachOnline
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }

        // GET: SachOnline
        public ActionResult Index()
        {
            //Lay 6 quyen sach moi
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }
        private List<SACH> LaySachBanNhieu(int count)
        {
            return data.SACHes.OrderByDescending(a => a.SoLuongBan).Take(count).ToList();
        }
        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = LaySachBanNhieu(6);
            return PartialView(listSachBanNhieu);
        }
        public ActionResult NavPartial()
        {
            return PartialView();
        }
        public ActionResult SliderPartial()
        {
            return PartialView();
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNXB = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(listNXB);
        }
        public ActionResult FooterPartial()
        {
            return PartialView();
        }

    }
}