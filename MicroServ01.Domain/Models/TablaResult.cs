using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServ01.Domain.Models
{
    public class TablaResult
    {
        public int Id { get; set; }
        public string? Semestre { get; set; }
        public string? Sexo { get; set; }
        public string? FecNac { get; set; } 
        public string? Ubigeo { get; set; }
        public string? Carrera { get; set; }
        public string? Ciclo { get; set; }
        public string? FecIngreso { get; set; }
        public string? Modalidad { get; set; }
        public int CreditosAcum { get; set; }
    }
}
