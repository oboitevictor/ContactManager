using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact.Web.Models
{
    public class Department:DepartmentModel
    {
        public override string Name {get; set;}
        public override string Description { get; set; }
     public Department()
        {

        }
    public Department(DepartmentModel model)
    {
        this.Name = model.Name;
        this.Description = model.Description;
    }
  }
}