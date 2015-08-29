using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
   public class StateModel:Model
    {
        public int StateID { get; set; }
        public string Name { get; set; }

        public virtual EmployeeModel Employee { get; set; }

       public StateModel()
        {
            Employee = new EmployeeModel();
        }
       public StateModel(State model)
       {
           Map(model);
       }

       private StateModel Map(State model)
       {
           this.StateID= model.StateID;
           this.Name= model.Name;
           return this;
       }
    }
}
