using Domain.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    
    public class Product
    {
        private int productId;
        private string name;
        private string brand;
        private float price;
        private float tva;
        private string category;
        private int quantity;
        private float discount;
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Interaction> Interactions { get; set; }
        public virtual ICollection<Showroom> Showrooms { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }


        public int ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
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

        public string Brand
        {
            get
            {
                return brand;
            }

            set
            {
                brand = value;
            }
        }



        public float Tva
        {
            get
            {
                return tva;
            }

            set
            {
                tva = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public float Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }



        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}
