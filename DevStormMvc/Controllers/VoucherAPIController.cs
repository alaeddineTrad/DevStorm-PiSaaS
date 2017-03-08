using DevStormMvc.Models;
using Domain.Entities;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevStormMvc.Controllers
{
    public class VoucherAPIController : ApiController
    {
        ServiceVoucher serviceVoucher = new ServiceVoucher();
        // GET: api/VoucherAPI
        public IEnumerable<VoucherModel> Get()
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
                    
                });
            }

            return vm;
        }

        // GET: api/VoucherAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VoucherAPI
        public IEnumerable<VoucherModel> Post(float amount,string description,string name,string reference,int userId)
        {
            Voucher v = new Voucher
            {
                Amount = amount,
                Description = description,
                Name = name,
                Reference = reference,
                UserId = userId

            };
            serviceVoucher.Add(v);
            serviceVoucher.Commit();
            VoucherAPIController vvv = new VoucherAPIController();
            return vvv.Get();
        }

        // PUT: api/VoucherAPI/5
        public IEnumerable<VoucherModel> Put(int id,float amount, string description, 
            string name, string reference, int userId)
        {
            Voucher v = (Voucher)serviceVoucher.GetById(id);
            v.Amount = amount;
            v.Description = description;
            v.Name = name;
            v.Reference = reference;
            v.UserId = userId;
            serviceVoucher.Commit();
            VoucherAPIController vvv = new VoucherAPIController();
            return vvv.Get();
        }

        // DELETE: api/VoucherAPI/5
        public IEnumerable<VoucherModel> Delete(int id)
        {
            serviceVoucher.Delete(serviceVoucher.GetById(id));
            serviceVoucher.Commit();
            VoucherAPIController vvv = new VoucherAPIController();
            return vvv.Get();
        }
    }
}
