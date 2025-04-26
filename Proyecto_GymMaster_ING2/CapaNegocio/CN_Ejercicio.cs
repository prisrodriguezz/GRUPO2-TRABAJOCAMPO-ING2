using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Ejercicio
    {
        private CD_Ejercicio objCD_Ejercicio = new CD_Ejercicio(); // Instancia de la capa de datos

        // Método para listar ejercicios
        public List<Ejercicio> Listar()
        {
            return objCD_Ejercicio.Listar();
        }

        // Método para agregar un nuevo ejercicio
        

        // Método para editar un ejercicio existente
        

        // Método para eliminar un ejercicio
        
    }
}
