using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practico._01
{
    public partial class webform1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList2_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }


        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)

        {

            
        }

        // Método para obtener el número de encuesta actual profe agregue esto porque sino era medio confuso a mi parecer 
        private int ObtenerNumeroEncuestaActual()
        {
            int numeroEncuestaActual = 1; // Valor predeterminado si no hay contador almacenado

            if (Session["NumeroEncuesta"] != null)
            {
                numeroEncuestaActual = (int)Session["NumeroEncuesta"];
            }

            return numeroEncuestaActual;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Ruta del archivo donde se guardarán los resultados
            string rutaArchivo = Server.MapPath("~/ResultadosEncuestas.txt");

            // Obtener el número de encuesta actual
            int numeroEncuestaActual = ObtenerNumeroEncuestaActual();

            // Incrementar el número de encuesta actual
            numeroEncuestaActual++;

            // Guardar el número de encuesta actual en la sesión lo de las sesiones los vimos el año pasado en php decidi implementarlo para practica je
            Session["NumeroEncuesta"] = numeroEncuestaActual;

            // Obtener el enunciado de la primera pregunta
            string enunciadoPregunta1 = Label2.Text;

            // Obtener la respuesta de la primera pregunta  osea el (RadioButton)
            string respuestaPregunta1 = RadioButtonList1.SelectedValue;

            // Obtener el enunciado de la segunda pregunta
            string enunciadoPregunta2 = Label3.Text;

            // Obtener las respuestas de la segunda pregunta (CheckBoxList)
            string respuestasPregunta2 = "";
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    respuestasPregunta2 += item.Value + "; "; // Obtener la opción seleccionada
                }
            }
            respuestasPregunta2 = respuestasPregunta2.TrimEnd(' ', ';'); // Eliminar el último ";"

            // Crear una cadena con el formato deseado para guardar en el archivo de texto
            string resultados = $"Encuesta #{numeroEncuestaActual}\r\n";
            resultados += $"Enunciado Pregunta 1: {enunciadoPregunta1}\r\n";
            resultados += $"Respuesta Pregunta 1: {respuestaPregunta1}\r\n";
            resultados += $"Enunciado Pregunta 2: {enunciadoPregunta2}\r\n";
            resultados += $"Respuestas Pregunta 2: {respuestasPregunta2}\r\n";

            // Verificar si se ha seleccionado alguna opción en los radio buttons
            if (RadioButtonList1.SelectedIndex == -1)
            {
                Response.Write("Por favor, selecciona una opción para la pregunta 1.");
                return;
            }

            // Verificar si se ha seleccionado alguna opción en los checkboxes me la complique solo me tuve que ayudar de internet xD
            bool algunCheckboxSeleccionado = false;
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    algunCheckboxSeleccionado = true;
                    break;
                }
            }

            if (!algunCheckboxSeleccionado)
            {
                Response.Write("Por favor, selecciona al menos una opción para la pregunta 2.");
                return;
            }

            try
            {
                // Agregar los resultados al archivo de texto (no sobrescribir)
                File.AppendAllText(rutaArchivo, resultados);

                // Mostrar un mensaje de éxito
                Response.Write("Encuesta guardada correctamente.");

                // Deseleccionar todos los RadioButton
                RadioButtonList1.ClearSelection();

                // Deseleccionar todos los CheckBox
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    item.Selected = false;
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir al guardar el archivo....
                Response.Write($"Error al guardar la encuesta: {ex.Message}");
            }
        }








    }
}