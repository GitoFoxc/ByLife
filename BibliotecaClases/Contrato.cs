using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Contrato : Tarifador
    {
        private String _numero;
        public String Numero
        {
            get { return _numero; }
            set
            {
                if (value.Length==0)
                {
                    DateTime hoy = DateTime.Now.Date;
                    _numero = value;
                }
                else
                {
                    throw new Exception("Debe ingresar un Numero.");
                }
            }
        }

        public DateTime FechaCreacionContrato { get; set; }
        private String _rutCon;
        public String RutCon
        {
            get { return _rutCon; }
            set
            {
                if (value.Length == 10)
                {
                    _rutCon = value;
                }
                else
                {
                    throw new Exception("Rut Incorrecto");
                }
            }
        }
        public Plan Plan { get; set; }
        private DateTime _fechaIniVigencia;
        public DateTime FechaIniVigencia
        {
            get { return _fechaIniVigencia; }
            set
            {
                DateTime fecIni = DateTime.Now.Date;
                DateTime fecTer = DateTime.Now.AddDays(30).Date;
                if (value >= fecIni && value <= fecTer)
                {
                    _fechaIniVigencia = value;
                }
                else
                {
                    throw new Exception("Fecha Incorrecta");
                }
            }
        }
        public DateTime FechaFinVigencia { get; set; }
        public bool Vigente { get; set; }
        public bool DeclaracionSalud { get; set; }
        public float PrimaAnual { get; set; }
        public float PrimaMensual { get; set; }
        private String _observaciones;

        public Cliente Cliente { get; set; }
        public String Observaciones
        {
            get { return _observaciones; }
            set
            {
                if (value.Trim().Length>0)
                {
                    _observaciones = value;
                }
                else
                {
                    throw new Exception("No se olvide de sus Observaciones");
                }
                
            }
        }
        public double CalcularPrimaAnual()
        {
            this.Cliente = Cliente;
            double pba = this.CalcularPrimaAnual();
            pba = pba + Plan.PrimaBase;
            return pba;
        }




    }
}
