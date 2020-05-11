using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClases;


namespace Controlador
{
    public class ClientesCollection : List<Cliente>
    {
        private static List<Cliente> clientes;

        public ClientesCollection()
        {
            if (clientes == null)
            {
                clientes = new List<Cliente>();
            }
        }
        public bool Agregar(Cliente cli) {
            if (existeCliente(cli.Rut)==false)
            {
                clientes.Add(cli);
                return true;
            }
            return false;

        }

        private bool existeCliente(string rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(rut))
                {
                    return true;
                }
                
            }
            return false;
        }

        public Cliente BuscarPorRut(String rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(rut))
                {
                    
                    return item;
                }

            }
            return null;
        }
        public bool Eliminar(String rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(rut))
                {
                    clientes.Remove(item);
                    return true;
                }

            }
            return false;
        }
        public bool ActualizarCliente(Cliente ncli)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(ncli.Rut))
                {
                    clientes.Remove(item);
                    clientes.Add(ncli);
                    return true;
                }

            }
            return false;
        }
        public List<Cliente> Listar()
        {
            return clientes;
        }
        
    }
}
