//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OOPS
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPropertyImage
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string ImageTitle { get; set; }
        public int PropertyInfoID { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DateAdded { get; set; }
        public System.DateTime DateModified { get; set; }
    }
}
