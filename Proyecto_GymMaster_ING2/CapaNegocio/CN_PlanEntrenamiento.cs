using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_PlanEntrenamiento
    {
        private CD_PlanEntrenamiento objCD_PlanEntrenamiento = new CD_PlanEntrenamiento();

        //Metodo para listar los planes de entrenamiento
        public List<PlanEntrenamiento> Listar()
        {
            return objCD_PlanEntrenamiento.Listar();
        }

        // Método para agregar un nuevo plan de entrenamiento
        public int Agregar(PlanEntrenamiento plan, out string mensaje)
        {
            return objCD_PlanEntrenamiento.Agregar(plan, out mensaje);
        }

        // Método para asociar ejercicios al plan
        public void AsociarEjercicios(int idPlan, List<int> listaEjercicios)
        {
            foreach (int idEjercicio in listaEjercicios)
            {
                objCD_PlanEntrenamiento.AsociarEjercicio(idPlan, idEjercicio);
            }
        }

        // Método para asociar usuarios al plan
        public void AsociarUsuarios(int idPlan, List<int> listaUsuarios)
        {
            foreach (int idUsuario in listaUsuarios)
            {
                objCD_PlanEntrenamiento.AsociarUsuario(idUsuario, idPlan);
            }
        }

        // Método para editar un plan de entrenamiento 
        public int Editar(PlanEntrenamiento plan, out string mensaje)
        {
            return objCD_PlanEntrenamiento.Editar(plan, out mensaje);
        }

        public void EliminarPlan_Usuario(int idPlan)
        {
            objCD_PlanEntrenamiento.EliminarPlan_Usuario(idPlan);
        }

        public void EliminarPlan_Ejercicio(int idPlan)
        {
            objCD_PlanEntrenamiento.EliminarPlan_Ejercicio(idPlan);
        }

        // Metodo para eliminar un plan de entrenamiento
        public int Eliminar(int id_plan, out string mensaje)
        {
            return objCD_PlanEntrenamiento.Eliminar(id_plan, out mensaje);
        }

        // Metodo para restaurar un plan de entrenamiento
        public int Restaurar(int id_plan, out string mensaje)
        {
            return objCD_PlanEntrenamiento.Restaurar(id_plan, out mensaje);
        }

        // Metodo para obtener un plan a traves de la ID
        public PlanEntrenamiento ObtenerPlanPorID(int idPlan, out string mensaje)
        {
            return objCD_PlanEntrenamiento.ObtenerPlanPorID(idPlan, out mensaje);
        }


        // METODOS PARA LISTAR EJERCICIOS Y COACHS EN BASE AL ID_PLAN
        public List<Ejercicio> ListarEjerciciosPorPlan(int idPlan)
        {
            return objCD_PlanEntrenamiento.ListarEjerciciosPorPlan(idPlan);
        }

        public List<Usuario> ListarCoachsPorPlan(int idPlan)
        {
            return objCD_PlanEntrenamiento.ListarCoachsPorPlan(idPlan);
        }


        public List<PlanEntrenamiento> ListarPlanesPorCoachs(int idUsuario)
        {
            return objCD_PlanEntrenamiento.ListarPlanesPorCoachs(idUsuario);
        }
    }
}
