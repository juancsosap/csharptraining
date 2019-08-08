using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class Persona
    {
        public int id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_longitud")]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "nombre")]
        public String nombre { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_longitud")]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "apellido")]
        public String apellido { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_requerido")]
        [Range(0, 150, ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_rango")]
        [System.Web.Mvc.Remote("Validador", "Persona", ErrorMessage = "El valor debe ser par")]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "edad")]
        public int edad { get; set; }

        [DefaultValue("Chile")]
        [StringLength(500, MinimumLength = 20, ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_longitud")]
        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "direccion")]
        public String direccion { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_requerido")]
        [StringLength(20, MinimumLength = 8, ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_longitud")]
        [DataType(DataType.CreditCard)]
        [CreditCard(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_cc")]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "tarjeta")]
        public String tarjeta { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recursos.Vista), ErrorMessageResourceName = "error_requerido")]
        [DataType(DataType.Date)]
        [Display(ResourceType = typeof(Recursos.Persona.Modelo), Name = "nacimiento")]
        public DateTime nacimiento { get; set; }

        [ForeignKey("idUsuario")]
        public int idUsuario { get; set; }

        public Usuario usuario { get; set; }

    }
}