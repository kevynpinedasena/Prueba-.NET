using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CrudLibros.Pages
{
    public partial class Autores : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["libros"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack == false)
            {
                cargarAutores();
               
            }
        }

        //metodo para Cargar la grilla 
        void cargarAutores()
        {
            gvAutores.DataBind();
        }

        //Accion de boton para redireccionar al index
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Index.aspx");
        }

        //metodo para insertar Autor
        protected void btnGuardarAutores_Click(object sender, EventArgs e)
        {
            LibrosBO adminLibros = new LibrosBO();

            string nombre = txtNombreAutor.Text.ToString();
            string apellido = txtApellidoAutor.Text.ToString();

            if (txtNombreAutor.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el Nombre', 'info');", true);
            }
            else if (txtApellidoAutor.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el Apellido', 'info');", true);
            }
            else
            {
                if (adminLibros.insertarAutores(nombre, apellido) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitosamente!', 'Autor Registrado Correctamente', 'success');", true);
                    cargarAutores();
                    limpiarAutores();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡error!', 'error', 'error');", true);
                }
            }
        }

        //metodo para limpiar formulario y activar btn
        void limpiarAutores()
        {
            txtNombreAutor.Text = "";
            txtApellidoAutor.Text = "";

            lblIdAutor.Visible = false;
            txtIDAutor.Visible = false;

            btnGuardarAutores.Visible = true;
            btnModificarAutor.Visible = false;
            btnEliminarAutores.Visible = false;
        }

        //evento de boton cancelar para limpiar
        protected void btnCancelarGuaAutor_Click(object sender, EventArgs e)
        {
            limpiarAutores();
        }

        //evento de la grilla para optener datos y enviarlos al formulario
        protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string idAutor = "";
            string nombre = "";
            string apellido = "";

            if (e.CommandName == "modificar")
            {
                string[] datos = e.CommandArgument.ToString().Split(';');

                idAutor = datos[0];
                nombre = datos[1];
                apellido = datos[2];

                txtIDAutor.Text = idAutor;
                txtNombreAutor.Text = nombre;
                txtApellidoAutor.Text = apellido;

                lblIdAutor.Visible = true;
                txtIDAutor.Visible = true;

                lblIdAutor.Enabled = false;
                txtIDAutor.Enabled = false;

                btnGuardarAutores.Visible = false;
                btnModificarAutor.Visible = true;
                btnEliminarAutores.Visible = true;
            }
        }

        //metodo para Modificar Autor
        protected void btnModificarAutor_Click(object sender, EventArgs e)
        {
            LibrosBO adminLibros = new LibrosBO();

            string idA = txtIDAutor.Text.ToString();
            string nombreAutor = txtNombreAutor.Text.ToString();
            string apellidoAutor = txtApellidoAutor.Text.ToString();

            if (txtIDAutor.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el ID', 'info');", true);
            }
            else if (txtNombreAutor.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el Nombre', 'info');", true);
            }
            else if (txtApellidoAutor.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el Apellido', 'info');", true);
            }
            else
            {
                int idAutor = Int32.Parse(idA);
                if (adminLibros.modificarAutor(idAutor, nombreAutor, apellidoAutor) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitosamente!', 'Autor Actualizado Correctamente', 'success');", true);
                    cargarAutores();
                    limpiarAutores();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡error!', 'error', 'error');", true);
                }
            }
        }

        //metodo para Eliminar Autor
        protected void btnEliminarAutores_Click(object sender, EventArgs e)
        {
            LibrosBO adminLibros = new LibrosBO();

            string idA = txtIDAutor.Text.ToString();

            if (idA == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el ID', 'info');", true);
            }
            else
            {
                int idAutor = Int32.Parse(idA);
                if (adminLibros.eliminarAutor(idAutor) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitosamente!', 'Autor Eliminado Correctamente', 'success');", true);
                    cargarAutores();
                    limpiarAutores();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡errror!', 'error', 'error');", true);
                }
            }
        }
    }
}