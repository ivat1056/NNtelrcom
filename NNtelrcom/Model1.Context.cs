﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EP3 : DbContext
    {
        public EP3()
            : base("name=EP3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ATC> ATC { get; set; }
        public virtual DbSet<CallTermination> CallTermination { get; set; }
        public virtual DbSet<Cat> Cat { get; set; }
        public virtual DbSet<CgPCdPh> CgPCdPh { get; set; }
        public virtual DbSet<Employ> Employ { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Fax> Fax { get; set; }
        public virtual DbSet<Floor> Floor { get; set; }
        public virtual DbSet<GateIN> GateIN { get; set; }
        public virtual DbSet<GateOut> GateOut { get; set; }
        public virtual DbSet<Home_photo> Home_photo { get; set; }
        public virtual DbSet<HomeTa> HomeTa { get; set; }
        public virtual DbSet<HostA> HostA { get; set; }
        public virtual DbSet<HostB> HostB { get; set; }
        public virtual DbSet<MainPBX> MainPBX { get; set; }
        public virtual DbSet<MKD_ID> MKD_ID { get; set; }
        public virtual DbSet<OrganInfo> OrganInfo { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<PBX_In> PBX_In { get; set; }
        public virtual DbSet<PBX_Out> PBX_Out { get; set; }
        public virtual DbSet<PBXType> PBXType { get; set; }
        public virtual DbSet<PhonesOrganizations> PhonesOrganizations { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Q931Cause> Q931Cause { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<RecordNumber> RecordNumber { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<TypeCause> TypeCause { get; set; }
        public virtual DbSet<TypeEstablishFlag> TypeEstablishFlag { get; set; }
        public virtual DbSet<TypeRate> TypeRate { get; set; }
        public virtual DbSet<TypeReleaseDirection> TypeReleaseDirection { get; set; }
        public virtual DbSet<UnusedParameters> UnusedParameters { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
