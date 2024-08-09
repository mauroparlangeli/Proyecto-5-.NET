using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TP7_GRUPO_11.Clases
{
    public class Conexion
    {
        String ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=BDSucursales;Integrated Security=True";
        public Conexion()
        {
            ///constructor
        }


        public Sucursal ObtenerSucursalPorNombre(string nombreSucursal)
        {
            Sucursal sucursal = null;

            SqlConnection con = new SqlConnection(ruta);

            string consulta = "SELECT ID_Sucursal, NombreSucursal, DescripcionSucursal FROM Sucursal WHERE NombreSucursal =@NombreSucursal";
            SqlCommand cmd = new SqlCommand(consulta, con);

            cmd.Parameters.AddWithValue("@NombreSucursal", nombreSucursal);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                sucursal = new Sucursal
                {
                    IdSucursal = reader["ID_Sucursal"].ToString(),
                    NombreSucursal = reader["NombreSucursal"].ToString(),
                    DescripcionSucursal = reader["DescripcionSucursal"].ToString()
                };
            }
           
            con.Close();
            return sucursal;
        }
    }
}