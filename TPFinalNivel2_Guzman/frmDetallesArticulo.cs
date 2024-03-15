using Dominio;
using MaterialSkin;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TPFinalNivel2_Guzman
{
    public partial class frmDetallesArticulo : Form
    {
        Articulo articulo;
      

        public frmDetallesArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo; 

        }





        private void DetallesArticulo_Load(object sender, EventArgs e)
        {

            MarcaNegocio Marca = new MarcaNegocio();
            CategoriaNegocio Categoria = new CategoriaNegocio();


            
                try
                {
                    var listaMarcas = Marca.listar();
                    listaMarcas.Insert(0, new Marca { Id = 0, Descripcion = "" });
                    cbbmarca.DataSource = listaMarcas;
                    cbbmarca.ValueMember = "Id";
                    cbbmarca.DisplayMember = "Descripcion";
                    var listaCategorias = Categoria.listar();
                    listaCategorias.Insert(0, new Categoria { Id = 0, Descripcion = "" });
                    cbbcategoria.DataSource = listaCategorias;
                    cbbcategoria.ValueMember = "Id";
                    cbbcategoria.DisplayMember = "Descripcion";



                    if (articulo != null)
                    {
                        labelCodigo.Text = articulo.Codigo;
                        labelNombre.Text = articulo.Nombre;
                        labelDescripcion.Text = articulo.Descripcion;
                        labelUrlImagen.Text = articulo.ImagenUrl;
                        cargarImagen(articulo.ImagenUrl);
                        cbbmarca.SelectedValue = articulo.IdMarca;
                        cbbcategoria.SelectedValue = articulo.IdCategoria;
                        labelPrecio.Text = articulo.Precio.ToString();
                    }
                }
                catch (Exception)
                {

                    throw;
                }



            }





        private void cargarImagen(string imagen)
        {
            try
            {
                ptbImagen.Load(imagen);

                if (imagen.Contains("https://images.samsung.com/is/image/samsung/assets/ar/p6_gro2/p6_initial_mktpd/smartphones/galaxy-s10/specs/galaxy-s10-plus_specs_design_colors_prism_black.jpg?$163_346_PNG$"))
                {
                    ptbImagen.SizeMode = PictureBoxSizeMode.CenterImage;                        
                }
                else
                {
                    ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                }
            catch (Exception)
            {

                ptbImagen.Load("https://www.freundferreteria.com/img/image-not-found.png");
                ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}

       

        
     

