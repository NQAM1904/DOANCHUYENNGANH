//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class AGENCY_SOCIAL
    {
        public int IDAGENCY_SOCIAL { get; set; }
        public Nullable<int> IDSOCIAL { get; set; }
        public Nullable<int> IDAGENCY { get; set; }
        public string NAME_SOCIAL { get; set; }
    
        public virtual AGENCY AGENCY { get; set; }
        public virtual SOCIAL SOCIAL { get; set; }
    }
}
