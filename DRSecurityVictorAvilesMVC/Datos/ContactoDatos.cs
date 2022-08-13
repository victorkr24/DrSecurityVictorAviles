using DRSecurityVictorAvilesMVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace DRSecurityVictorAvilesMVC.Datos
{
    public class ContactoDatos
    {
        public List<Carro> Listar()
        {
            var oLista = new List<Carro>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("CarroGetAll", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new Carro()
                        {
                            IdCarro = Convert.ToInt32(dr["IdCarro"]),
                            Nombre = dr["Nombre"].ToString(),
                            Modelo = dr["Modelo"].ToString(),
                            NumeroSerie = dr["NumeroSerie"].ToString(),
                            IdColor = Convert.ToInt32(dr["IdColor"]),
                            IdMarca = Convert.ToInt32(dr["IdMarca"]),

                        });

                    }
                }
            }

            return oLista;
        }

        public Carro Obtener(int IdCarro)
        {

            var oContacto = new Carro();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("GetById", conexion);
                cmd.Parameters.AddWithValue("IdCarro", IdCarro);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContacto.IdCarro = Convert.ToInt32(dr["IdCarro"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Modelo = dr["Modelo"].ToString();
                        oContacto.NumeroSerie = dr["NumeroSerie"].ToString();
                        oContacto.IdColor = Convert.ToInt32(dr["IdColor"]);
                        oContacto.IdMarca = Convert.ToInt32(dr["IdMarca"]);
                    }
                }
            }

            return oContacto;
        }
        //Guarda un carro en la tabla
        public bool Guardar(Carro ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("CarroAdd", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Modelo", ocontacto.Modelo);
                    cmd.Parameters.AddWithValue("NumeroSerie", ocontacto.NumeroSerie);
                    cmd.Parameters.AddWithValue("IdColor", ocontacto.IdColor);
                    cmd.Parameters.AddWithValue("IdMarca", ocontacto.IdMarca);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }
        public bool Editar(Carro ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("CarroUpdate", conexion);
                    cmd.Parameters.AddWithValue("IdCarro", ocontacto.IdCarro);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Modelo", ocontacto.Modelo);
                    cmd.Parameters.AddWithValue("NumeroSerie", ocontacto.NumeroSerie);
                    cmd.Parameters.AddWithValue("IdColor", ocontacto.IdColor);
                    cmd.Parameters.AddWithValue("IdMarca", ocontacto.IdMarca);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar(int Idcarro)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("CarroDelete", conexion);
                    cmd.Parameters.AddWithValue("IdCarro", Idcarro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }



    }
}
