using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioEstadoController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.UsuarioEstado.GetAllWebAPI();

            ML.UsuarioEstado usuarioEstado = new ML.UsuarioEstado();
            usuarioEstado.UsuarioEstados = result.Objects;

            return View(usuarioEstado);

        }
        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdUsuario) //Add , Update
        {
            ML.UsuarioEstado usuarioEstado = new ML.UsuarioEstado();

            if (IdUsuario == null)//Add
            {
                return View(usuarioEstado);
            }
            else //Update
            {
                ML.Result result = BL.UsuarioEstado.GetByIdWebAPI(IdUsuario.Value);

                if (result.Correct)
                {
                    usuarioEstado.IdUsuario = ((ML.UsuarioEstado)result.Object).IdUsuario;
                    usuarioEstado.IdEstado = ((ML.UsuarioEstado)result.Object).IdEstado;

                    return View(usuarioEstado);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }


        }
        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.UsuarioEstado usuarioEstado)
        {
            ML.Result result = new ML.Result();

            if (usuarioEstado.IdUsuario == 0)//Add
            {
                result = BL.UsuarioEstado.AddWebAPI(usuarioEstado);
                ViewBag.Message = "El usuarioEstado se agregó correctamente ";
            }
            else //Update
            {
                result = BL.UsuarioEstado.UpdateWebAPI(usuarioEstado);
                ViewBag.Message = "El usuarioEstado se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el usuarioEstado " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.UsuarioEstado.DeleteEF(IdUsuario);

            return RedirectToAction("GetAll");
        }
    }
}