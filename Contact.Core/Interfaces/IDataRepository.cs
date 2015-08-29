using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Interfaces
{
  public  interface IDataRepository
    {
        IQueryable<T> Get<T>() where T : class;
        void Add<T>(T item) where T : class;
        T GetByID<T>(int id) where T : class;
        void Delete<T>(T item) where T : class;
        Operation SaveChanges();
        IEnumerable<T> Execute<T>(string sql);

        /// <summary>
        /// Executes a Stored Proceedure
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="name">Name of Stored Procedure</param>
        /// <param name="args">Any object whose properties are the parameters for the Proceedure</param>
        /// <returns>Enumerable of Entities</returns>
        IEnumerable<T> Execute<T>(string name, object args);

        /// <summary>
        /// Executes an Arbitrary SQL that does not need return entities.. Useful for CUD commands
        /// </summary>
        /// <param name="sql">SQL Statement</param>
        /// <returns>An operation describing the status of the command</returns>
        void Execute(string sql, object args);

        /// <summary>
        /// Executes an Arbitrary SQL that does not need return entities.. Useful for CUD commands
        /// </summary>
        /// <param name="sql">SQL Statement</param>
        void Execute(string sql);  
    }
}
