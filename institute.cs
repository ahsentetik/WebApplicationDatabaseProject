//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationDatabaseProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class institute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public institute()
        {
            this.thesis = new HashSet<thesis>();
        }
    
        public int institute_id { get; set; }
        public string institute_name { get; set; }
        public Nullable<int> university_id { get; set; }
    
        public virtual university university { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<thesis> thesis { get; set; }
    }
}
