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
    
    public partial class thesis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public thesis()
        {
            this.keyword = new HashSet<keyword>();
            this.supervisors1 = new HashSet<supervisors>();
        }
    
        public int thesis_id { get; set; }
        public string title { get; set; }
        public string @abstract { get; set; }
        public Nullable<int> author_id { get; set; }
        public Nullable<int> university_id { get; set; }
        public Nullable<int> institute_id { get; set; }
        public Nullable<int> topic_id { get; set; }
        public string type { get; set; }
        public Nullable<int> year { get; set; }
        public string pages { get; set; }
        public Nullable<int> language_id { get; set; }
        public string submission_date { get; set; }
        public Nullable<int> supervisor_id { get; set; }
    
        public virtual author author { get; set; }
        public virtual institute institute { get; set; }
        public virtual language language { get; set; }
        public virtual supervisors supervisors { get; set; }
        public virtual topics topics { get; set; }
        public virtual university university { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<keyword> keyword { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<supervisors> supervisors1 { get; set; }
    }
}