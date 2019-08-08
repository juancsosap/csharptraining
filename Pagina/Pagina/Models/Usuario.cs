using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class Usuario
    {
        public int id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_requerido")]
        [StringLength(100, MinimumLength = 10, ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_longitud")]
        [EmailAddress(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_email")]
        [DataType(DataType.EmailAddress)]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "email")]
        public String email { get; set; }

        [NotMapped]
        [Required(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_requerido")]
        [EmailAddress(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_email")]
        [Compare("email", ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_comparar")]
        [DataType(DataType.EmailAddress)]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "emailval")]
        public String emailval { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_requerido")]
        [StringLength(100, MinimumLength = 8, ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_longitud")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "contrasena")]
        public String contrasena { get; set; }

        [NotMapped]
        [Required(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_requerido")]
        [Compare("contrasena", ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_comparar")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "contrasenaval")]
        public String contrasenaval { get; set; }

        public Persona persona { get; set; }
    }
}