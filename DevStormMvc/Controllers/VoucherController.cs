using DevStormMvc.helper;
using DevStormMvc.Models;
using Domain.Entities;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Controllers
{
    public class VoucherController : Controller
    {
        ServiceVoucher serviceVoucher = new ServiceVoucher();
        ServiceShowroomer serviceShowroomer = new ServiceShowroomer();
        // GET: Voucher
        public ActionResult Index()
        {
            List<VoucherModel> vm = new List<VoucherModel>();
            var listVouchers = serviceVoucher.GetAll();

            foreach (var item in listVouchers)
            {

                vm.Add(new VoucherModel
                {

                    voucherId = item.VoucherId,
                    name = item.Name,
                    description = item.Description,
                    amount = item.Amount,
                    reference = item.Reference,
                    userId = item.UserId,
                    showroomer = item.Showroomer




                });
            }

            return View(vm);

        }

        // GET: Voucher/Details/5
        public ActionResult Details(int id)
        {
            Voucher v = (Voucher)serviceVoucher.GetById(id);
            VoucherModel VM = new VoucherModel
            {
                amount = v.Amount,
                description = v.Description,
                name = v.Name,
                reference = v.Reference,
                voucherId = v.VoucherId,
                userId = v.UserId,
                showroomer = v.Showroomer



            };
            return View(VM);
        }

        // GET: Voucher/Create
        public ActionResult Create()
        {
            IEnumerable<Showroomer> showroomers = serviceShowroomer.GetAll();

            VoucherModel pvm = new VoucherModel();

            pvm.ListShowroomers = showroomers.ToSelectShowroomer();

            return View(pvm);
        }

        // POST: Voucher/Create
        [HttpPost]
        public ActionResult Create(VoucherModel VM)
        {
            Voucher v = new Voucher
            {
                Amount = VM.amount,
                Description = VM.description,
                Name = VM.name,
                Reference = VM.reference,
                VoucherId = VM.voucherId,

                UserId = VM.userId



            };
            try
            {
                serviceVoucher.Add(v);
                serviceVoucher.Commit();

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
            Voucher v = (Voucher)serviceVoucher.GetById(id);
            IEnumerable<Showroomer> showroomers = serviceShowroomer.GetAll();

            VoucherModel pvm = new VoucherModel();

            VoucherModel VM = new VoucherModel
            {
                amount = v.Amount,
                description = v.Description,
                name = v.Name,
                reference = v.Reference,
                voucherId = v.VoucherId,
                userId = v.UserId,
                ListShowroomers = showroomers.ToSelectShowroomer()


            };

            return View(VM);
        }

        // POST: Voucher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VoucherModel VM)
        {
            try
            {
                Voucher c = (Voucher)serviceVoucher.GetById(id);
                c.Name = VM.name;
                c.Reference = VM.reference;
                c.Amount = VM.amount;
                c.Description = VM.description;
                c.UserId = VM.userId;

                serviceVoucher.Update(c);
                serviceVoucher.Commit();

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
            Voucher v = (Voucher)serviceVoucher.GetById(id);
            VoucherModel VM = new VoucherModel
            {
                amount = v.Amount,
                description = v.Description,
                name = v.Name,
                reference = v.Reference,
                voucherId = v.VoucherId,
                userId = v.UserId


            };



            return View(VM);
        }

        // POST: Voucher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Voucher c = (Voucher)serviceVoucher.GetById(id);
                serviceVoucher.Delete(c);
                serviceVoucher.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
