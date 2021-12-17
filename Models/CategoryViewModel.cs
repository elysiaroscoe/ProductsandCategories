using System.Collections.Generic;

namespace ProductsandCategories.Models
{
    public class CategoryViewModel
    {
        public Category ThisCategory {get;set;}
        public List<Category> AllCategories{get;set;}
    }
}