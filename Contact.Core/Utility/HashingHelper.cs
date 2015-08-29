using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
namespace Contact.Core.Utility
{
   public class HashingHelper
    {
       public byte[] HashPassword(string password)
       {
           var hash = System.Text.Encoding.UTF8.GetBytes(password);
           var result = SHA256.Create().ComputeHash(hash);
           return result;
       }
    }
}
