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
    
    public partial class TypeEstablishFlagPage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeEstablishFlagPage()
        {
            this.ATC = new HashSet<ATC>();
        }
    
        public int IDCallTermination { get; set; }
        public Nullable<int> IDTypeEstablishFlag { get; set; }
        public Nullable<int> IDTypeReleaseDirection { get; set; }
        public Nullable<int> IDQ931Cause { get; set; }
        public Nullable<int> IDCause { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATC> ATC { get; set; }
        public virtual Q931Cause Q931Cause { get; set; }
        public virtual TypeCause TypeCause { get; set; }
        public virtual TypeEstablishFlag TypeEstablishFlag { get; set; }
        public virtual TypeReleaseDirection TypeReleaseDirection { get; set; }
    }
}
