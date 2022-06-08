using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APPGIROS.Controllers
{
    public class ElementController : Controller
    {
        // GET: Element
        public ActionResult Index()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (Models.GIROSEntities db = new Models.GIROSEntities())
            {

                list = (from d in db.PAIS
                        select new SelectListItem
                        {
                            Value = d.Id_Pais.ToString(),
                            Text = d.Nombre_Pais
                        }).ToList();

            }
            return View(list);
        }

        [HttpGet]
        public JsonResult Ciudad(int IdPais)
        {
            List<ElementJsonIntKey> list = new List<ElementJsonIntKey>();
            using (Models.GIROSEntities db = new Models.GIROSEntities())
            {
                list = (from d in db.CIUDAD
                        where d.Id_Pais == IdPais
                        select new ElementJsonIntKey
                        {
                            Value = d.Id_Ciudad,
                            Text = d.Nombre_Ciudad
                        }).ToList();

            }

            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public class ElementJsonIntKey
        {
            public int Value  { get; set; }
            public string Text  { get; set; }

        }


        public JsonResult DatosTabla(int IdCiudad)
        {
            List<ElementJsonIntKeyt> list = new List<ElementJsonIntKeyt>();
            using (Models.GIROSEntities db = new Models.GIROSEntities())
            {
                list = (from d in db.GGIROS
                        where d.Id_Ciudad == IdCiudad


                        select new ElementJsonIntKeyt
                        {
                            Value = d.Id_Ciudad,
                            Text = d.Nombre,
                            idCiudad = d.Id_Ciudad
                        }).ToList();

            }

            return Json(list, JsonRequestBehavior.AllowGet);

        }


        public class ElementJsonIntKeyt
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public int idCiudad { get; set; }

        }
    }
}