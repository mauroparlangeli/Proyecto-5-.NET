using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TP7_GRUPO_11.Clases;

namespace TP7_GRUPO_11
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Si esta vacio trae todas las sucursales
            if(txtSucursales.Text.Trim() == "")
            {
                SqlDataSourceSucursales.SelectCommand = "SELECT NombreSucursal, URL_Imagen_Sucursal, DescripcionSucursal FROM Sucursal";
            }
            else
            {
                SqlDataSourceSucursales.SelectCommand = "SELECT NombreSucursal, URL_Imagen_Sucursal, DescripcionSucursal FROM Sucursal WHERE NombreSucursal LIKE '%"+txtSucursales.Text+"%'";
            }
            txtSucursales.Text = "";
        }


        protected void BtnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            GestionSucursales gSucursales = new GestionSucursales();

            if (e.CommandName == "EventoSeleccionar")
            {
                if (Session["SucursalesSeleccionadas"] == null)
                {
                    Session["SucursalesSeleccionadas"] = gSucursales.crearTabla();
                }

                String nombre = e.CommandArgument.ToString();
                Conexion conexion = new Conexion();
                Sucursal sucursal = conexion.ObtenerSucursalPorNombre(nombre);

                if (ExisteID(sucursal.IdSucursal))
                {
                    return;
                }
                else
                {
                    gSucursales.agregarFila((DataTable)Session["SucursalesSeleccionadas"], sucursal.IdSucursal, nombre, sucursal.DescripcionSucursal);
                }             
            }
        }
        public bool ExisteID(string ID_Sucursal)
        {
            DataTable tabla = (DataTable)Session["SucursalesSeleccionadas"];
            foreach (DataRow row in tabla.Rows)
            {
                if (row["ID_Sucursal"].ToString() == ID_Sucursal)
                {
                    return true;
                }
            }
            return false;
        }


        protected void btnProvincias_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "comandoBoton")
            {
                SqlDataSourceSucursales.SelectCommand = "SELECT [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal] FROM [Sucursal] WHERE [Id_ProvinciaSucursal] =" + e.CommandArgument.ToString();
                txtSucursales.Text = "";
            }
        }
    }
}