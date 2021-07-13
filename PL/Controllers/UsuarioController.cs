using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAllWebAPI();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = result.Objects;

            return View(usuario);

        }
        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdUsuario) //Add , Update
        {
            ML.Usuario usuario = new ML.Usuario();

            if (IdUsuario == null)//Add
            {
                return View(usuario);
            }
            else //Update
            {
                ML.Result result = BL.GeoReferencia.GetByIdWebAPI(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                    usuario.Contraseña = ((ML.Usuario)result.Object).Contraseña;
                    usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                    usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                    usuario.RFC = ((ML.Usuario)result.Object).RFC;

                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }


        }
        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            if (usuario.IdUsuario == 0)//Add
            {
                result = BL.Usuario.AddWebAPI(usuario);
                ViewBag.Message = "El usuario se agregó correctamente ";
            }
            else //Update
            {
                result = BL.Usuario.UpdateWebAPI(usuario);
                ViewBag.Message = "El usuario se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el usuario " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

            return RedirectToAction("GetAll");
        }
    }
}