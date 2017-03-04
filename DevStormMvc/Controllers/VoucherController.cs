using DevStormMvc.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Controllers
{
    public class VoucherController : Controller
    {
        // GET: Voucher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Voucher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Voucher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voucher/Create
        [HttpPost]
        public ActionResult Create(VoucherModel VM)
        {
            Voucher v = new Voucher
            {
                Amount = VM.amount,
                Description=VM.description,
                Name=VM.name,
                Reference=VM.reference,
                VoucherId=VM.voucherId,
                Showroomer=VM.showroomer
                

            };
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Voucher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Voucher/Edit/5
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

        // GET: Voucher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Voucher/Delete/5
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
