using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{
    public class Operation
    {
        public StatusCode Status { get; set; }
        public string Message { get; set; }

        public Operation Catch(Exception ex)
        {
            //Get Innermost Exception
            while (ex.InnerException != null) ex = ex.InnerException;
            Message = ex.Message;
            Status = StatusCode.Failed;
            return this;
        }
    }

    public class Operation<T> : Operation
    {
        public T Result { get; set; }
    }

    public enum StatusCode { Failed, Succeeded }
}
