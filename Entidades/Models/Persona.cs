using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public abstract class Persona
    {
        public Persona() { }
        public Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido=apellido;
        }
        public Persona(int id, string nombre, string apellido)
        {
            Id = id;
            Nombre = nombre;
            Apellido=apellido;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
