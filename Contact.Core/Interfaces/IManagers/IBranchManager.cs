using Contact.Core.DataAccess;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Interfaces.IManagers
{
   public interface IBranchManager
    {
       Operation CreateBranch(BranchModel model);
       Operation EditBranch(int id, BranchModel model);
       IEnumerable<Branch> GetListOfBranch();
       BranchModel GetByNameAndPhone(string name, string number);
       Operation DeleteBranch(int id);
    }
}
