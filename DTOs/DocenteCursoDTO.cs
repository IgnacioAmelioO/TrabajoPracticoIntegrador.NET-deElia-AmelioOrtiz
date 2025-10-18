using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DocenteCursoDTO
    {
        public int Id_dictado { get; set; }
        public int Id_curso { get; set; }
        public int Id_docente { get; set; }
        public int Cargo { get; set; }
    }
}
