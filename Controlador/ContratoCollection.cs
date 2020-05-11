using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClases;


namespace Controlador
{
    public class ContratoCollection
    {
        private static List<Contrato> contratos;
        public ContratoCollection()
        {
                if (contratos == null)
                {
                    contratos = new List<Contrato>();
                }
            }
            public bool Agregar(Contrato co)
            {
                if (existeCliente(co.Numero) == false)
                {
                    contratos.Add(co);
                    return true;
                }
                return false;

            }

            private bool existeCliente(string rut)
            {
                foreach (Contrato item in contratos)
                {
                    if (item.RutCon.Equals(rut))
                    {
                        return true;
                    }

                }
                return false;
            }

            public Contrato BuscarPorRut(String rut)
            {
                foreach (Contrato item in contratos)
                {
                    if (item.RutCon.Equals(rut))
                    {

                        return item;
                    }

                }
                return null;
            }
            public bool Eliminar(String rut)
            {
                foreach (Contrato item in contratos)
                {
                    if (item.RutCon.Equals(rut))
                    {
                        contratos.Remove(item);
                        return true;
                    }

                }
                return false;
            }
            public bool ActualizarCliente(Contrato ncli)
            {
                foreach (Contrato item in contratos)
                {
                    if (item.RutCon.Equals(ncli.RutCon))
                    {
                        contratos.Remove(item);
                        contratos.Add(ncli);
                        return true;
                    }

                }
                return false;
            }
            public List<Contrato> Listar()
            {
                return contratos;
            }

        }
    
    
}
