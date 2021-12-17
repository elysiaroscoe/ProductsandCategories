using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProductsandCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get;set;}



        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "Please enter the category's name")]
        public string CategoryName {get;set;}
    

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //Navigation Property for Many to Many Table
        public List<Association> Associations {get;set;}
    }
}