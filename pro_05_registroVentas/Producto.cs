using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_05_registroVentas
{
    class Producto
    {
        private int codigo;
        private string nombre;
        private double precio;

        public Producto() { }
        public Producto(int vCodigo, string vNombre, double vPrecio)
        {
            codigo = vCodigo;
            nombre = vNombre;
            precio = vPrecio;
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Descripcion
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public List<Producto> listarProductos()
        {
            Producto producto1 = new Producto(1, "Televisor", 1200);
            Producto producto2 = new Producto(2, "Equipo", 500);
            Producto producto3 = new Producto(3, "Refrigeradora", 750);
            Producto producto4 = new Producto(4, "Lavadora", 300);
            List<Producto> productos = new List<Producto>();
            productos.Add(producto1);
            productos.Add(producto2);
            productos.Add(producto3);
            productos.Add(producto4);
            return productos;
        }
        public Producto buscarByCode(int codigoBuscar)
        {
            int indiceBuscado = codigoBuscar - 1;
            List<Producto> productos = listarProductos();
            Producto producto = productos[indiceBuscado];
            return producto;
        }
    }
}
