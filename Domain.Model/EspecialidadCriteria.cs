namespace Domain.Model
{
    public class EspecialidadCriteria
    {
        public string Texto { get; private set; }

        public EspecialidadCriteria(string texto)
        {
            Texto = texto ?? string.Empty;
        }
    }
}