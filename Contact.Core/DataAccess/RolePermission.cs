//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contact.Core.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class RolePermission
    {
        public int RolePermissionID { get; set; }
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
    
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}