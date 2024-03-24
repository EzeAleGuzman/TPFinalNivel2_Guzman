using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Negocio.Utilidades;


namespace TPFinalNivel2_Guzman
{
    public partial class Catalogo : Form
    {
        private List<Articulo> listaArticulos;
        
        public Catalogo()
        {
            InitializeComponent();
        }


        private void CATALOGO_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            try
            {
              
                listaArticulos = negocio.listar();
                //ordenar Articulos por su numero
                listaArticulos = listaArticulos.OrderBy(p => p.Nombre).ToList();
                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = listaArticulos;
                //Como ocultar una columna
                OcultarColumnas();

                cargarImagen(listaArticulos[0].ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void OcultarColumnas()

        {
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["IdMArca"].Visible=false;
            dgvArticulos.Columns["IdCategoria"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            frmAltaArticulo agregar = new frmAltaArticulo();
            agregar.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = dgvArticulos.CurrentRow?.DataBoundItem as Articulo;
            try
            {
                if (seleccionado != null)
                {

                    frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
                    modificar.ShowDialog();
                    cargar();
                }
                else
                {
                    MessageBox.Show("Debes seleccionar un Registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Error al intentar modificar el Articulo.");
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo Seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(Seleccionado.ImagenUrl);
            }

        }

        private void cargarImagen(string imagen)
        {
            try
            {
                ptbImagenUrl.Load(imagen);

                if (imagen.Contains("https://images.samsung.com/is/image/samsung/assets/ar/p6_gro2/p6_initial_mktpd/smartphones/galaxy-s10/specs/galaxy-s10-plus_specs_design_colors_prism_black.jpg?$163_346_PNG$"))
                {
                    // este condicional esta hecho para solucionar el problema de la imagen del s10
                    ptbImagenUrl.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else
                {
                    // sino vuelvo a colocarlo de manera optima
                    ptbImagenUrl.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception)
            {

                ptbImagenUrl.Load("https://www.freundferreteria.com/img/image-not-found.png");
                ptbImagenUrl.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            eliminar(false);
        }

        private void eliminar(bool logico = false)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            Articulo seleccionado;

            try
            {

                seleccionado = dgvArticulos.CurrentRow?.DataBoundItem as Articulo;

                if (seleccionado != null)
                {
                    DialogResult resultado = MessageBox.Show("¿Seguro de eliminar el registro?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.OK)
                    {
                        if (logico)
                        {
                            negocio.eliminarLogico(seleccionado.Id);
                        }
                        else
                        {
                            negocio.eliminar(seleccionado.Id);
                        }
                        cargar();
                    }


                }
                else
                {
                    MessageBox.Show("Debes seleccionar un Registro", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btndetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = dgvArticulos.CurrentRow?.DataBoundItem as Articulo;
            if (seleccionado != null)
            {
                frmDetallesArticulo detalle = new frmDetallesArticulo(seleccionado);
                detalle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debes seleccionar un Registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       

    }
}
