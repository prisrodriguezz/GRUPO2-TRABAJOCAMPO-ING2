using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class DetallesPlanEntrenamiento : Form
    {
        private int id_Plan;
        public DetallesPlanEntrenamiento(int idPlan)
        {
            InitializeComponent();
            id_Plan = idPlan;
        }

        private void DetallesPlanEntrenamiento_Load(object sender, EventArgs e)
        {
            // Llamar a la capa de negocio para obtener los ejercicios del plan
            List<Ejercicio> listaEjercicios = new CN_PlanEntrenamiento().ListarEjerciciosPorPlan(id_Plan);

            dataGridViewEjercicios.Rows.Clear();
            foreach (Ejercicio ejercicio in listaEjercicios)
            {
                dataGridViewEjercicios.Rows.Add(new object[] {ejercicio.id_ejercicio, ejercicio.nombre, ejercicio.repeticiones,  ejercicio.tiempo});
            }

            cantEjercicios.Text = $"{dataGridViewEjercicios.Rows.Count}";

            // Llamar a la capa de negocio para obtener los coachs del plan
            List<Usuario> listaCoachs = new CN_PlanEntrenamiento().ListarCoachsPorPlan(id_Plan);

            dgvdataCoach.Rows.Clear();
            foreach (Usuario coach in listaCoachs)
            {
                dgvdataCoach.Rows.Add(new object[] {coach.id_usuario, coach.nombre, coach.apellido, coach.dni, coach.email, coach.fecha_nacimiento, coach.telefono});
            }

            cantCoachs.Text = $"{dgvdataCoach.Rows.Count}";
        }
    }
}
