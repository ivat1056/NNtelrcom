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
    
    public partial class Home_photo
    {
        public int ID_Photo { get; set; }
        public int ID_home { get; set; }
        public string path { get; set; }
        public byte[] pathBin { get; set; }
    
        public virtual HomeTa HomeTa { get; set; }
    }
}
