using PeopleCrud.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCrud.Interfacez
{
    public interface IRepository<T>
    {
        //Crud(Operaciones basicas para manipular tablas de mi base de datos)
        List<T> GetAll();
        T GetById(int id);
        bool Create(T modelo);
        bool Delete(int id);
        bool Update(T modelo);
    }
}
