//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LetsFightCovid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AdminMember
    {
        public int admin_ID { get; set; }

        [Required(ErrorMessage ="This field is Required")]
        [Display(Name="Admin Username")]
        public string admin_userName { get; set; }
        public string admin_full_name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Password")]
        public string passwords { get; set; }
    }
}
