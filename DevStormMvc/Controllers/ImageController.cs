using DevStormMvc.Models;
using Domain.Entities;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Controllers
{
    public class ImageController : Controller
    {
        ServiceImage serviceImage = new ServiceImage();
        ServiceProduct serviceProduct = new ServiceProduct();
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        // GET: Image/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [HttpPost]
        public Image Create(ProductModel pM , HttpPostedFileBase file,int idProduct)
        {
            Image img = new Image { };
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/Content/uploads"), guid + fileName);
                file.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = "~/Content/uploads/" + newpath;

                //IM.url = imagepath;
                //IM.name = fileName;
                 img = new Image
                {

                    Name = fileName,
                    Url = pM.ImageUrl,
                    ProductId = idProduct

                };
               

            }


             
            
                //TempData["Success"] = "Upload successful";


               return img ;
            
            
        }

        // GET: Image/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Image/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Image/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
