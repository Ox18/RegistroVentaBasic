using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_05_registroVentas
{
    class Registro
    {
        private DateTime fecha;
        private Producto producto;
        private int cantidad;

        public Registro() { }
        public Registro(DateTime vFecha, Producto vProducto, int vCantidad)
        {
            fecha = vFecha;
            producto = vProducto;
            cantidad = vCantidad;
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public double subtotal()
        {
            double subtotal = producto.Precio * Cantidad;
            return subtotal;
        }
        public double descuento()
        {
            double descuento;
            if (subtotal() > 20000)
            {
                descuento = subtotal() * 0.02;
            }else if (subtotal() > 10000)
            {
                descuento = subtotal() * 0.01;
            }else if (subtotal() > 5000)
            {
                descuento = subtotal() * 0.005;
            }
            else
            {
                descuento = 0;
            }
            return descuento;
        }
        public double total()
        {
            double total = subtotal() - descuento();
            return total;
        }
    }
}
