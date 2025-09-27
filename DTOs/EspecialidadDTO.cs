using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class EspecialidadDTO
    {
        public int Id_especialidad { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Desc_esp { get; set; } = string.Empty;
    }
}
