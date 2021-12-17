using System.Collections.Generic;

namespace ProductsandCategories.Models
{
    public class ProductInformationVM
    {
        public Product ThisProduct {get;set;}
        public List<Category> UnassignedCategories{get;set;}
        public Association Connection {get;set;}
    }
}