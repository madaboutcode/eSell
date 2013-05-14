using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using eSell.Models;

namespace eSell.Drivers
{
    public class ProductDriver:ContentPartDriver<ProductPart>
    {
        protected override string Prefix
        {
            get { return "Product"; }
        }

        protected override DriverResult Display(ProductPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Product",
                () => shapeHelper.Parts_Product(
                    Price : part.Price,
                    Discount : part.Discount));
        }

        //GET
        protected override DriverResult Editor(ProductPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Product_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/Product",
                    Model: part,
                    Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(ProductPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }


}