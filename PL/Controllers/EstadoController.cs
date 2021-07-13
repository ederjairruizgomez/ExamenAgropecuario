using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Estado.GetAllWebAPI();

            ML.Estado estado = new ML.Estado();
            estado.Estados = result.Objects;

            return View(estado);

        }

        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdEstado) //Add , Update
        {
            ML.Estado estado = new ML.Estado();

            if (IdEstado == null)//Add
            {
                return View(estado);
            }
            else //Update
            {
                ML.Result result = BL.Estado.GetByIdWebAPI(IdEstado.Value);

                if (result.Correct)
                {
                    estado.IdEstado = ((ML.Estado)result.Object).IdEstado;
                    estado.Nombre = ((ML.Estado)result.Object).Nombre;
                    estado.Abreviacion = ((ML.Estado)result.Object).Abreviacion;

                    return View(estado);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }


        }

        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Estado estado)
        {
            ML.Result result = new ML.Result();

            if (estado.IdEstado == 0)//Add
            {
                result = BL.Estado.AddWebAPI(estado);
                ViewBag.Message = "El Estado se agregó correctamente ";
            }
            else //Update
            {
                result = BL.Estado.UpdateWebAPI(estado);
                ViewBag.Message = "El Estado se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el Estado " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdEstado)
        {
            ML.Result result = BL.Estado.DeleteEF(IdEstado);

            return RedirectToAction("GetAll");
        }
    }
}