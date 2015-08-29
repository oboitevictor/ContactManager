using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{
    public class Operation
    {
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
        }
    }

    public class Operation<T> : Operation
    {
        public T Result { get; set; }
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
    public enum StatusCode { Failed, Succeeded }
}
