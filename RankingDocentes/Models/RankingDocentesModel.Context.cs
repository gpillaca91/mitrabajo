﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RankingDocentes.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    //using System.Data.Entity.Core.Objects; reemplazar por System.Data.Objects;
    using System.Data.Objects;
    using System.Linq;
    
    public partial class DefaultConnection : DbContext
    {
        public DefaultConnection()
            : base("name=DefaultConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<AprobacionDocente> AprobacionDocente { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<DetalleDocente> DetalleDocente { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<DocenteSugerido> DocenteSugerido { get; set; }
        public virtual DbSet<RankingDocente> RankingDocente { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int USP_INS_RegistrarUsuario(string cNombres, string cUsuApePaterno, string cUsuApeMaterno, string cCorreo, string cContraseña, Nullable<int> nIdCarrera, Nullable<int> nTipoUsuario)
        {
            var cNombresParameter = cNombres != null ?
                new ObjectParameter("cNombres", cNombres) :
                new ObjectParameter("cNombres", typeof(string));
    
            var cUsuApePaternoParameter = cUsuApePaterno != null ?
                new ObjectParameter("cUsuApePaterno", cUsuApePaterno) :
                new ObjectParameter("cUsuApePaterno", typeof(string));
    
            var cUsuApeMaternoParameter = cUsuApeMaterno != null ?
                new ObjectParameter("cUsuApeMaterno", cUsuApeMaterno) :
                new ObjectParameter("cUsuApeMaterno", typeof(string));
    
            var cCorreoParameter = cCorreo != null ?
                new ObjectParameter("cCorreo", cCorreo) :
                new ObjectParameter("cCorreo", typeof(string));
    
            var cContraseñaParameter = cContraseña != null ?
                new ObjectParameter("cContraseña", cContraseña) :
                new ObjectParameter("cContraseña", typeof(string));
    
            var nIdCarreraParameter = nIdCarrera.HasValue ?
                new ObjectParameter("nIdCarrera", nIdCarrera) :
                new ObjectParameter("nIdCarrera", typeof(int));
    
            var nTipoUsuarioParameter = nTipoUsuario.HasValue ?
                new ObjectParameter("nTipoUsuario", nTipoUsuario) :
                new ObjectParameter("nTipoUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_INS_RegistrarUsuario", cNombresParameter, cUsuApePaternoParameter, cUsuApeMaternoParameter, cCorreoParameter, cContraseñaParameter, nIdCarreraParameter, nTipoUsuarioParameter);
        }
    }
}
