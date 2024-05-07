using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Negocio
{
    public class Validaciones
    {

        public bool soloNumeros(string cadena)
        {       
            if (!(decimal.TryParse(cadena, out _)))
            {
                MessageBox.Show("Debes ingresar un precio con el formato correcto 0.00");
                return true;
            }
                
            else
                return false;
        }

        public bool formatoPrecio(string cadena)
        {
            if (cadena.Contains(","))
            {
                MessageBox.Show("El formato precio no admite comas, en su lugar utilice el punto");
                return true;
            }
            else
                return false;
        }


        public bool campoVacio(string cadena) 
        {
            
            if (string.IsNullOrEmpty(cadena))
            {
                MessageBox.Show("Debes cargar el campo...");
                return true;
            }          
                
            else
                return false;
        }

        public bool validarPrecio(string cadena)
        {
            if (formatoPrecio(cadena))
            {
                return true;
            }

            if (soloNumeros(cadena))               
                return true;
                           
            else if (campoVacio(cadena))
                return true;
            else
                return false;
        }
        //NADA DE ESTO FUNCIONA PARA VALIDAR LA IMAGEN:
        //public static bool IsImageUrl(string image)
        //{
        //    try
        //    {
        //        // Realiza una solicitud HEAD a la URL para obtener los encabezados de la respuesta
        //        var request = WebRequest.Create(image) as HttpWebRequest;
        //        request.Method = "HEAD"; // Utiliza el método HEAD para obtener solo los encabezados
        //        using (var response = request.GetResponse() as HttpWebResponse)
        //        {
        //            // Verifica si el código de estado de la respuesta es OK (200)
        //            if (response.StatusCode == HttpStatusCode.OK)
        //            {
        //                // Verifica si el tipo de contenido de la respuesta comienza con "image/"
        //                if (response.ContentType.StartsWith("image/"))
        //                {
        //                    return true; // La URL apunta a una imagen
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // Se produjo un error al realizar la solicitud o al obtener la respuesta
        //        // Puedes manejar el error según tus necesidades
        //    }
        //    return false; // La URL no apunta a una imagen o se produjo un error
        //}

        //public static bool IsImageValid(string imagen)
        //{
        //    if (imagen.ToLower().Contains("http") || imagen.ToLower().Contains("https"))
        //    {
        //        try
        //        {

        //            //intenta hacer una solicitud web para ver si la url de la
        //            //imagen es accesible
        //            using (var webClient = new WebClient())
        //            {
        //                using (webClient.OpenRead(imagen))
        //                {

        //                    return true;
        //                }
        //            }

        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }
        //    return false;

        //}

        //public static bool isImageAccesible(string imagenUrl)
        //{
        //    try
        //    {
        //        using (var webClient = new WebClient())
        //        {
        //            //descarga los datos de la imagen
        //            byte[] imageData = webClient.DownloadData(imagenUrl);
        //            //verifica si se pudo descargar datos de la imagen
        //            return imageData.Length > 0;
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        public static bool validaTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return true;
                else
                    return false;

            }

            return false;
        }

        public static void catchEx(Exception ex, HttpContext context)
        {
            context.Session["Error"] = ex.ToString();
            context.Response.Redirect("Error.aspx");
        }
    




    }

    
}
