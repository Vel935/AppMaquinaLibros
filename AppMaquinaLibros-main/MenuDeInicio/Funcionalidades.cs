using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppMaquinaLibros;


namespace MenuDeInicio
{
    public partial class Funcionalidades : Form
    {
        private List<Libro> Listadodelibros = new List<Libro>();
        public bool V_Agregarlibro = false;
        public bool V_Eliminarlibro = false;
        public bool V_Modificarlibro = false;
        public Funcionalidades()
        {
            InitializeComponent();
            Libro libro1 = new Libro();
            libro1.Codigo = "01";
            libro1.Nombre = "Algebra y trigonometria";
            libro1.Categoria = "Ciencias basicas";
            libro1.Cantidad = 10;
            libro1.Valor = 2000;

            Libro libro2 = new Libro();
            libro2.Codigo = "02";
            libro2.Nombre = "Matematicas discretas";
            libro2.Categoria = "Ciencias basicas";
            libro2.Cantidad = 15;
            libro2.Valor = 5000;

            Listadodelibros.Add(libro1);
            Listadodelibros.Add(libro2);
            lstLibrosDisponibles2.Items.Add(libro1.Nombre);
            lstLibrosDisponibles2.Items.Add(libro2.Nombre);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtBNombre.Enabled = true;
            txtBCodigo.Enabled = true;
            txtBCategoria.Enabled = true;
            txtBCantidad.Enabled = true;
            txtBPrecio.Enabled = true;
            btnGuardar.Enabled = true;
            V_Agregarlibro = true;
            V_Eliminarlibro = false;
            V_Modificarlibro = false;

            txtBNombre.Text = string.Empty;
            txtBCodigo.Text = string.Empty;
            txtBCategoria.Text = string.Empty;
            txtBCantidad.Text = string.Empty;
            txtBPrecio.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (V_Agregarlibro is true)
            {
                if (txtBNombre.Text != "" && txtBCodigo.Text != "" && txtBPrecio.Text != "" && txtBCantidad.Text != "")
                {
                    Libro libro_para_agregar = new Libro();
                    libro_para_agregar.Nombre = txtBNombre.Text;
                    libro_para_agregar.Codigo = txtBCodigo.Text;
                    libro_para_agregar.Categoria = txtBCategoria.Text;
                    libro_para_agregar.Cantidad = Convert.ToInt32(txtBCantidad.Text);
                    libro_para_agregar.Valor = Convert.ToDouble(txtBPrecio.Text);
                    Listadodelibros.Add(libro_para_agregar);
                    lstLibrosDisponibles2.Items.Add(libro_para_agregar.Nombre);
                    btnGuardar.Enabled = false;
                }
            }

            else if (V_Eliminarlibro is true)
            {
                int indiceLibros = lstLibrosDisponibles2.SelectedIndex;
                Listadodelibros.RemoveAt(indiceLibros);
                lstLibrosDisponibles2.Items.Remove(lstLibrosDisponibles2.SelectedItem);
                btnGuardar.Enabled = false;
                txtBNombre.Text = string.Empty;
                txtBCodigo.Text = string.Empty;
                txtBCategoria.Text = string.Empty;
                txtBCantidad.Text = string.Empty;
                txtBPrecio.Text = string.Empty;
            }
            else if (V_Modificarlibro is true)
            {

            }

        }

        private void lstLibrosDisponibles2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceLibros = lstLibrosDisponibles2.SelectedIndex;
            try
            {
                txtBNombre.Text = Listadodelibros[(indiceLibros)].Nombre;
                txtBCodigo.Text = Listadodelibros[(indiceLibros)].Codigo;
                txtBCategoria.Text = Listadodelibros[(indiceLibros)].Categoria;
                txtBCantidad.Text = Convert.ToString(Listadodelibros[(indiceLibros)].Cantidad);
                txtBPrecio.Text = Convert.ToString(Listadodelibros[(indiceLibros)].Valor);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            V_Agregarlibro = false;
            V_Eliminarlibro = true;
            btnGuardar.Enabled = true;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceLibros = lstLibrosDisponibles2.SelectedIndex;
                if (Listadodelibros[(indiceLibros)].Cantidad > 0)
                {
                    Listadodelibros[(indiceLibros)].Cantidad -= 1;
                    txtBCantidad.Text = Convert.ToString(Listadodelibros[(indiceLibros)].Cantidad);
                    MessageBox.Show("Su compra ha sido exitosa");
                }
                else
                {
                    MessageBox.Show("Lo siento, no hay más unidades");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Primero Selecciona un articulo!");
            }

        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void accesoCompleto()
        {
            btnEliminar.Enabled = true;
            btnAgregar.Enabled = true;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "0451")
            {
                accesoCompleto();
            }
            else txtContraseña.Text = string.Empty;


        }

    
    }
}
