using CRUD.Bll;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            var result = EmpService.GetAllEmp();
            if (result.Result == "1")
            {
                var model = result.ReturnList;
                return View(model);
            }
            return View();
        }


        public ActionResult Create(Emp model)
        {
            var result = EmpService.InsertUser(model);
            if (result.Result == "1")
            {
                TempData["AlertMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            ViewData["ReturnMsg"] = result.Message;
            return View(model);
        }

        public ActionResult Edit(string no)
        {

            var result = EmpService.GetUser(no);

            if (result.Result == "1")
            {
                var model = result.ReturnList;
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Emp model)
        {

            var result = EmpService.UpdateUser(model);

            if (result.Result == "1")
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(string no)
        {

            var result = EmpService.GetUser(no);

            if (result.Result == "1")
            {
                var model = result.ReturnList;
                return View(model);
            }
            return View();
        }

        public ActionResult Delete(string no)
        {

            var result = EmpService.GetUser(no);

            if (result.Result == "1")
            {
                var model = result.ReturnList;
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Emp model)
        {
            var result = EmpService.DeleteUser(model.No);

            if (result.Result == "1")
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}