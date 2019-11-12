using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAJAX.Models;
using System.Threading.Tasks;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();

        public ActionResult IndexRazor()
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return View(response.Result.listado);
        }

        public JsonResult GetStudent(string id)
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentModel std)
        {
            //   service.Insert(std);
            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public ActionResult Index()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult UpdateStudent(Student std, int Id)
        {
            std.FechaModificacion = DateTime.Today;
            service.Update(std, Id);
            string message = "SUCCESS";

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }

        [HttpPost]
        public ActionResult DeleteStudent(int Id)
        {
            service.Delete(Id);
            string message = "SUCCESS";

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }*/

    }
}