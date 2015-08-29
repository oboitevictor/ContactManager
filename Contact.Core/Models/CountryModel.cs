using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
   public class CountryModel:Model
    {
        public int CountryID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EmployeeModel> Employees { get; set; }

       public CountryModel()
        {
            Employees = new List<EmployeeModel>();
        }
       public CountryModel(Country model)
       {
           Map(model);
       }

       private CountryModel Map(Country model)
       {
           this.CountryID = model.CountryID;
           this.Name = model.Name;
           return this;
       }
    }
}
