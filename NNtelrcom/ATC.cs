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
    
    public partial class ATC
    {
        public int IDATC { get; set; }
        public Nullable<int> IDMKD { get; set; }
        public string CallID { get; set; }
        public string CallLegID { get; set; }
        public Nullable<int> IDEvent { get; set; }
        public Nullable<int> IDCallTermination { get; set; }
        public string SetupDateTime { get; set; }
        public string ReleaseDateTime { get; set; }
        public string CallDuration { get; set; }
        public string AnswerDateTime { get; set; }
        public string SpeechDuration { get; set; }
        public Nullable<int> FaxDuration { get; set; }
        public Nullable<int> HostPort_A { get; set; }
        public Nullable<int> HostPort_B { get; set; }
        public Nullable<int> IDtype { get; set; }
        public Nullable<int> IDTypeCat { get; set; }
        public Nullable<int> IDEmptyDate { get; set; }
        public Nullable<int> IDPBX { get; set; }
        public Nullable<int> IDrecord_number { get; set; }
        public Nullable<int> IDGateIN { get; set; }
        public Nullable<int> IDGateOUT { get; set; }
        public string SessionID { get; set; }
        public Nullable<int> IDCgPhCdPh { get; set; }
    
        public virtual TypeEstablishFlagPage CallTermination { get; set; }
        public virtual Cat Cat { get; set; }
        public virtual CgPCdPh CgPCdPh { get; set; }
        public virtual Event Event { get; set; }
        public virtual Fax Fax { get; set; }
        public virtual GateIN GateIN { get; set; }
        public virtual GateOut GateOut { get; set; }
        public virtual HostA HostA { get; set; }
        public virtual HostB HostB { get; set; }
        public virtual MainPBX MainPBX { get; set; }
        public virtual MKD_ID MKD_ID { get; set; }
        public virtual RecordNumber RecordNumber { get; set; }
        public virtual Type Type { get; set; }
        public virtual UnusedParameters UnusedParameters { get; set; }
    }
}
