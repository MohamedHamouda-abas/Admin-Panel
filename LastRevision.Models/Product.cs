using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastRevision.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(500)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required, MaxLength(500)]
        public string ISBN { get; set; }
        [Required,MaxLength(500)]
        public string Author { get; set; }
        [Required,Range(1,255)]
        public Double Price { get; set; }
        [ValidateNever]
        public string ImageUrl {  get; set; }

        //How To Add The CategoryModel In it
        //First Add The FoiginKey
        public int CategoryId { get; set; }
        //Add The Navigation Prop To Relate The FoiginKey
        //Put The dataAnotation To Know the ForiginnKey
        [ForeignKey(nameof(CategoryId))]
        [ValidateNever]
        public Category Category { get; set; }
    }
}
