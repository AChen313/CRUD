using CRUD.Bll;
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
    }
}