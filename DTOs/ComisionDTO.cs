﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ComisionDTO
    {public int Id_comision { get; set; }
     public string Desc_comision { get; set; }

        public int Anio_especialidad { get; set; } = 1;

     public int Id_plan { get; set; }
     }
}
