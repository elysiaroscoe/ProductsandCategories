using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProductsandCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}



        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "Please enter the product's name")]
        public string ProductName {get;set;}



        [Display(Name = "Description: ")]
        [Required(ErrorMessage = "Please enter the product's description")]
        public string Description {get;set;}



        [Display(Name = "Price: $")]
        [Required(ErrorMessage = "Please enter the product's price")]
        public decimal Price {get;set;}



        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //Navigation Property for Many to Many Table
        public List<Association> Associations {get;set;}
    }
}