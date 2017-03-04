using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RateReview : Review
    {
        
        private int mark;
        public RateReview() : base()
        {

        }
        public int Mark
        {
            get
            {
                return mark;
            }

            set
            {
                mark = value;
            }
        }
        
    }
}
