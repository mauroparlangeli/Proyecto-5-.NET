using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace TP7_GRUPO_11.Clases
{
    public class GestionSucursales
    {


        public GestionSucursales(){ }

        public DataTable crearTabla()
        {
            DataTable dt = new DataTable();
            //Agregar columnas
            DataColumn columna = new DataColumn("ID_Sucursal", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            columna = new DataColumn("Nombre", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            columna = new DataColumn("Descripcion", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }

        public void agregarFila(DataTable tabla, string ID_Sucursal, string nombre, string descripcion)
        {
            DataRow dr = tabla.NewRow();
            dr["ID_Sucursal"] = ID_Sucursal;
            dr["Nombre"] = nombre;
            dr["Descripcion"] = descripcion;
            tabla.Rows.Add(dr);
        }


    }
}