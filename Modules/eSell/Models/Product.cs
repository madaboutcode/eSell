using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace eSell.Models
{
    public class ProductPartRecord : ContentPartRecord
    {
        public virtual float Price { get; set; }
        public virtual float Discount { get; set; }
    }

    public class ProductPart : ContentPart<ProductPartRecord>
    {
        [Required]
        public float Price
        {
            get { return Record.Price; }
            set { Record.Price = value; }
        }

        public float Discount
        {
            get { return Record.Discount; }
            set { Record.Discount = value; }
        }
    }
}