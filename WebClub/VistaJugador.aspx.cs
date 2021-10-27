using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Entidades.Models;
using Entidades.Datos;

namespace WebClub
{
    public partial class VistaJugador : System.Web.UI.Page
    {
        private void MostrarJugadores()
        {
            gridJugador.DataSource = AdmJugador.Listar();
            gridJugador.DataBind();
        }
        private void LlenarCombo()
        {
            DataTable puestos = AdmPuesto.Listar();
            ddlPuesto.DataSource = puestos;
            ddlPuesto.DataValueField = puestos.Columns["Nombre"].ToString();
            ddlPuesto.DataTextField = puestos.Columns["Nombre"].ToString();
            ddlPuesto.DataBind();
        }

        private void LlenarBuscador()
        {
            DataTable buscarPuesto = AdmPuesto.Listar();
            ddlBuscar.DataSource = buscarPuesto;
            ddlBuscar.DataValueField = buscarPuesto.Columns["Nombre"].ToString();
            ddlBuscar.DataTextField = buscarPuesto.Columns["Nombre"].ToString();
            DataRow fila = buscarPuesto.NewRow();
            fila["Id"] = 0;
            fila["Nombre"] = "[TODOS]";
            buscarPuesto.Rows.InsertAt(fila, 0);
            ddlBuscar.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarJugadores();
                LlenarCombo();
                LlenarBuscador();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime fecha = Convert.ToDateTime(txtFechaNacimiento.Text);
            string puesto = ddlPuesto.SelectedValue;
            Jugador jugador = new Jugador(nombre, apellido, fecha, puesto);
            int filasAfectadas = AdmJugador.Insertar(jugador);
            if (filasAfectadas > 0)
            {
                MostrarJugadores();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime fecha = Convert.ToDateTime(txtFechaNacimiento.Text);
            string puesto = ddlPuesto.SelectedValue;
            Jugador jugador = new Jugador(id, nombre, apellido, fecha, puesto);
            int filasAfectadas = AdmJugador.Modificar(jugador);
            if (filasAfectadas > 0)
            {
                MostrarJugadores();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int filasAfectadas = AdmJugador.Eliminar(id);
            if (filasAfectadas > 0)
            {
                MostrarJugadores();
            }
        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrueba.Text = Convert.ToString(ddlBuscar.SelectedValue);
            string puesto = Convert.ToString(ddlBuscar.SelectedValue);
            if (puesto == "[TODOS]")
            {
                MostrarJugadores();
            }
            else
            {
                gridJugador.DataSource = AdmJugador.Listar(puesto);
                gridJugador.DataBind();
            }
        }
    }
}