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
    public partial class Inicio : Form
    {
        bool sidebarExpand;
        bool articulosMenu;
        public Inicio()
        {
            InitializeComponent();
        }

        //funcion para abrir los formularios dentro del dashboar principal
        private void AbrirFormHijo (object formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
           Form fm = formhijo as Form;
            fm.TopLevel = false;
            fm.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fm);
            this.PanelContenedor.Tag = fm;
            fm.Show();
        }

        private void SideBarTime_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebarContainer.Width -= 10;
                if (sidebarContainer.Width <= sidebarContainer.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SideBarTime.Stop();
                }

            }
            else
            {
                sidebarContainer.Width += 10;
                if (sidebarContainer.Width >= sidebarContainer.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SideBarTime.Stop();
                }
            }

        }

        private void BotonMenu_Click(object sender, EventArgs e)
        {
            SideBarTime.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void articulosTimer_Tick(object sender, EventArgs e)
        {
            if (articulosMenu)
            {
                articulosContainer.Height -= 10;
                if (articulosContainer.Height == articulosContainer.MinimumSize.Height)
                {
                    articulosMenu = false;
                    articulosTimer.Stop();

                }

            }
            else
            {
                articulosContainer.Height += 10;
                if (articulosContainer.Height == articulosContainer.MaximumSize.Height)
                {
                    articulosMenu = true;
                    articulosTimer.Stop();

                }

            }

        }



        private void button6_Click(object sender, EventArgs e)
        {
            articulosTimer.Start();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Portada());
        }

        private void PnEnStock_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Catalogo());
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            btnInicio_Click(null, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Construiccion());
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Construiccion());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Construiccion());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Construiccion());
        }
    }
}
