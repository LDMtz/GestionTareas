using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Common;

namespace GestionTareas
{
    public class Conexion
    {
        //Cadena de Conexion a la BD
        static string cadena = "server= DESKTOP-1145PHU\\SQLEXPRESS; database= GestionTareas ; integrated security = true";

        //Metodo que devuelve todas las tareas de la base de datos.
        public List<Tarea> listarTareas()
        {
            List<Tarea> lista = new List<Tarea>();

            using (SqlConnection conectar = new SqlConnection(cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select CodigoTarea,NombreMateria,NombreTarea,Estado,Fecha,Tarea from tareas ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conectar);
                    cmd.CommandType = CommandType.Text;

                    conectar.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Tarea()
                            {
                                Codigo = Convert.ToInt32(dr["CodigoTarea"]),
                                Materia = dr["NombreMateria"].ToString(),
                                Nombre = dr["NombreTarea"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                Fecha = dr["Fecha"].ToString(),
                                cTarea = dr["Tarea"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se devolverá una lista vacia porque hubo un error.\n"+"Tipo de Excepcion: " + ex.GetType().Name + "\n"
                    + "Mensaje: " + ex.Message + "\n"
                    + "Link de Ayuda: " + ex.HelpLink + "\n"
                    + "Source: " + ex.Source + "\n"
                    , "Exception - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lista = new List<Tarea>();
                }
                finally
                {
                    conectar.Close();
                }
            }
            return lista;
        }

        //Metodo para agregar la tarea a la BD
        public void AgregarTarea(Tarea tarea)
        {
            string mensaje = string.Empty;

            SqlConnection conectar = new SqlConnection(cadena);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarTarea", conectar);
                cmd.Parameters.AddWithValue("Codigo",tarea.Codigo);
                cmd.Parameters.AddWithValue("Materia", tarea.Materia);
                cmd.Parameters.AddWithValue("Nombre", tarea.Nombre);
                cmd.Parameters.AddWithValue("Estado", tarea.Estado);
                cmd.Parameters.AddWithValue("Tarea", tarea.cTarea);
                cmd.Parameters.Add("Mensaje",SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                conectar.Open();
                cmd.ExecuteNonQuery();

                mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                MessageBox.Show(mensaje,"Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Tipo de Excepcion: "+ex.GetType().Name+"\n"
                    +"Mensaje: "+ex.Message + "\n"
                    +"Link de Ayuda: "+ex.HelpLink+ "\n"
                    +"Source: "+ex.Source + "\n"
                    , "Exception - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conectar.Close();
            }
        }

        //Metodo para modificar la tarea en la BD
        public void ModificarTarea(Tarea tarea, int CodigoAnterior)
        {
            string mensaje = string.Empty;

            SqlConnection conectar = new SqlConnection(cadena);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ModificarTarea", conectar);
                cmd.Parameters.AddWithValue("CodigoAnterior", CodigoAnterior);
                cmd.Parameters.AddWithValue("@CodigoNuevo", tarea.Codigo);
                cmd.Parameters.AddWithValue("Materia", tarea.Materia);
                cmd.Parameters.AddWithValue("Nombre", tarea.Nombre);
                cmd.Parameters.AddWithValue("Estado", tarea.Estado);
                cmd.Parameters.AddWithValue("Tarea", tarea.cTarea);
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                conectar.Open();
                cmd.ExecuteNonQuery();

                mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Tipo de Excepcion: " + ex.GetType().Name + "\n"
                    + "Mensaje: " + ex.Message + "\n"
                    + "Link de Ayuda: " + ex.HelpLink + "\n"
                    + "Source: " + ex.Source + "\n"
                    ,"Exception - Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                conectar.Close();
            }
        }
        
        //Metodo para eliminar la tarea en la BD
        public void EliminarTarea(int Codigo)
        {
            string mensaje = string.Empty;
            SqlConnection conectar = new SqlConnection(cadena);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarTarea", conectar);
                cmd.Parameters.AddWithValue("Codigo",Codigo);
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                conectar.Open();
                cmd.ExecuteNonQuery();

                mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tipo de Excepcion: " + ex.GetType().Name + "\n"
                    + "Mensaje: " + ex.Message + "\n"
                    + "Link de Ayuda: " + ex.HelpLink + "\n"
                    + "Source: " + ex.Source + "\n"
                    , "Exception - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conectar.Close();
            }
        }
    }
}
