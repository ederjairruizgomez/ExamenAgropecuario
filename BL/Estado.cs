using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace BL
{
    public class Estado
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
                    var responseTask = client.GetAsync("Estado");
                    responseTask.Wait();
                    result.Objects = new List<object>();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {

                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Estado resultItemList = JsonConvert.DeserializeObject<ML.Estado>(resultItem.ToString());
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
        public static ML.Result GetByIdWebAPI(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.GetAsync("Estado/" + IdEstado);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Estado resultItemList = new ML.Estado();
                        resultItemList = JsonConvert.DeserializeObject<ML.Estado>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Estado";
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
        public static ML.Result AddWebAPI(ML.Estado estado)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Estado>("Estado/", estado);
                    postTask.Wait();
                    var result1 = postTask.Result;
                    if (result1.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Estado";
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
        public static ML.Result UpdateWebAPI(ML.Estado estado)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    var postTask = client.PutAsJsonAsync<ML.Estado>("Estado/" + estado.IdEstado, estado);
                    postTask.Wait();
                    var resultApi = postTask.Result;
                    if (resultApi.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Estado";
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
        public static ML.Result AddEF(ML.Estado estado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var query = context.EstadoAdd(estado.Nombre, estado.Abreviacion);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El Estado no se pudo insertar correctamente.";
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
        public static ML.Result UpdateEF(ML.Estado estado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var query = context.EstadoUpdate(estado.IdEstado, estado.Nombre, estado.Abreviacion);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El Estado no se pudo actualizar correctamente.";
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
        public static ML.Result DeleteEF(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var query = context.EstadoDelete(IdEstado);

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
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var usuarios = context.EstadoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios.ToList().Count >= 1)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = obj.IdEstado;
                            estado.Nombre = obj.Nombre;
                            estado.Abreviacion = obj.Abreviacion;
                            result.Objects.Add(estado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Estado";
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
        public static ML.Result GetByIdEF(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var estados = context.EstadoGetById(IdEstado).SingleOrDefault();

                    if (estados != null)
                    {
                        ML.Estado estado = new ML.Estado();
                        estado.IdEstado = estados.IdEstado;
                        estado.Nombre = estados.Nombre;
                        estado.Abreviacion = estados.Abreviacion;
                        result.Object = estado;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Estado";
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
