//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NNtelrcom
{
    using System;
    using System.Collections.Generic;
    
    public partial class UnusedParameters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnusedParameters()
        {
            this.ATC = new HashSet<ATC>();
        }
    
        public int IDEmptyDate { get; set; }
        public string PN_List { get; set; }
        public string OgPN_root { get; set; }
        public string RdPN_root { get; set; }
        public string OgPN_ext { get; set; }
        public string RdPN_ext { get; set; }
        public string SessionID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATC> ATC { get; set; }
    }
}
