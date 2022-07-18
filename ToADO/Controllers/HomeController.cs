using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToADO.Models;

namespace ToADO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TodoDBRepository repo = new TodoDBRepository();
            List<Todos> obj = repo.GetTodos();
            return View(obj);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Todos todo)
        {
            TodoDBRepository repo = new TodoDBRepository();
            if (ModelState.IsValid)
            {
                bool isSuccess = repo.AddTodo(todo);
                if (isSuccess)
                {
                    ViewBag.Message = "Data Added Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            TodoDBRepository repo = new TodoDBRepository();
            var row = repo.GetTodos().Find(model =>  model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id,Todos todo)
        {
            TodoDBRepository repo = new TodoDBRepository();
            if (ModelState.IsValid)
            {
                bool isSuccess = repo.EditTodo(id,todo);
                if (isSuccess)
                {
                    ViewBag.Message = "Data Editted Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            TodoDBRepository repo = new TodoDBRepository();
            var row = repo.DeleteTodo(id);
            return RedirectToAction("Index");
        }

    }
}