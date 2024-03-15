
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Utilidades
{
    internal class Validator
    {
        public static void MostrarMensajeError(Control control, string mensaje)
        {
            // Verificar si ya existe un control de mensaje de error para este control
            string nombreMensajeError = $"{control.Name}_mensajeError";
            if (!control.Parent.Controls.ContainsKey(nombreMensajeError))
            {
                // Si no existe, crear un nuevo control de mensaje de error
                Label nuevoMensajeError = new Label();
                nuevoMensajeError.Name = nombreMensajeError;
                nuevoMensajeError.Text = mensaje;
                nuevoMensajeError.ForeColor = Color.Red;
                nuevoMensajeError.Location = new Point(control.Location.X, control.Location.Y + control.Height);
                nuevoMensajeError.AutoSize = true;
                // Agregar el mensaje de error a la ventana o al contenedor apropiado
                control.Parent.Controls.Add(nuevoMensajeError);
            }
            else
            {
                // Si ya existe, actualizar el mensaje

                control.Parent.Controls[nombreMensajeError].Text = mensaje;
            }

            // Hacer visible el mensaje de error
            control.Parent.Controls[nombreMensajeError].Visible = true;
        }

        public static void OcultarMensajeError(Control control)
        {
            // Ocultar el mensaje de error si existe para este control
            string nombreMensajeError = $"{control.Name}_mensajeError";


            if (control.Parent.Controls.ContainsKey(nombreMensajeError))
            {
                control.Parent.Controls[nombreMensajeError].Visible = false;
            }
        }


       




    }
}
