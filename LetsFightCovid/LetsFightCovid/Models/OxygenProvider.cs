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
    
    public partial class OxygenProvider
    {
        public int provider_ID { get; set; }
        public string provider_address { get; set; }
        public string provider_contact { get; set; }
        public int available_stock { get; set; }
        public string price_per_cylinder { get; set; }
    }
}