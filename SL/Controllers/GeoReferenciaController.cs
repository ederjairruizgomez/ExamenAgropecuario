using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class GeoReferenciaController : ApiController
    {
        // GET: api/GeoReferencia
        [HttpGet]
        [Route("api/GeoReferencia")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.GeoReferencia.GetAllEF();
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
        [Route("api/GeoReferencia/{IdGeoReferencia}")]
        // GET: api/GeoReferencia/5
        public IHttpActionResult GetById(int IdGeoReferencia)
        {
            ML.Result result = BL.GeoReferencia.GetByIdEF(IdGeoReferencia);
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
        [Route("api/GeoReferencia/")]
        // POST: api/GeoReferencia
        public IHttpActionResult Post([FromBody] ML.GeoReferencias geoReferencia)
        {
            ML.Result result = BL.GeoReferencia.AddEF(geoReferencia);

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
        [Route("api/GeoReferencia/{IdGeoReferencia}")]
        // PUT: api/GeoReferencia/5
        public IHttpActionResult Put(int IdGeoReferencia, [FromBody] ML.GeoReferencias geoReferencia)
        {
            geoReferencia.IdGeoReferencia = IdGeoReferencia;
            ML.Result result = BL.GeoReferencia.UpdateEF(geoReferencia);

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
        [Route("api/GeoReferencia/{IdGeoReferencia}")]
        // DELETE: api/GeoReferencia/5
        public IHttpActionResult Delete(int IdGeoReferencia)
        {
            ML.Result result = BL.GeoReferencia.DeleteEF(IdGeoReferencia);

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
