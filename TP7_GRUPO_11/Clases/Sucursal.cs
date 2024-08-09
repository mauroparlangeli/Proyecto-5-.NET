using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_11.Clases
{
    public class Sucursal
    {
        public Sucursal() { }
        public Sucursal(String idSucursal, String nombreSucursal, String descripcionSucursal)
        {
            this.id_sucursal = idSucursal;
            this.nombre_sucursal = nombreSucursal;
            this.descripcion_sucursal = descripcionSucursal;
        }

        private String id_sucursal;
        private String nombre_sucursal;
        private String descripcion_sucursal;


        public String IdSucursal
        {
            get { return id_sucursal; }
            set { id_sucursal = value; }
        }

        public string NombreSucursal
        {
            get { return nombre_sucursal; }
            set { nombre_sucursal = value; }
        }

        public string DescripcionSucursal
        {
            get { return descripcion_sucursal; }
            set { descripcion_sucursal = value; }
        }
    }
}