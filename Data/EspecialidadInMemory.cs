using Domain.Model;

namespace Data
{
    public class EspecialidadInMemory
    {
        public static List<Especialidad> Especialidades;

        static EspecialidadInMemory()
        {
            Especialidades = new List<Especialidad>
                {
                    new Especialidad(1, "Especialidad orientada al desarrollo, análisis y gestión de sistemas informáticos."),
                    new Especialidad(2, "Especialidad enfocada en el diseño y desarrollo de dispositivos y sistemas electrónicos."),
                    new Especialidad(3, "Especialidad dedicada a la optimización de procesos productivos y gestión industrial.")
                };
        }
    }
}
