using Domain.Model;

namespace Data
{
    public class PersonaInMemory
    {
        //No es ThreadSafe pero sirve para el proposito del ejemplo        
        public static List<Persona> Personas;

        static PersonaInMemory()
        {
            Personas = new List<Persona>
                {
                    new Persona(1, "Juan", "Pérez", "Calle Falsa 123", "juan.perez@email.com", "1122334455", new DateOnly(1990, 5, 12), "A001", "Alumno", 1),
                    new Persona(2, "María", "Gómez", "Av. Siempre Viva 742", "maria.gomez@email.com", "2233445566", new DateOnly(1988, 8, 23), "A002", "Alumno", 2),
                    new Persona(3, "Carlos", "López", "Calle 9 de Julio 100", "carlos.lopez@email.com", "3344556677", new DateOnly(1995, 3, 15), "A003", "Alumno", 1),
                    new Persona(4, "Ana", "Martínez", "Av. Corrientes 200", "ana.martinez@email.com", "4455667788", new DateOnly(1992, 12, 2), "A004", "Alumno", 3),
                    new Persona(5, "Lucía", "Fernández", "Calle Mitre 321", "lucia.fernandez@email.com", "5566778899", new DateOnly(1998, 7, 30), "A005", "Alumno", 2),
                    new Persona(6, "Pedro", "Sánchez", "Calle Belgrano 456", "pedro.sanchez@email.com", "6677889900", new DateOnly(1985, 1, 10), "A006", "Alumno", 1),
                    new Persona(7, "Sofía", "Ramírez", "Av. San Martín 789", "sofia.ramirez@email.com", "7788990011", new DateOnly(1993, 4, 18), "A007", "Alumno", 3),
                    new Persona(8, "Diego", "Torres", "Calle Sarmiento 654", "diego.torres@email.com", "8899001122", new DateOnly(1991, 9, 5), "A008", "Alumno", 2),
                    new Persona(9, "Valentina", "Silva", "Av. Rivadavia 321", "valentina.silva@email.com", "9900112233", new DateOnly(1996, 11, 25), "A009", "Alumno", 1),
                    new Persona(10, "Martín", "Castro", "Calle Moreno 147", "martin.castro@email.com", "1011121314", new DateOnly(1989, 6, 8), "A010", "Alumno", 2),
                    new Persona(11, "Camila", "Méndez", "Av. Libertador 963", "camila.mendez@email.com", "1213141516", new DateOnly(1994, 2, 14), "A011", "Alumno", 3),
                    new Persona(12, "Javier", "Ruiz", "Calle Lavalle 852", "javier.ruiz@email.com", "1314151617", new DateOnly(1997, 10, 3), "A012", "Alumno", 1),
                    new Persona(13, "Florencia", "Acosta", "Av. Santa Fe 753", "florencia.acosta@email.com", "1415161718", new DateOnly(1990, 3, 27), "A013", "Alumno", 2),
                    new Persona(14, "Federico", "Ortiz", "Calle Entre Ríos 369", "federico.ortiz@email.com", "1516171819", new DateOnly(1987, 5, 19), "A014", "Alumno", 3),
                    new Persona(15, "Paula", "Vega", "Av. Córdoba 258", "paula.vega@email.com", "1617181920", new DateOnly(1992, 8, 11), "A015", "Alumno", 1)
                };
        }

    }

}
