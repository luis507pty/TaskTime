using PeopleCrud.Interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleCrud.Models
{
    public class Answer : IAnswer
    {
        public bool IsDone { get; set; }
        public string mensaje { get; set; }
        public object valor { get; set; }
    }
}