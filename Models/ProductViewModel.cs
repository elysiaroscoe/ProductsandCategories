using System.Collections.Generic;

namespace ProductsandCategories.Models
{
    public class ProductViewModel
    {
        public Product ThisProduct {get;set;}
        public List<Product> AllProducts{get;set;}
    }
}