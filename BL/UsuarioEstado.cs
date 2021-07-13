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
    public class UsuarioEstado
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
                    var responseTask = client.GetAsync("UsuarioEstado");
                    responseTask.Wait();
                    result.Objects = new List<object>();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {

                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.UsuarioEstado resultItemList = JsonConvert.DeserializeObject<ML.UsuarioEstado>(resultItem.ToString());
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
        public static ML.Result GetByIdWebAPI(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.GetAsync("UsuarioEstado/" + IdUsuario);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.UsuarioEstado resultItemList = new ML.UsuarioEstado();
                        resultItemList = JsonConvert.DeserializeObject<ML.UsuarioEstado>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla UsuarioEstado";
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
        public static ML.Result AddWebAPI(ML.UsuarioEstado usuarioEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("UsuarioEstado/", usuarioEstado);
                    postTask.Wait();
                    var result1 = postTask.Result;
                    if (result1.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla UsuarioEstado";
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
        public static ML.Result UpdateWebAPI(ML.UsuarioEstado usuarioEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    var postTask = client.PutAsJsonAsync("UsuarioEstado/" + usuarioEstado.IdUsuario, usuarioEstado);
                    postTask.Wait();
                    var resultApi = postTask.Result;
                    if (resultApi.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla UsuarioEstado";
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
        public static ML.Result AddEF(ML.UsuarioEstado usuarioEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var query = context.UsuarioEstadoAdd(usuarioEstado.IdEstado);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El UsuarioEstado no se pudo insertar correctamente.";
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
        public static ML.Result UpdateEF(ML.UsuarioEstado usuarioEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var query = context.UsuarioEstadoUpdate(usuarioEstado.IdUsuario, usuarioEstado.IdEstado);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El UsuarioEstado no se pudo actualizar correctamente.";
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
        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var query = context.UsuarioEstadoDelete(IdUsuario);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El UsuarioEstado no se pudo borrar correctamente.";
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
                    var usuarios = context.UsuarioEstadoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios.ToList().Count >= 1)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.UsuarioEstado usuarioEstado = new ML.UsuarioEstado();
                            usuarioEstado.IdUsuario = obj.IdUsuario;
                            usuarioEstado.IdEstado = int.Parse(obj.IdEstado.ToString());
                            result.Objects.Add(usuarioEstado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla UsuarioEstado";
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
        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var Usuarios = context.UsuarioEstadoGetById(IdUsuario).SingleOrDefault();

                    if (Usuarios != null)
                    {
                        ML.UsuarioEstado usuarioEstado = new ML.UsuarioEstado();
                        usuarioEstado.IdUsuario = Usuarios.IdUsuario;
                        usuarioEstado.IdEstado = int.Parse(Usuarios.IdEstado.ToString());
                        result.Object = usuarioEstado;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla UsuarioEstado";
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
