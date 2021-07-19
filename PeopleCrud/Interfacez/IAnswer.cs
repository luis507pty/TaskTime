using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCrud.Interfacez
{
    public interface IAnswer
    { 
        bool IsDone { get; set; }
        string mensaje { get; set; }
        object valor { get; set; }
    }
}
