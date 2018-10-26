using DAL;
using DAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REPO.Interfaces;
using REPO;
 
namespace AppUsage.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            using (UnitOfWork work = new UnitOfWork())
            {
                ViewBag.Message = null;
                var postList = new List<Login>();

               
                //{
                //    postList2.
                //};

                //var a = work.LoginRepository.getFirstOrDefault();
                //var ab = work.LoginRepository.listByWhere(x => x.KullaniciAdi == "hasan");
                //if (work.LoginRepository.countByWhere(ok => ok.KullaniciAdi == "hasan" && ok.Sifre == "sahin") > 0)
                //{

                //}
                
                
                    return View(postList);
            }
        }
        [HttpPost]
        public ActionResult SignIn(string Username, string Password, string admin)
        {
            Session["clientid"] = 0;
            using (UnitOfWork work = new UnitOfWork())
            {
                var ab = work.LoginRepository.listByWhere(x => x.KullaniciAdi == Username);
                if (work.LoginRepository.countByWhere(ok => ok.KullaniciAdi == Username && ok.Sifre == Password) > 0)
                {
                    if(admin=="")
                    {

                        Session["serverid"] = ab[0].ID; Session["anayetki"] = 0;
                        ViewBag.login = true; Session["login"] = Username; Session["hata"] = null; Session["hata2"] = null; Session["yetki"] = "User "; @Session["renk"] = "blue";
                    }
                   else
                    {
                        if (work.LoginRepository.countByWhere(ok => ok.AdminYetki == admin) > 0)
                        {
                            
                            ViewBag.login = true; Session["login"] = Username; Session["hata"] = null; @Session["renk"] = "red";
                            Session["yetki"] = "Admin ";
                            Session["anayetki"] = 1; Session["serverid"] = ab[0].ID;
                            Session["hata2"] = null;
                        }
                        else
                        {
                            Session["yetki2"] = 0; Session["clientid"] = ab[0].ID;
                            Session["hata"] = null;
                            Session["hata2"] = "1";
                        }
                    }
                   
                }
                else
                {
                    Session["clientid"] = 0; Session["yetki2"] = 0;
                    Session["hata2"] = null;
                    Session["hata"] = "1";
                }

            }
            return RedirectToAction("HomePage");

        }
        public ActionResult SignOut()
        {
            Session.Clear();

            // TODO : Redirect Url after SignOut
            return RedirectToAction("HomePage");
        }
        public ActionResult HomePage()
        {
            
            ViewBag.kullanici = ""; 
            return View();
        }
        public ActionResult iletisim()
        {
            
            return View();
        }
        public ActionResult about()
        {

            return View();
        }

    }
}