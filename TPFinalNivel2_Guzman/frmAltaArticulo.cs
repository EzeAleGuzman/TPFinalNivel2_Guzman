using Dominio;
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
using System.Xml.Linq;
using Negocio.Utilidades;
using MaterialSkin.Controls;

namespace TPFinalNivel2_Guzman
{
    public partial class frmAltaArticulo : Form 
    {
        Articulo articulo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
            Text = "Agregar Articulo";
        }

        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }


        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio Marca = new MarcaNegocio();
            CategoriaNegocio Categoria = new CategoriaNegocio();
            this.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);


            try
            {
                   var listaMarcas = Marca.listar();
                   listaMarcas.Insert(0, new Marca { Id = 0, Descripcion = "" });
                   cbbMarca.DataSource = listaMarcas;
                   cbbMarca.ValueMember = "Id";
                   cbbMarca.DisplayMember = "Descripcion";
                   var listaCategorias = Categoria.listar();
                   listaCategorias.Insert(0, new Categoria { Id = 0, Descripcion = "" });
                   cbbCategoria.DataSource = listaCategorias;
                   cbbCategoria.ValueMember = "Id";
                   cbbCategoria.DisplayMember = "Descripcion";



                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtUrlImagen.Text = articulo.ImagenUrl;
                    cargarImagen(articulo.ImagenUrl);
                    cbbMarca.SelectedValue = articulo.IdMarca;
                    cbbCategoria.SelectedValue = articulo.IdCategoria;
                    txtPrecio.Text = articulo.Precio.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {

                if (!ValidarCampos())
                {
                    return;
                }

                ArticulosNegocio negocio = new ArticulosNegocio();

                if (articulo == null)
                {
                    articulo = new Articulo();
                }
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.ImagenUrl = txtUrlImagen.Text;
                articulo.Marca = (Marca)cbbMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbbCategoria.SelectedItem;
                decimal precio = Convert.ToDecimal(txtPrecio.Text);
                articulo.Precio = precio;
                
                
                


                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado Correctamente");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado Exitosamente");
                }

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }


        //la funcion general que realiza las validaciones
        private  bool ValidarCampos()
        {
            Txtvacio(txtNombre, "Por favor ingrese un Nombre");
            Txtvacio(txtCodigo, "Por favor ingrese un Código");
            Txtvacio(txtDescripcion, "Por favor ingrese una Descripcion");
            Txtvacio(txtPrecio, "Por favor ingrese un Precio");
            Txtvacio(txtUrlImagen, "Por favor ingrese la direccion de una imagen");
            cbbVacio(cbbMarca, "Selecciona una marca");
            cbbVacio(cbbCategoria, "Selecciona una categoria");
            if (!soloNumeros(txtPrecio, "Ingresa solo números"))
            {
                return false;
            }
            if (!Txtvacio(txtPrecio, "Por favor ingrese un Precio")) 
            {
                return false;
            }
           

            return true;
        }



        //validar los txt para que no esten vacios
        public bool Txtvacio(TextBox textBox, string mensaje)
        {
            if (textBox.Text == "")
            {
                Validator.MostrarMensajeError(textBox, mensaje);
                return false;
            }
            else
            {
                Validator.OcultarMensajeError(textBox);
            }
            return true;
        }



        //valido que en el txt se ingrese solo numeros(y tambien agregue la coma)
        public static bool soloNumeros(TextBox textBox,string mensaje)
        {
            foreach (char c in textBox.Text)
            {
                if (!(char.IsNumber(c) || c == ','))
                {
                    Validator.MostrarMensajeError(textBox, mensaje);
                    return false;
                }

            }
            return true;
        }



        //Esta funcion valida que un Combobox no puede estar vacio a la hora de agregar un nuevo articulo
        public bool cbbVacio(ComboBox comboBox, string mensaje)
        {
            //utilizo el indice 0, con la idea de que por distraccion al cargar un articulo se obvie especificar estas opciones
            if (comboBox.SelectedIndex == 0)
            {
                //cuando el indice es 0, muestra el msj de error y crea la validacion
                Validator.MostrarMensajeError(comboBox, mensaje);
                return false;
            }
            else
            {
                //sino borra el mensaje de error
                Validator.OcultarMensajeError(comboBox);
            }

            return true;
        }

    
    }
}
