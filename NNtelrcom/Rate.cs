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
    
    public partial class Rate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rate()
        {
            this.PhonesOrganizations = new HashSet<PhonesOrganizations>();
        }
    
        public int IDRate { get; set; }
        public string Name { get; set; }
        public Nullable<int> IDTyprRate { get; set; }
        public string Cost { get; set; }
        public string Direction { get; set; }
        public string NumberOfMinutes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhonesOrganizations> PhonesOrganizations { get; set; }
        public virtual TypeRate TypeRate { get; set; }
    }
}
