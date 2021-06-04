using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public abstract class RepositoryBase<T>:IRepositoryBase<T> where T:class
    {
        protected RepositorySQL _RepositorySQL { get; set; }
        #region Inyection Dependencie
        public RepositoryBase(RepositorySQL inyeccion)
        {
            _RepositorySQL = inyeccion;
        }

        //public IQueryable<T> FindAll(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Create(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(T entity)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion


    }

}
