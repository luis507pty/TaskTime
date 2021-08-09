using PeopleCrud.Entity;
using PeopleCrud.Interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PeopleCrud.Repositorios
{
    public class GenericRepository<TEntity>: IRepository<TEntity> where TEntity : class 
    {
        private readonly MyTask _Context; 
        public GenericRepository( MyTask context)
        {
            _Context = context;
        }
        public List<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }
        public TEntity GetById(int id)
        {
            return _Context.Set<TEntity>().Find(id);
        }
        public bool Update(TEntity modelo)
        {
            try
            {
              _Context.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           

        }
        public bool Delete(int id)
        {
            try
            {
                var delete = GetById(id);
                _Context.Set<TEntity>().Remove(delete);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Create(TEntity modelo)
        {
            try
            {
               _Context.Set<TEntity>().Add(modelo);
               _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}