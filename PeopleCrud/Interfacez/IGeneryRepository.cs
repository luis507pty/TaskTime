using PeopleCrud.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCrud.Interfacez
{
    public interface IGeneryRepository<TEntity> where TEntity : class
    {
        //Crud(Operaciones basicas para manipular tablas de mi base de datos)
        List<TEntity> GetAll();
        TEntity GetById(int id);
        bool Create(TEntity modelo);
        bool Delete(int id);
        bool Update(TEntity modelo);
    }
}
