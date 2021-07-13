using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class EstadoController : ApiController
    {
        // GET: api/Estado
        [HttpGet]
        [Route("api/Estado")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Estado.GetAllEF();
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
        [Route("api/Estado/{IdEstado}")]
        // GET: api/Estado/5
        public IHttpActionResult GetById(int IdEstado)
        {
            ML.Result result = BL.Estado.GetByIdEF(IdEstado);
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
        [Route("api/Estado/")]
        // POST: api/Estado
        public IHttpActionResult Post([FromBody] ML.Estado estado)
        {
            ML.Result result = BL.Estado.AddEF(estado);

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
        [Route("api/Estado/{IdEstado}")]
        // PUT: api/Estado/5
        public IHttpActionResult Put(int IdEstado, [FromBody] ML.Estado estado)
        {
            estado.IdEstado = IdEstado;
            ML.Result result = BL.Estado.UpdateEF(estado);

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
        [Route("api/Estado/{IdEstado}")]
        // DELETE: api/Estado/5
        public IHttpActionResult Delete(int IdEstado)
        {
            ML.Result result = BL.Estado.DeleteEF(IdEstado);

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
