//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EderEntities : DbContext
    {
        public EderEntities()
            : base("name=EderEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<GeoReferencia> GeoReferencias { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Usuario1> Usuario1 { get; set; }
        public virtual DbSet<UsuarioEstado> UsuarioEstadoes { get; set; }
    
        public virtual int EstadoAdd(string nombre, string abreviacion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var abreviacionParameter = abreviacion != null ?
                new ObjectParameter("Abreviacion", abreviacion) :
                new ObjectParameter("Abreviacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EstadoAdd", nombreParameter, abreviacionParameter);
        }
    
        public virtual int EstadoDelete(Nullable<int> idEstado)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EstadoDelete", idEstadoParameter);
        }
    
        public virtual ObjectResult<EstadoGetAll_Result> EstadoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoGetAll_Result>("EstadoGetAll");
        }
    
        public virtual ObjectResult<EstadoGetById_Result> EstadoGetById(Nullable<int> idEstado)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoGetById_Result>("EstadoGetById", idEstadoParameter);
        }
    
        public virtual int EstadoUpdate(Nullable<int> idEstado, string nombre, string abreviacion)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var abreviacionParameter = abreviacion != null ?
                new ObjectParameter("Abreviacion", abreviacion) :
                new ObjectParameter("Abreviacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EstadoUpdate", idEstadoParameter, nombreParameter, abreviacionParameter);
        }
    
        public virtual int GeoReferenciaAdd(Nullable<int> idEstado, string latitud, string longitud)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            var latitudParameter = latitud != null ?
                new ObjectParameter("Latitud", latitud) :
                new ObjectParameter("Latitud", typeof(string));
    
            var longitudParameter = longitud != null ?
                new ObjectParameter("Longitud", longitud) :
                new ObjectParameter("Longitud", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GeoReferenciaAdd", idEstadoParameter, latitudParameter, longitudParameter);
        }
    
        public virtual int GeoReferenciaDelete(Nullable<int> idGeoReferencia)
        {
            var idGeoReferenciaParameter = idGeoReferencia.HasValue ?
                new ObjectParameter("IdGeoReferencia", idGeoReferencia) :
                new ObjectParameter("IdGeoReferencia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GeoReferenciaDelete", idGeoReferenciaParameter);
        }
    
        public virtual ObjectResult<GeoReferenciaGetAll_Result> GeoReferenciaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GeoReferenciaGetAll_Result>("GeoReferenciaGetAll");
        }
    
        public virtual ObjectResult<GeoReferenciaGetById_Result> GeoReferenciaGetById(Nullable<int> idGeoReferencia)
        {
            var idGeoReferenciaParameter = idGeoReferencia.HasValue ?
                new ObjectParameter("IdGeoReferencia", idGeoReferencia) :
                new ObjectParameter("IdGeoReferencia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GeoReferenciaGetById_Result>("GeoReferenciaGetById", idGeoReferenciaParameter);
        }
    
        public virtual int GeoReferenciaUpdate(Nullable<int> idGeoReferencia, Nullable<int> idEstado, string latitud, string longitud)
        {
            var idGeoReferenciaParameter = idGeoReferencia.HasValue ?
                new ObjectParameter("IdGeoReferencia", idGeoReferencia) :
                new ObjectParameter("IdGeoReferencia", typeof(int));
    
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            var latitudParameter = latitud != null ?
                new ObjectParameter("Latitud", latitud) :
                new ObjectParameter("Latitud", typeof(string));
    
            var longitudParameter = longitud != null ?
                new ObjectParameter("Longitud", longitud) :
                new ObjectParameter("Longitud", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GeoReferenciaUpdate", idGeoReferenciaParameter, idEstadoParameter, latitudParameter, longitudParameter);
        }
    
        public virtual int Usuario1Add(string contraseña, string nombre, Nullable<System.DateTime> fechaNacimiento, string rFC)
        {
            var contraseñaParameter = contraseña != null ?
                new ObjectParameter("Contraseña", contraseña) :
                new ObjectParameter("Contraseña", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usuario1Add", contraseñaParameter, nombreParameter, fechaNacimientoParameter, rFCParameter);
        }
    
        public virtual int Usuario1Delete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usuario1Delete", idUsuarioParameter);
        }
    
        public virtual ObjectResult<Usuario1GetAll_Result> Usuario1GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usuario1GetAll_Result>("Usuario1GetAll");
        }
    
        public virtual ObjectResult<Usuario1GetById_Result> Usuario1GetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usuario1GetById_Result>("Usuario1GetById", idUsuarioParameter);
        }
    
        public virtual int Usuario1Update(Nullable<int> idUsuario, string contraseña, string nombre, Nullable<System.DateTime> fechaNacimiento, string rFC)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var contraseñaParameter = contraseña != null ?
                new ObjectParameter("Contraseña", contraseña) :
                new ObjectParameter("Contraseña", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usuario1Update", idUsuarioParameter, contraseñaParameter, nombreParameter, fechaNacimientoParameter, rFCParameter);
        }
    
        public virtual int UsuarioAdd(string nombre, string apellidoPaterno, string apellidoMaterno, string email, string password, string sexo, string telefono)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, passwordParameter, sexoParameter, telefonoParameter);
        }
    
        public virtual int UsuarioDelete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioDelete", idUsuarioParameter);
        }
    
        public virtual int UsuarioEstadoAdd(Nullable<int> idEstado)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioEstadoAdd", idEstadoParameter);
        }
    
        public virtual int UsuarioEstadoDelete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioEstadoDelete", idUsuarioParameter);
        }
    
        public virtual ObjectResult<UsuarioEstadoGetAll_Result> UsuarioEstadoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioEstadoGetAll_Result>("UsuarioEstadoGetAll");
        }
    
        public virtual ObjectResult<UsuarioEstadoGetById_Result> UsuarioEstadoGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioEstadoGetById_Result>("UsuarioEstadoGetById", idUsuarioParameter);
        }
    
        public virtual int UsuarioEstadoUpdate(Nullable<int> idUsuario, Nullable<int> idEstado)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioEstadoUpdate", idUsuarioParameter, idEstadoParameter);
        }
    
        public virtual ObjectResult<UsuarioGetAll_Result> UsuarioGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAll_Result>("UsuarioGetAll");
        }
    
        public virtual ObjectResult<UsuarioGetById_Result> UsuarioGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetById_Result>("UsuarioGetById", idUsuarioParameter);
        }
    
        public virtual int UsuarioUpdate(Nullable<int> idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string password, string sexo, string telefono)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUpdate", idUsuarioParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, passwordParameter, sexoParameter, telefonoParameter);
        }
    }
}
