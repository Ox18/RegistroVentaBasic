using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_05_registroVentas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            listarProductos();
            headerAdd();

        }
        private void headerAdd()
        {
            dgvRegistro.Columns.Add("producto", "Descripcion del producto");
            dgvRegistro.Columns.Add("precio", "Precio S/.");
            dgvRegistro.Columns.Add("cantidad", "Cant");
            dgvRegistro.Columns.Add("subtotal", "Subtotal S/.");
            dgvRegistro.Columns.Add("descuento", "Dsct S/.");
            dgvRegistro.Columns.Add("total", "Total S/.");
            dgvRegistro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvRegistro.AllowUserToAddRows = false;
        }
        private void listarProductos()
        {
            Producto producto = new Producto();
            listProducto.DataSource = producto.listarProductos();
            listProducto.DisplayMember = "Descripcion";
            listProducto.ValueMember = "Codigo";
            listProducto.SelectedIndex = -1;
           
        }
        private void resetear()
        {
            txtPrecio.Text = "0";
            txtCantidad.Text = "0";
            listProducto.SelectedIndex = -1;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtFechaHora.Text = DateTime.Now.ToString();
        }

        private void listProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listProducto_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void listProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(listProducto.SelectedIndex);
            Producto producto = new Producto();
            producto = producto.buscarByCode(codigo);
            txtPrecio.Text = producto.Precio.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            int codigo = Convert.ToInt32(listProducto.SelectedIndex);
            Producto producto = new Producto();
            producto = producto.buscarByCode(codigo);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            Registro registro = new Registro(fecha, producto, cantidad);
            string[] fila = new string[6];
            fila[0] = registro.Producto.Descripcion;
            fila[1] = registro.Producto.Precio.ToString();
            fila[2] = registro.Cantidad.ToString();
            fila[3] = registro.subtotal().ToString();
            fila[4] = registro.descuento().ToString();
            fila[5] = registro.total().ToString();
            dgvRegistro.Rows.Add(fila);
            resetear();
            calcularTotal();
        }
        private void calcularTotal()
        {
            double total = 0;
            double subtotal = 0;
            double descuento = 0;
            foreach (DataGridViewRow fila in dgvRegistro.Rows)
            {
                total += Convert.ToDouble(fila.Cells["total"].Value);
                subtotal += Convert.ToDouble(fila.Cells["subtotal"].Value);
                descuento += Convert.ToDouble(fila.Cells["descuento"].Value);
            }
            txtDscto.Text = descuento.ToString();
            txtSubTotal.Text = subtotal.ToString();
            txtTotal.Text = total.ToString();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow fila in dgvRegistro.Rows)
            {
                dgvRegistro.Rows.Remove(fila);
            }
            calcularTotal();
        }

        private void dgvRegistro_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcularTotal();
        }

        private void dgvRegistro_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            calcularTotal();
        }
    }
}
