using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Day_1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_Day_1
{
    public class customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Customer Name is not Empty")]
        [Display(Name ="Customer Name")]
        [StringLength(50)]
        [Column(TypeName ="varchar")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage ="Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        public DateTime? DateofBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(50)]
        public string Gender { get; set; }
        [Required(ErrorMessage ="City cannot be empty")]
        public string City { get; set; }

   
        public MemberShipType MemberShipType { get; set; }

        
        [Required]
        [Display(Name ="MemberShip Type")]
        public int? MemberShipTypeId { get; set; }
    }
}