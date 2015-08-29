using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{
    public class Operation
    {
<<<<<<< HEAD
        public virtual string Message { get; set; }
        public StatusCode Status { get; set; }

        public static Operation Create(Action<Operation> process)
        {
            var operation = new Operation();
            try
            {
                operation.Status = StatusCode.Succeeded;
                process(operation);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                operation.Status = StatusCode.Failed;
                operation.Message = ex.Message;
            }
            return operation;
        }

        public static async Task<Operation> Run(Func<Operation, Task> process)
        {
            var operation = new Operation();
            try
            {
                operation.Status = StatusCode.Succeeded;
                await process(operation);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                operation.Status = StatusCode.Failed;
                operation.Message = ex.Message;
            }
            return operation;
=======
        public StatusCode Status { get; set; }
        public string Message { get; set; }

        public Operation Catch(Exception ex)
        {
            //Get Innermost Exception
            while (ex.InnerException != null) ex = ex.InnerException;
            Message = ex.Message;
            Status = StatusCode.Failed;
            return this;
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
        }
    }

    public class Operation<T> : Operation
    {
        public T Result { get; set; }
<<<<<<< HEAD
        public static Operation<T> Create(Func<Operation<T>, T> process)
        {
            var operation = new Operation<T>();
            try
            {
                operation.Status = StatusCode.Succeeded;
                operation.Result = process(operation);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                operation.Status = StatusCode.Failed;
                operation.Message = ex.Message;
            }
            return operation;
        }

        public static async Task<Operation<T>> Run(Func<Operation<T>, Task<T>> process)
        {
            var operation = new Operation<T>();
            try
            {
                operation.Status = StatusCode.Succeeded;
                operation.Result = await process(operation);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                operation.Status = StatusCode.Failed;
                operation.Message = ex.Message;
            }
            return operation;
        }
    }
=======
    }

>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
    public enum StatusCode { Failed, Succeeded }
}
