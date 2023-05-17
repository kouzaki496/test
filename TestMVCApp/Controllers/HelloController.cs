using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestMVCApp.Controllers
{
    public class HelloController : Controller
    {
        public List<string> list;

        public HelloController() 
        {
            list = new List<string>();
            list.Add("Japan");
            list.Add("USA");
            list.Add("UK");

        }

        [Route("Hello/{id?}/{name?}")]
        public IActionResult Index(int id, string name)
        {
            ViewData["Hoge"] = "hello!!";
            ViewData["message"] = "id = " + id + ", name = " + name;
            return View();
        }

        [HttpPost]
        public IActionResult Form()
        {
            string[] res = (string[])Request.Form["list"];
            string msg = "※";
            foreach(var item in res)
            {
                msg += "「" + item + "」";
            }

            ViewData["message"] = msg + " selected.";
            ViewData["list"] = Request.Form["list"];
            ViewData["listdata"] = list;
            return View("Index");
        }
    }

}
