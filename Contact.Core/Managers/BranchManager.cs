using Contact.Core.DataAccess;
using Contact.Core.Interfaces.IManagers;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Managers
{
    public class BranchManager : IBranchManager
    {

        private readonly DataRepository _db;
        public BranchManager(DataRepository db)
        {
            _db = db;
        }
        public Operation CreateBranch(Models.BranchModel model)
        {
         
                var operation = new Operation();
                try
                {
                    var newbranch = new Branch
                    {
                        EmailAddress = model.EmailAddress,
                        PhoneNumber = model.PhoneNumber,
                        BranchAddress = model.BranchAddress,
                        BranchName = model.BranchName
                    };
                    _db.Add(newbranch);
                    _db.SaveChanges();
            }
            catch (Exception)
            {  
                throw;
            }
           return operation;
        }

        public Operation EditBranch(int id, BranchModel model)
        {
            var operation = new Operation();
            try
            {
                var branch = _db.Get<Branch>().FirstOrDefault(x => x.BranchID==id);
                if (branch != null)
                {
                    branch.BranchName = model.BranchName;
                    branch.EmailAddress = model.EmailAddress;
                    branch.PhoneNumber = model.PhoneNumber;
                    branch.BranchAddress = model.BranchAddress;
                    _db.Update(branch);
                    _db.SaveChanges();
                    operation.Status = StatusCode.Succeeded;
                }
                else
                {
                    operation.Status = StatusCode.Failed;
                    operation.Message = "Branch Do Not Exist to Update";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return operation;
        }

        public IEnumerable<Branch> GetListOfBranch()
        {
            var branches = _db.Get<Branch>().ToList();
            return branches;
        }
        public Models.BranchModel GetByNameAndPhone(string name, string number)
        {
            var branch = _db.Get<Branch>().FirstOrDefault(x => x.BranchName == name || x.PhoneNumber == number);
            return new BranchModel(branch);
        }
        public Branch GetByID(int id)
        {
            var branch = _db.GetByID<Branch>(id);
            return branch;
        }
        public Operation DeleteBranch(int id)
        {
            var operation = new Operation();
            try
            {
                var branch = _db.GetByID<Branch>(id);
                if (branch != null)
                {
                    _db.Delete(branch);
                    operation.Status = StatusCode.Succeeded;
                }
            }
            catch (Exception ex)
            {
                operation.Status = StatusCode.Failed;
                while (ex.InnerException != null) ex = ex.InnerException;
                {
                    operation.Message = ex.Message;
                }
            }
            return operation;
        }
    }
}
