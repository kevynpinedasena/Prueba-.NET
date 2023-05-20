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
    public partial class Index : System.Web.UI.Page
    {
        //conexion a base de datos
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["libros"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack == false)
            {
                cargarLibros();
               
            }
        }

        //cargar la grilla
        void cargarLibros()
        {
            gvLibros.DataBind();
        }

        //accion para mandar al la gestion de Autores
        protected void btnCrearAutores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Autores.aspx");
        }

        //accion para mandar al la gestion de Editores
        protected void btnCrearEditores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Editores.aspx");
        }

        //metodo para crear libros
        protected void btnGuardarLibro_Click(object sender, EventArgs e)
        {
            LibrosBO adminLibros = new LibrosBO();

            string isbn = txtISBN.Text.ToString().Trim();
            string titulo = txtTitulo.Text.ToString().Trim();
            string nPaginas = txtNPaginas.Text.ToString().Trim();
            string sipnosis = txtSipnosis.Text.ToString().Trim();
            string idAutor = "-1";
            string idEditor = "-1";

            if (txtISBN.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el ISBN', 'info');", true);
            }
            else if (txtTitulo.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el Titulo', 'info');", true);
            }
            else if (txtSipnosis.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese la Sipnosis', 'info');", true);
            }
            else if (txtNPaginas.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el Numero de Paginas', 'info');", true);
            }
            else if (ddlIdAutores.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitoso!', 'Por favor seleccione un Autor', 'info');", true);
            }
            else if (ddlIdEditores.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitoso!', 'Por favor seleccione un Editor', 'info');", true);
            }
            else
            {
                idAutor = ddlIdAutores.SelectedValue.ToString();
                idEditor = ddlIdEditores.SelectedValue.ToString();

                int ISBN = Int32.Parse(isbn);
                int idA = Int32.Parse(idAutor);
                int idE = Int32.Parse(idEditor);

                string resultado = adminLibros.insertarLibros(ISBN, titulo, nPaginas, sipnosis, idA, idE);
                if (resultado == "OK")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitoso!', 'Libro Registrado Exitosamente', 'success');", true);
                    limpiar();
                    cargarLibros();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡error!', '"+ resultado +"', 'error');", true);
                }
            }
        }

        //metodo para Limpiar y desaparecer botones
        void limpiar()
        {
            txtISBN.Text = "";
            txtTitulo.Text = "";
            txtNPaginas.Text = "";
            txtSipnosis.Text = "";
            ddlIdAutores.SelectedValue = "-1";
            ddlIdEditores.SelectedValue = "-1";

            lblISBN.Enabled = true;
            txtISBN.Enabled = true;

            btnGuardarLibro.Visible = true;
            btnActualizarLibro.Visible = false;
            btnEliminarLibro.Visible = false;
        }

        //metodo para Actualizar libros
        protected void btnActualizarLibro_Click(object sender, EventArgs e)
        {
            LibrosBO adminLibros = new LibrosBO();

            string isbn = txtISBN.Text.ToString().Trim();
            string titulo = txtTitulo.Text.ToString().Trim();
            string nPaginas = txtNPaginas.Text.ToString().Trim();
            string sipnosis = txtSipnosis.Text.ToString().Trim();
            string idAutor = "-1";
            string idEditor = "-1";

            if (txtISBN.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el ISBN', 'info');", true);
            }
            else if (txtTitulo.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el Titulo', 'info');", true);
            }
            else if (txtNPaginas.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el Numero de Paginas', 'info');", true);
            }
            else if (txtSipnosis.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese la Sipnosis', 'info');", true);
            }
            else if (ddlIdAutores.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor Seleccione un Autor', 'info');", true);
            }
            else if (ddlIdEditores.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor Seleccione un Editor', 'info');", true);
            }
            else
            {
                idAutor = ddlIdAutores.SelectedValue.ToString();
                idEditor = ddlIdEditores.SelectedValue.ToString();

                int ISBN = Int32.Parse(isbn);
                int idA = Int32.Parse(idAutor);
                int idE = Int32.Parse(idEditor);
                if (adminLibros.modificarLibros(ISBN, titulo, nPaginas, sipnosis, idA, idE) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitoso!', 'Libro Actualizar Exitosamente', 'success');", true);
                    limpiar();
                    cargarLibros();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡error!', 'error', 'error');", true);
                }
            }
        }

        //metodo para Eliminar libros
        protected void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            LibrosBO adminLibros = new LibrosBO();

            string isbn = txtISBN.Text.ToString().Trim();
            if (txtISBN.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Alerta!', 'Por Favor ingrese el ISBN', 'info');", true);
            }
            else
            {
                int ISBN = Int32.Parse(isbn); 
                if (adminLibros.eliminarLibros(ISBN) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡Exitoso!', 'Libro Eliminado Exitosamente', 'success');", true);
                    limpiar();
                    cargarLibros();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "swal", "Swal.fire('¡error!', 'error', 'error');", true);
                }
            }
        }

        //Evento para mandar datos a los campos del formulario
        protected void gvLibros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string isbn = "";
            string titulo = "";
            string sipnosis = "";
            string numeroPaginas = "";
            string ddlidAutor = "";
            string ddlidEditor = "";

            if (e.CommandName == "modificar")
            {
                string[] datos = e.CommandArgument.ToString().Split(';');

                isbn = datos[0];
                titulo = datos[1];
                sipnosis = datos[2];
                numeroPaginas = datos[3];
                ddlidAutor = datos[4];
                ddlidEditor = datos[5];

                txtISBN.Text = isbn;
                txtTitulo.Text = titulo;
                txtNPaginas.Text = numeroPaginas;
                txtSipnosis.Text = sipnosis;
                ddlIdAutores.SelectedValue = ddlidAutor;
                ddlIdEditores.SelectedValue = ddlidEditor;

                lblISBN.Enabled = false;
                txtISBN.Enabled = false;

                btnGuardarLibro.Visible = false;
                btnActualizarLibro.Visible = true;
                btnEliminarLibro.Visible = true;
            }
        }

        //evento del boton cancelas para limpiar el formulario
        protected void btnCancelarLibro_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}