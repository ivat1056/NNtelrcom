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
    
    public partial class MainPBX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainPBX()
        {
            this.ATC = new HashSet<ATC>();
        }
    
        public int IDPBX { get; set; }
        public Nullable<int> IDpbx_in { get; set; }
        public Nullable<int> IDpbx_out { get; set; }
        public Nullable<int> IDPBXType { get; set; }
        public string SessionID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATC> ATC { get; set; }
        public virtual PBX_In PBX_In { get; set; }
        public virtual PBX_Out PBX_Out { get; set; }
        public virtual PBXType PBXType { get; set; }
    }
}
