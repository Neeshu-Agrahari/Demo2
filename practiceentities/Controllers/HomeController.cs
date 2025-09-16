using practiceentities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practiceentities.Controllers
{
    public class HomeController : Controller
    {
        adoonlyEntities1 db = new adoonlyEntities1();
        // GET: Home
        // neeshu
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(add_tbl t)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["profile"];
                t.profile = file.FileName;
                file.SaveAs(Server.MapPath("/Content/images/" + file.FileName.ToString()));
                t.regdate = DateTime.Now.ToString();
                db.add_tbl.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('record save')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('record not save')</script>");
            }
            return View();

        }

        public ActionResult Display()
        {

            List<add_tbl> s = null;
           s=db.add_tbl.ToList();
            return View(s);
        }



        }
}