using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;

namespace CrudLibros.Pages
{
    public partial class Editores : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["libros"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack == false)
            {
                cargarEditor();
               
            }
        }

        //metodo para Cargar la grilla
        void cargarEditor()
        {
            gvEditor.DataBind();
        }

        //Accion de boton para redirigir al index
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Index.aspx");
        }

        //metodo para insertar editor
        protected void btnGuardarEditores_Click(object sender, EventArgs e)
        {
            LibrosBO adminLibros = new LibrosBO();

            string nombre = txtNombreEditor.Text.ToString();
            string sede = txtSede.Text.ToString();

            if (txtNombreEditor.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor Ingrese El Nombre', 'info');", true);
                cargarEditor();
            }
            else if (txtSede.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor Ingrese la sede', 'info');", true);
                cargarEditor();
            }
            else
            {
                if (adminLibros.insertarEditores(nombre, sede) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitoso!', 'Editor Registrado Exitosamente', 'success');", true);
                    cargarEditor();
                    limpiarEditores();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Error!', 'error', 'error');", true);
                }
            }
        }

        //metodo para limpiar el formulario y habilitar y desabilitar botones
        void limpiarEditores()
        {
            txtNombreEditor.Text = "";
            txtSede.Text = "";

            lblIDEditor.Visible = false;
            txtIDEditor.Visible = false;

            btnGuardarEditores.Visible = true;
            btnModificarEditores.Visible = false;
            btnEliminarEditores.Visible = false;
        }

        protected void btnCancelarGuaEditores_Click(object sender, EventArgs e)
        {
            limpiarEditores();
        }

        //Accion RowCommand para enviar valores al formulario
        protected void gvEditores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string idEditores = "";
            string nombre = "";
            string sede = "";

            if (e.CommandName == "modificar")
            {
                string[] datos = e.CommandArgument.ToString().Split(';');

                idEditores = datos[0];
                nombre = datos[1];
                sede = datos[2];

                txtIDEditor.Text = idEditores;
                txtNombreEditor.Text = nombre;
                txtSede.Text = sede;

                lblIDEditor.Visible = true;
                txtIDEditor.Visible = true;

                lblIDEditor.Enabled = false;
                txtIDEditor.Enabled = false;

                btnGuardarEditores.Visible = false;
                btnModificarEditores.Visible = true;
                btnEliminarEditores.Visible = true;
            }
        }


        //metodo para Actualizar editor
        protected void btnModificarEditores_Click(object sender, EventArgs e)
        {
            LibrosBO adminLibros = new LibrosBO();

            string ide = txtIDEditor.Text.ToString();
            string nombreEditor = txtNombreEditor.Text.ToString();
            string sede = txtSede.Text.ToString();

            if (txtIDEditor.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor Ingrese ID', 'info');", true);
            }
            else if (txtNombreEditor.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor Ingrese el Nombre', 'info');", true);
            }
            else if (txtSede.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor Ingrese la Sede', 'info');", true);
            }
            else
            {
                int idEditor = Int32.Parse(ide);
                if (adminLibros.modificarEditores(idEditor, nombreEditor, sede) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitoso!', 'Editor Actualizado Exitosamente', 'success');", true);
                    cargarEditor();
                    limpiarEditores();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡error!', 'error', 'error');", true);
                }
            }
        }

        //metodo para eliminar editor
        protected void btnEliminarEditores_Click(object sender, EventArgs e)
        {
            LibrosBO adminLibros = new LibrosBO();

            string idE = txtIDEditor.Text.ToString();

            if (idE == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'El Id no Pueder ser nulo', 'info');", true);
            }
            else
            {
                int idEditor = Int32.Parse(idE);
                if (adminLibros.eliminarEditores(idEditor) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitoso!', 'Editor Eliminado Exitosamente', 'success');", true);
                    cargarEditor();
                    limpiarEditores();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡error!', 'error', 'error');", true);
                }
            }
        }
    }
}