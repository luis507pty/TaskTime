using PeopleCrud.Entity;
using PeopleCrud.Interfacez;
using PeopleCrud.Models;
using PeopleCrud.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeopleCrud.Controllers
{
    public class TaskController : Controller
    {
        private GeneryRepository<Task> _taskRepository;
        private Answer _answer;
        public TaskController(GeneryRepository<Task> taskRepository, Answer answer)
        {
            _taskRepository = taskRepository;
            _answer = answer;
        }
        public ActionResult Index()
        {
            return View(_taskRepository.GetAll().OrderBy(x=> x.Id).ToList());
        }

        [HttpPost]
        public PartialViewResult GetById([Bind(Include = "id")] int id)
        {
            var tarea = _taskRepository.GetById(id);
            var view = new TaskViewValidation() { Nombre = tarea.Nombre, Descripcion = tarea.Descripcion, id = tarea.Id };
            return PartialView("_Update", view);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Nombre,Descripcion,Id")] TaskViewValidation add)
        {
            if (ModelState.IsValid)
            {
                var create = new Task()  { Nombre = add.Nombre, Descripcion = add.Descripcion };
                var resul = _taskRepository.Create(create); 

                if (resul) {  
                    _answer.IsDone = true;  
                    _answer.mensaje = "Tarea creada";  
                } 
                else { 
                    _answer.IsDone = false; 
                    _answer.mensaje = "Error";  
                }
            }
            else { _answer.IsDone = false; _answer.mensaje = "Datos invilidos"; }

            return Json(_answer);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete([Bind(Include = "id")] int id)
        {
            var result = _taskRepository.Delete(id);
            if (result)
            {
                _answer.IsDone = true;
                _answer.mensaje = "Tarea Eliminada";
            }
            else
            {
                _answer.IsDone = false;
                _answer.mensaje = "Error";
            }

            return Json(_answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Update([Bind(Include = "Nombre,Descripcion,Id")] TaskViewValidation update)
        {

            if (ModelState.IsValid)
            {
                var create = new Task() { Nombre = update.Nombre, Descripcion = update.Descripcion, Id = update.id };
                var result = _taskRepository.Update(create);

                if (result)
                {
                    _answer.IsDone = true;
                    _answer.mensaje = "Tarea actualizada";
                }
                else
                {
                    _answer.IsDone = false;
                    _answer.mensaje = "Error";
                }
            }
            else { _answer.IsDone = false; _answer.mensaje = "Datos invilidos"; }
            

            return Json(_answer);
        }

        public PartialViewResult ViewCreateForm()
        {
            return PartialView("_Create", new TaskViewValidation());
        }
        public PartialViewResult ViewTab()
        {
            return PartialView("_Tabla", _taskRepository.GetAll());
        }
        public PartialViewResult FailViewCreate(TaskViewValidation fail)
        {
            return PartialView("_Create", fail);
        }
        public PartialViewResult FailViewUpdate(TaskViewValidation fail)
        {
            return PartialView("_Update", fail);
        }


    }
}