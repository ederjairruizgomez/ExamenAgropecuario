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
    public class Usuario
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
                    var responseTask = client.GetAsync("Usuario");
                    responseTask.Wait();
                    result.Objects = new List<object>();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {

                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Usuario resultItemList = JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
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
                    var responseTask = client.GetAsync("Usuario/" + IdUsuario);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Usuario resultItemList = new ML.Usuario();
                        resultItemList = JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
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
        public static ML.Result AddWebAPI(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("Usuario/", usuario);
                    postTask.Wait();
                    var result1 = postTask.Result;
                    if (result1.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Usuario";
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
        public static ML.Result UpdateWebAPI(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    var postTask = client.PutAsJsonAsync("Usuario/" + usuario.IdUsuario, usuario);
                    postTask.Wait();
                    var resultApi = postTask.Result;
                    if (resultApi.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Usuario";
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
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var query = context.Usuario1Add(usuario.Contraseña, usuario.Nombre, usuario.FechaNacimiento, usuario.RFC);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El Usuario no se pudo insertar correctamente.";
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
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EderEntities context = new DL.EderEntities())
                {
                    var query = context.Usuario1Update(usuario.IdUsuario, usuario.Contraseña, usuario.Nombre, usuario.FechaNacimiento, usuario.RFC);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El Usuario no se pudo actualizar correctamente.";
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
                    var query = context.Usuario1Delete(IdUsuario);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El Usuario no se pudo borrar correctamente.";
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
                    var usuarios = context.Usuario1GetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios.ToList().Count >= 1)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Contraseña = obj.Contraseña;
                            usuario.Nombre = obj.Nombre;
                            usuario.FechaNacimiento = DateTime.Parse(obj.FechaNacimiento.ToString());
                            usuario.RFC = obj.RFC;
                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Usuario";
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
                    var Usuarios = context.Usuario1GetById(IdUsuario).SingleOrDefault();

                    if (Usuarios != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = Usuarios.IdUsuario;
                        usuario.Contraseña = Usuarios.Contraseña;
                        usuario.Nombre = Usuarios.Nombre;
                        usuario.FechaNacimiento = DateTime.Parse(Usuarios.FechaNacimiento.ToString());
                        usuario.RFC = Usuarios.RFC;
                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Usuario";
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
