using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GeoReferencia
    {
        public static ML.Result GetAllWebAPI()
        {
            ML.Result result = new ML.Result();

            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //HTTP GET
                    var responseTask = client.GetAsync("GeoReferencia");
                    responseTask.Wait();
                    result.Objects = new List<object>();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {

                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.GeoReferencias resultItemList = JsonConvert.DeserializeObject<ML.GeoReferencias>(resultItem.ToString());
                            result.Objects.Add(resultItemList);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result GetByIdWebAPI(int IdGeoReferencia)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.GetAsync("GeoReferencia/" + IdGeoReferencia);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.GeoReferencias resultItemList = new ML.GeoReferencias();
                        resultItemList = JsonConvert.DeserializeObject<ML.GeoReferencias>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla GeoReferencia";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static ML.Result AddWebAPI(ML.GeoReferencias geoReferencia)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("GeoReferencia/", geoReferencia);
                    postTask.Wait();
                    var result1 = postTask.Result;
                    if (result1.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla GeoReferencia";
                    }
                }

            }



            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;


        }
        public static ML.Result UpdateWebAPI(ML.GeoReferencias geoReferencia)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    var postTask = client.PutAsJsonAsync("GeoReferencia/" + geoReferencia.IdGeoReferencia, geoReferencia);
                    postTask.Wait();
                    var resultApi = postTask.Result;
                    if (resultApi.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla GeoReferencia";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;


        }
        public static ML.Result AddEF(ML.GeoReferencias geoReferencia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERuizAgropecuarioEntities context = new DL.ERuizAgropecuarioEntities())
                {
                    var query = context.GeoReferenciaAdd(geoReferencia.Estado.IdEstado, geoReferencia.Latitud, geoReferencia.Longitud);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El GeoReferencia no se pudo insertar correctamente.";
                    }
                }

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;


        }
        public static ML.Result UpdateEF(ML.GeoReferencias geoReferencia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERuizAgropecuarioEntities context = new DL.ERuizAgropecuarioEntities())
                {
                    var query = context.GeoReferenciaUpdate(geoReferencia.IdGeoReferencia, geoReferencia.Estado.IdEstado, geoReferencia.Latitud, geoReferencia.Longitud);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El GeoReferencia no se pudo actualizar correctamente.";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;


        }
        public static ML.Result DeleteEF(int IdGeoReferencia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERuizAgropecuarioEntities context = new DL.ERuizAgropecuarioEntities())
                {
                    var query = context.GeoReferenciaDelete(IdGeoReferencia);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El Estado no se pudo borrar correctamente.";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;


        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERuizAgropecuarioEntities context = new DL.ERuizAgropecuarioEntities())
                {
                    var usuarios = context.GeoReferenciaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios.ToList().Count >= 1)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.GeoReferencias geoReferencia = new ML.GeoReferencias();
                            geoReferencia.Estado = new ML.Estado();
                            geoReferencia.IdGeoReferencia = obj.IdGeoReferencia;
                            geoReferencia.Estado.IdEstado = int.Parse(obj.IdEstado.ToString());
                            geoReferencia.Latitud = (decimal)obj.Latitud;
                            geoReferencia.Longitud = (decimal)obj.Longitud;
                            result.Objects.Add(geoReferencia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla GeoReferencia";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static ML.Result GetByIdEF(int IdGeoReferencia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERuizAgropecuarioEntities context = new DL.ERuizAgropecuarioEntities())
                {
                    var GeoReferencias = context.GeoReferenciaGetById(IdGeoReferencia).SingleOrDefault();

                    if (GeoReferencias != null)
                    {
                        ML.GeoReferencias geoReferencia = new ML.GeoReferencias();
                        geoReferencia.Estado = new ML.Estado();
                        geoReferencia.IdGeoReferencia = GeoReferencias.IdGeoReferencia;
                        geoReferencia.Estado.IdEstado = int.Parse(GeoReferencias.IdEstado.ToString());
                        geoReferencia.Latitud = (decimal)GeoReferencias.Latitud;
                        geoReferencia.Longitud = (decimal)GeoReferencias.Longitud;
                        result.Object = geoReferencia;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla GeoReferencia";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
    }
}
