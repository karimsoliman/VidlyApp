﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        [Display(Name = "Date of Birth")]
        [Min18YearsValidation]
        public DateTime? Birthdate { get; set; }
        public MemberShipType MemberShipType { get; set; }
        [Required]
        [Display(Name="Membership Type")]
        public int MemberShipTypeId { get; set; }
    }
}