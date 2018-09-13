using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RankingDocentes.Models
{
    public class UsuarioSistemaViewModel
    {

        public int nUsuarioId { get; set; }


        [Required(ErrorMessage = "Debe ingresar una contraseña", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string cContraseña { get; set; }

        [Compare("cContraseña", ErrorMessage = "Las contraseñas no coinciden")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string cConfirmarContraseña { get; set; }

        [Required(ErrorMessage = "Debe ingresar nombres", AllowEmptyStrings = false)]
        public string cNombres { get; set; }

        [Required(ErrorMessage = "Debe ingresar Apellido Paterno", AllowEmptyStrings = false)]
        public string cUsuApePaterno { get; set; }

        [Required(ErrorMessage = "Debe ingresar Apellido Materno", AllowEmptyStrings = false)]
        public string cUsuApeMaterno { get; set; }

       
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage = "Debe ingresar un correo válido")]
        public string cCorreo { get; set; }

        public int nIdCarrera { get; set; }

        public List<Carrera> lstCarreras { get; set; }
        public virtual Carrera Carrera { get; set; }

        public int nTipoUsuario { get; set; }
        public string cEstado { get; set; }


    }
}