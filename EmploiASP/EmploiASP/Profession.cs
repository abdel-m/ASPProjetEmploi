//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmploiASP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profession
    {
        public Profession()
        {
            this.Contrat = new HashSet<Contrat>();
            this.TraductionProfession = new HashSet<TraductionProfession>();
        }
    
        public string codeAlphabetique { get; set; }
    
        public virtual ICollection<Contrat> Contrat { get; set; }
        public virtual ICollection<TraductionProfession> TraductionProfession { get; set; }
    }
}