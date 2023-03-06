using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisLabel.Repository
{
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// READ.
        /// </summary>
        /// <param name="id">key id.</param>
        /// <returns>return the instance.</returns>
        T GetOne(int id);

        /// <summary>
        /// Creates an item in DB.
        /// </summary>
        /// <param name="item">instance.</param>
        void Create(T item);

        /// <summary>
        /// Delete item.
        /// </summary>
        /// <param name="id">key id.</param>
        void Delete(T Entity);

        /// <summary>
        /// Updates an item.
        /// </summary>
        /// <param name="id">kkey id.</param>
        /// <param name="param">paramaters, it is different for every class.</param>
        void Update(T entity);

        /// <summary>
        /// Gets The whole table.
        /// </summary>
        /// <returns>List with every object.</returns>
        List<T> GetTable();
    }
}
