using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Voucher
    {
        private int voucherId;
        private string reference;
        private string name;
        private string description;
        private float amount;
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Showroomer Showroomer { get; set; }

        public int VoucherId
        {
            get
            {
                return voucherId;
            }

            set
            {
                voucherId = value;
            }
        }

        public string Reference
        {
            get
            {
                return reference;
            }

            set
            {
                reference = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public float Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }
    }
}
