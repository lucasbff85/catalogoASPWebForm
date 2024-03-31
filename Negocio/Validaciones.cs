using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }

    
}
