using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Cliente
    {
        private String _rut;

        public String Rut
        {
            get { return _rut; } //campo
            set {
                if(value.Length==10)
                {
                    _rut = value;
                }
                else
                {
                    throw new Exception("Rut Incorrecto");
                }
            }
        }
        private String _nombre; //campo

        public String Nombre
        {
            get { return _nombre; }
            set{
                if (value.Length <= 20 && value.Length > 0) { 
                    _nombre = value;
                }
                else
                {
                    if (value.Length>20)
                    {
                        throw new Exception("Nombre Demasiado Largo.");
                    }
                    else if (value.Length==0)
                    {
                        throw new Exception("El Nombre debe ser Obligatorio.");
                    }
                    
                }
            }
        }
        private String _apellido; //campo

        public String Apellido
        {
            get { return _apellido; }
            set { if(value.Length<=20&&value.Length>0)
                {
                    _apellido = value;
                }
                else
                {
                    if (value.Length > 20)
                    {
                        throw new Exception("Apellido Demasiado Largo.");
                    }
                    else if (value.Length == 0)
                    {
                        throw new Exception("El Apellido es Obligatorio.");
                    }
                }
            }

        }

        private DateTime _fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set {
                DateTime hoy = DateTime.Now.Date;
                DateTime fecha_ingreso = value;
                int anos = hoy.Year - fecha_ingreso.Year;
                if (anos>18)
                {
                    _fechaCreacion = value;
                }
                else
                {
                    throw new Exception(String.Format("Es menor de Edad, ya que posee {0} años. Usted ingreso {1}", anos, fecha_ingreso));
                }

            }   
        }

        public TipoSexo Sexo { get; set; }
        public TipoEstadoCivil EstadoCivil { get; set; }
    }
}
