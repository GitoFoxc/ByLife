using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Tarifador
    {
        public Cliente cliente { get; set; }

        public Tarifador() { }
        public double CalcularPrima()
        {
            double recargo = 0;
            int años = DateTime.Now.Date.Year - cliente.FechaCreacion.Date.Year;
            if (años >= 18 && años <= 25) 
            {
                recargo = recargo+0.036;
            }
            else if (años >= 26 && años <= 45)
            {
                recargo = recargo + 0.024;
            }
            else if (años < 45)
            {
                recargo = recargo + 0.060;
            }
            if (cliente.Sexo.Equals("Masculino"))
            {
                recargo = recargo + 0.024;
            }
            else if (cliente.Sexo.Equals("Femenino"))
            {
                recargo = recargo + 0.012;
            }
            if (cliente.EstadoCivil.Equals("Casado"))
            {
                recargo = recargo + 0.024;
            }
            else if (cliente.EstadoCivil.Equals("Soltero"))
            {
                recargo = recargo + 0.048;
            }
            else
            {
                if (cliente.EstadoCivil.Equals("Viudo") || cliente.EstadoCivil.Equals("Separado"))
                {
                    recargo = recargo + 0.036;
                }
            }


            return recargo;
        }
    }
}
