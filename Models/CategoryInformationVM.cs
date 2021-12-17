using System.Collections.Generic;

namespace ProductsandCategories.Models
{
    public class CategoryInformationVM
    {
        public Category ThisCategory {get;set;}
        public List<Product> UnassignedProducts {get;set;}
        public Association Connection {get;set;}
    }
}