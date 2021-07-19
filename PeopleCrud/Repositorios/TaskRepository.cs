using PeopleCrud.Entity;
using PeopleCrud.Interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PeopleCrud.Repositorios
{
    public class TaskRepository : IRepository<Task>
    {
        private readonly TaskTimeEntities _Context; 
        public TaskRepository( TaskTimeEntities context)
        {
            _Context = context;
        }
        public List<Task> GetAll()
        {
            return _Context.Task.OrderByDescending(x=>x.Id).ToList();
        }
        public Task GetById(int id)
        { 
            return _Context.Task.Where(x => x.Id == id).FirstOrDefault();
        }
        public bool Update(Task modelo)
        {
            try
            {
                var old = _Context.Task.Find(modelo.Id);
                old.Nombre = modelo.Nombre;
                old.Descripcion = modelo.Descripcion;
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
               var delete = _Context.Task.Find(id);
                _Context.Task.Remove(delete);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Create(Task modelo)
        {
            try
            {
               _Context.Task.Add(modelo);
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