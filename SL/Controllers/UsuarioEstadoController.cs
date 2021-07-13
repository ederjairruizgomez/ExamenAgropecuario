using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class UsuarioEstadoController : ApiController
    {
        // GET: api/UsuarioEstado
        [HttpGet]
        [Route("api/UsuarioEstado")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.UsuarioEstado.GetAllEF();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("api/UsuarioEstado/{IdUsuario}")]
        // GET: api/UsuarioEstado/5
        public IHttpActionResult GetById(int IdUsuario)
        {
            ML.Result result = BL.UsuarioEstado.GetByIdEF(IdUsuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("api/UsuarioEstado/")]
        // POST: api/UsuarioEstado
        public IHttpActionResult Post([FromBody] ML.UsuarioEstado usuarioEstado)
        {
            ML.Result result = BL.UsuarioEstado.AddEF(usuarioEstado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        [Route("api/UsuarioEstado/{IdUsuario}")]
        // PUT: api/UsuarioEstado/5
        public IHttpActionResult Put(int IdUsuario, [FromBody] ML.UsuarioEstado usuarioEstado)
        {
            usuarioEstado.IdUsuario = IdUsuario;
            ML.Result result = BL.UsuarioEstado.UpdateEF(usuarioEstado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("api/UsuarioEstado/{IdUsuario}")]
        // DELETE: api/UsuarioEstado/5
        public IHttpActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.UsuarioEstado.DeleteEF(IdUsuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
