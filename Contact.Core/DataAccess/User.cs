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
    
    public partial class User
    {
        public User()
        {
            this.UserRoles = new HashSet<UserRole>();
        }
    
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
