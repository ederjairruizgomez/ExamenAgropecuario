using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        [HttpGet]
        [Route("api/Usuario")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAllEF();
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
        [Route("api/Usuario/{IdUsuario}")]
        // GET: api/Usuario/5
        public IHttpActionResult GetById(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);
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
        [Route("api/Usuario/")]
        // POST: api/Usuario
        public IHttpActionResult Post([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEF(usuario);

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
        [Route("api/Usuario/{IdUsuario}")]
        // PUT: api/Usuario/5
        public IHttpActionResult Put(int IdUsuario, [FromBody] ML.Usuario usuario)
        {
            usuario.IdUsuario = IdUsuario;
            ML.Result result = BL.Usuario.UpdateEF(usuario);

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
        [Route("api/Usuario/{IdUsuario}")]
        // DELETE: api/Usuario/5
        public IHttpActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

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
