//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Survey_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answer
    {
        public int Id { get; set; }
        public string PersonCode { get; set; }
        public string PersonName { get; set; }
        public string UserCode { get; set; }
        public string Score { get; set; }
        public string IsComplete { get; set; }
        public Nullable<System.DateTime> CreateDte { get; set; }
        public string CreateBy { get; set; }
    }
}
