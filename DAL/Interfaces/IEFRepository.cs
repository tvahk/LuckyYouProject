using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    // this is the base repository interface for all EF repositories
    public interface IEFRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Get all records in table
        /// </summary>
		List<T> All { get; }

        /// <summary>
        /// Get record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		T GetById(object id);

        /// <summary>
        /// Add record
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete record
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Delete record by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);

        /// <summary>
        /// Save record
        /// </summary>
        void Save();
    }
}