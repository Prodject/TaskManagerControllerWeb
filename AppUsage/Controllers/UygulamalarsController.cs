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
    public class UygulamalarsController : Controller
    {

        // GET: Uygulamalars
        public ActionResult Index()
        {
            if (Session["login"] != null)
            {
                int clientid = Convert.ToInt16(Session["serverid"]);
                @Session["yetki0"] = 0; @Session["client1"] = 0;
                @Session["yetki1"] = 0; @Session["client3"] = 0;
                @Session["yetki2"] = 0; @Session["client4"] = 0;
                @Session["yetki3"] = 0; @Session["client5"] = 0;
                @Session["yetki4"] = 0; @Session["client2"] = 0;
                @Session["yetki5"] = 0;
                using (UnitOfWork work = new UnitOfWork())
                {
                    ViewBag.Message = null;
                    var postList = new List<Uygulamalar>();

                    List<SelectListItem> uygulamalistesi = new SelectList("").ToList();
                    { };
                    List<SelectListItem> serverlistesi = new SelectList("").ToList();
                    { };

                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == false).OrderByDescending(x => x.IsAcik))
                    {

                        postList.Add(item);
                        uygulamalistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi, Value = item.UygulamaAdi }));

                    }
                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == true).OrderByDescending(x => x.IsAcik))
                    {

                        postList.Add(item);
                        serverlistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi }));

                    }
                    var client = work.LoginRepository.listByWhere(x => x.ID == clientid);
                   
                    if (Convert.ToInt16(@Session["anayetki"]) == 1)
                    {
                        @Session["yetki0"] = 1;
                        if (client[0].ClientYetki1 != "")
                        {
                            @Session["yetki1"] = 1; 
                        }
                        if (client[0].ClientYetki2 != "")
                        {
                            @Session["yetki2"] = 1;
                        }
                        if (client[0].ClientYetki3 != "")
                        {
                            @Session["yetki3"] = 1;
                        }
                        if (client[0].ClientYetki4 != "")
                        {
                            @Session["yetki4"] = 1;
                        }
                        if (client[0].ClientYetki5 != "")
                        {
                            @Session["yetki5"] = 1;
                        }
                    }
                    else
                    {
                        @Session["yetki0"] = 0;
                        @Session["yetki1"] = 0;
                        @Session["yetki2"] = 0;
                        @Session["yetki3"] = 0;
                        @Session["yetki4"] = 0;
                        @Session["yetki5"] = 0;
                    }
                    @Session["client0"] = clientid; 
                    @Session["client1"] = client[0].Client1;                 
                    @Session["client2"] = client[0].Client2;
                    @Session["client3"] = client[0].Client3;
                    @Session["client4"] = client[0].Client4;
                    @Session["client5"] = client[0].Client5;
                    ViewData["uygulamalist"] = uygulamalistesi;
                    ViewData["serverlist"] = serverlistesi;


                    return View(postList);
                }
            }
            else
            {
                @Session["client0"] = 0; @Session["yetki0"] = 0;
                @Session["yetki1"] = 0; @Session["client1"] = 0;
                @Session["yetki2"] = 0; @Session["client2"] = 0;
                @Session["yetki3"] = 0; @Session["client3"] = 0;
                @Session["yetki4"] = 0; @Session["client4"] = 0;
                @Session["yetki5"] = 0; @Session["client5"] = 0;
                return View();
            }
        }
        
        public ActionResult UygulamaBaslat(IEnumerable<SelectListItem> list1, string list2, string a = "", string t = "")
        {
            try
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    string l1 = Request.Form["DropDownValue"];
                    string l2 = Request.Form["list2"];
                    a = Request.Form["t1"]; t = Request.Form["t2"]; int clientid = Convert.ToInt16(a);
                    var client = work.LoginRepository.listByWhere(x => x.ID == clientid);
                    client[0].ProgramAdi = l1;
                    client[0].PKomut = l2;
                    client[0].yedek1 = t;
                    work.Save();
                }
            }
            catch (Exception)
            {


            }



            return RedirectToAction("Index");
        }
        public ActionResult KomutGonder(IEnumerable<SelectListItem> list1, string list2, string a = "")
        {
            try
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    string l1 = Request.Form["cmd"];
                    a = Request.Form["t1"]; int clientid = Convert.ToInt16(a);
                    var client = work.LoginRepository.listByWhere(x => x.ID == clientid);
                    client[0].CKomut = l1;
                    work.Save();
                }
            }
            catch (Exception)
            {

            }
          


            return View();
        }
        public PartialViewResult Client(int clientid=0,int yetki=0)
        {
           
            var postList = new List<Uygulamalar>();
            if (clientid!=0)
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    ViewBag.Message = null;


                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == false).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item);
                    }
                    
                }
            }
                return PartialView("_Listele",postList);
        }
        public PartialViewResult Clientas(int clientid = 0, int yetki = 0)
        {

            var postList = new List<Uygulamalar>();
            if (clientid != 0)
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    ViewBag.Message = null;


                   
                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == true).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item);
                    }
                }
            }
            return PartialView("_Listele2", postList);
        }
        public ActionResult Client1()
        {
            int clientid = Convert.ToInt16(@Session["client1"]); int yetki = Convert.ToInt16(@Session["yetki1"]);
            List<SelectListItem> uygulamalistesi = new SelectList("").ToList();
            { };
            List<SelectListItem> serverlistesi = new SelectList("").ToList();
            { };
            var postList = new List<Uygulamalar>();
            if (clientid != 0)
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    ViewBag.Message = null;


                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == false).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item);
                        
                        uygulamalistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi, Value = item.UygulamaAdi }));
                    }
                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == true).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item); serverlistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi }));
                    }
                }
                ViewData["uygulamalist"] = uygulamalistesi;
                ViewData["serverlist"] = serverlistesi;
            }
            return View();
        }
        public ActionResult Client2()
        {
            int clientid = Convert.ToInt16(@Session["client2"]); int yetki = Convert.ToInt16(@Session["yetki2"]);
            List<SelectListItem> uygulamalistesi = new SelectList("").ToList();
            { };
            List<SelectListItem> serverlistesi = new SelectList("").ToList();
            { };
            var postList = new List<Uygulamalar>();
            if (clientid != 0)
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    ViewBag.Message = null;


                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == false).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item);
                        
                        uygulamalistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi, Value = item.UygulamaAdi }));
                    }
                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == true).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item); serverlistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi }));
                    }
                }
                ViewData["uygulamalist"] = uygulamalistesi;
                ViewData["serverlist"] = serverlistesi;
            }
            return View();
        }
        public ActionResult Client3()
        {
            int clientid = Convert.ToInt16(@Session["client3"]); int yetki = Convert.ToInt16(@Session["yetki3"]);
            List<SelectListItem> uygulamalistesi = new SelectList("").ToList();
            { };
            List<SelectListItem> serverlistesi = new SelectList("").ToList();
            { };
            var postList = new List<Uygulamalar>();
            if (clientid != 0)
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    ViewBag.Message = null;


                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == false).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item);
                       
                        uygulamalistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi, Value = item.UygulamaAdi }));
                    }
                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == true).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item); serverlistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi }));
                    }
                }
                ViewData["uygulamalist"] = uygulamalistesi;
                ViewData["serverlist"] = serverlistesi;
            }
            return View();
        }
        public ActionResult Client4()
        {
            int clientid = Convert.ToInt16(@Session["client4"]); int yetki = Convert.ToInt16(@Session["yetki4"]);
            List<SelectListItem> uygulamalistesi = new SelectList("").ToList();
            { };
            List<SelectListItem> serverlistesi = new SelectList("").ToList();
            { };
            var postList = new List<Uygulamalar>();
            if (clientid != 0)
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    ViewBag.Message = null;


                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == false).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item);
                       
                        uygulamalistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi, Value = item.UygulamaAdi }));
                    }
                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == true).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item); serverlistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi }));
                    }
                }
                ViewData["uygulamalist"] = uygulamalistesi;
                ViewData["serverlist"] = serverlistesi;
            }
            return View();
        }
        public ActionResult Client5()
        {
            int clientid = Convert.ToInt16(@Session["client5"]); int yetki = Convert.ToInt16(@Session["yetki5"]);
            List<SelectListItem> uygulamalistesi = new SelectList("").ToList();
            { };
            List<SelectListItem> serverlistesi = new SelectList("").ToList();
            { };
            var postList = new List<Uygulamalar>();
            if (clientid != 0)
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    ViewBag.Message = null;


                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == false).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item);
                        
                        uygulamalistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi, Value = item.UygulamaAdi }));
                    }
                    foreach (var item in work.UygulamalarRepositor.listByWhere(x => x.Userid == clientid && x.IsServis == true).OrderByDescending(x => x.IsAcik))
                    {
                        postList.Add(item); serverlistesi.Insert(0, (new SelectListItem { Text = item.UygulamaAdi }));
                    }
                }
                ViewData["uygulamalist"] = uygulamalistesi;
                ViewData["serverlist"] = serverlistesi;
            }
            return View();
        }

    }
}