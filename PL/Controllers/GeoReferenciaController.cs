using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class GeoReferenciaController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.GeoReferencia.GetAllWebAPI();

            ML.GeoReferencias geoReferencia = new ML.GeoReferencias();
            geoReferencia.Estado = new ML.Estado();
            geoReferencia.geoReferencias = result.Objects;

            return View(geoReferencia);

        }
        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdGeoReferencia) //Add , Update
        {
            ML.GeoReferencias geoReferencia = new ML.GeoReferencias();

            if (IdGeoReferencia == null)//Add
            {
                return View(geoReferencia);
            }
            else //Update
            {
                ML.Result result = BL.GeoReferencia.GetByIdWebAPI(IdGeoReferencia.Value);

                if (result.Correct)
                {
                    geoReferencia.Estado = new ML.Estado();
                    geoReferencia.IdGeoReferencia = ((ML.GeoReferencias)result.Object).IdGeoReferencia;
                    geoReferencia.Estado.IdEstado = ((ML.GeoReferencias)result.Object).Estado.IdEstado;
                    geoReferencia.Latitud = ((ML.GeoReferencias)result.Object).Latitud;
                    geoReferencia.Longitud = ((ML.GeoReferencias)result.Object).Longitud;

                    return View(geoReferencia);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }


        }
        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.GeoReferencias geoReferencia)
        {
            ML.Result result = new ML.Result();

            if (geoReferencia.IdGeoReferencia == 0)//Add
            {
                result = BL.GeoReferencia.AddWebAPI(geoReferencia);
                ViewBag.Message = "El geoReferencia se agregó correctamente ";
            }
            else //Update
            {
                result = BL.GeoReferencia.UpdateWebAPI(geoReferencia);
                ViewBag.Message = "El geoReferencia se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el Estado " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdGeoReferencia)
        {
            ML.Result result = BL.GeoReferencia.DeleteEF(IdGeoReferencia);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Mapa1(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            return View();            
        }
        [HttpGet]
        public ActionResult Mapa()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}