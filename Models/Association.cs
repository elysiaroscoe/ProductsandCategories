using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace ProductsandCategories.Models
{
    public class Association
    {
        [Key]
        public int AssociationId {get;set;}



        //Foreign Key and Navigation Property for Product
        // [ForeignKey("ProductinCategory")]
        public int ProductId {get;set;}
        [Display(Name = "Product: ")]
        public Product Product {get;set;}



        //Foreign Key and Navigation Property for Category
        // [ForeignKey("CategoryofProduct")]
        public int CategoryId {get;set;}
        [Display(Name = "Category: ")]
        public Category Category {get;set;}




        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}