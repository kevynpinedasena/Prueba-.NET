using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudLibros
{
    public class LibrosBO
    {
        //cadena de conexion
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["libros"].ConnectionString);

        //metodo para Insertar un Autor
        public Boolean insertarAutores(string nombre, string apellido)
        {

            Boolean ingreso = false;

            try
            {
                SqlCommand comando = new SqlCommand("autorInsProc", conexion);
                conexion.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                ingreso = comando.ExecuteNonQuery() > 0;
                ingreso = true;

            }
            catch
            {

            }
            finally
            {
                conexion.Close();
            }
            return ingreso;
        }

        //metodo para Actualizar un Autor
        public Boolean modificarAutor(int id, string nombre, string apellido)
        {

            Boolean ingreso = false;

            try
            {
                SqlCommand comando = new SqlCommand("autorUpdProc", conexion);
                conexion.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                ingreso = comando.ExecuteNonQuery() > 0;
                ingreso = true;

            }
            catch
            {

            }
            finally
            {
                conexion.Close();
            }
            return ingreso;
        }

        //metodo para eliminar un Autor
        public Boolean eliminarAutor(int id)
        {

            Boolean ingreso = false;

            try
            {
                SqlCommand comando = new SqlCommand("autorDelProc", conexion);
                conexion.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                ingreso = comando.ExecuteNonQuery() > 0;
                ingreso = true;

            }
            catch
            {

            }
            finally
            {
                conexion.Close();
            }
            return ingreso;
        }


        //editores
        //metodo para Insertar un Editor
        public Boolean insertarEditores(string nombre, string sede)
        {

            Boolean ingreso = false;

            try
            {
                SqlCommand comando = new SqlCommand("editoresInsProc", conexion);
                conexion.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@sede", sede);
                ingreso = comando.ExecuteNonQuery() > 0;
                ingreso = true;

            }
            catch
            {

            }
            finally
            {
                conexion.Close();
            }
            return ingreso;
        }


        //metodo para Actualizar un Editor
        public Boolean modificarEditores(int id, string nombre, string sede)
        {

            Boolean ingreso = false;

            try
            {
                SqlCommand comando = new SqlCommand("editorUpdProc", conexion);
                conexion.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@sede", sede);
                ingreso = comando.ExecuteNonQuery() > 0;
                ingreso = true;

            }
            catch
            {

            }
            finally
            {
                conexion.Close();
            }
            return ingreso;
        }

        //metodo para eliminar un Editor
        public Boolean eliminarEditores(int id)
        {

            Boolean ingreso = false;

            try
            {
                SqlCommand comando = new SqlCommand("editorDelProc", conexion);
                conexion.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                ingreso = comando.ExecuteNonQuery() > 0;
                ingreso = true;

            }
            catch
            {

            }
            finally
            {
                conexion.Close();
            }
            return ingreso;
        }

        //gestion libros
        //metodo para insertar un libro
        public String insertarLibros(int isbn, string titulo, string nPaginas, string sipnosis, int idAutor, int idEditor)
        {
            string respuesta = string.Empty;

            try
            {
                SqlCommand comando = new SqlCommand("librosInsProc", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@isbn", isbn);
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@nPaginas", nPaginas);
                comando.Parameters.AddWithValue("@sipnosis", sipnosis);
                comando.Parameters.AddWithValue("@idAtor", idAutor);
                comando.Parameters.AddWithValue("@idEditor", idEditor);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = reader.GetString(0);
                }
            }
            catch (Exception e)
            {
                string mes = e.Message.ToString();
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }

        //metodo para Actualizar un libro
        public Boolean modificarLibros(int isbn, string titulo, string nPaginas, string sipnosis, int idAutor, int idEditor)
        {

            Boolean ingreso = false;

            try
            {
                SqlCommand comando = new SqlCommand("libroUpdProc", conexion);
                conexion.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@isbn", isbn);
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@nPaginas", nPaginas);
                comando.Parameters.AddWithValue("@sipnosis", sipnosis);
                comando.Parameters.AddWithValue("@idAtor", idAutor);
                comando.Parameters.AddWithValue("@idEditor", idEditor);
                ingreso = comando.ExecuteNonQuery() > 0;
                ingreso = true;

            }
            catch
            {

            }
            finally
            {
                conexion.Close();
            }
            return ingreso;
        }


        //metodo para Eliminar un libro
        public Boolean eliminarLibros(int isbn)
        {

            Boolean ingreso = false;

            try
            {
                SqlCommand comando = new SqlCommand("libroDelProc", conexion);
                conexion.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@isbn", isbn);
                ingreso = comando.ExecuteNonQuery() > 0;
                ingreso = true;

            }
            catch
            {

            }
            finally
            {
                conexion.Close();
            }
            return ingreso;
        }
    }
}