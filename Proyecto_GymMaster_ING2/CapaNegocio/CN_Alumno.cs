using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Alumno
    {
        private CD_Alumno objCapaDatos = new CD_Alumno();

        public List<Alumno> Listar()
        {
            return objCapaDatos.Listar();
        }


        public int Registrar(Alumno obj, out string mensaje)
        {
            return objCapaDatos.Registrar(obj, out mensaje);
        }

        public bool VerificarCuotaAlumno(int idAlumno, out int mesesAdeudados, out string cuotaAlDia)
        {
            return objCapaDatos.VerificarCuotaAlumno(idAlumno, out mesesAdeudados, out cuotaAlDia);
        }

        public bool EliminarAlumno(int idAlumno, out string mensaje)
        {
            return objCapaDatos.EliminarAlumno(idAlumno, out mensaje);
        }

        public bool RestaurarAlumno(int idAlumno, out string mensaje)
        {
            return objCapaDatos.RestaurarAlumno(idAlumno, out mensaje);
        }

        public bool Editar(Alumno obj, out string mensaje)
        {
            return objCapaDatos.Editar(obj, out mensaje);
        }
    }
}
