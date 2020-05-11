using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClases;

namespace Controlador
{
    public class DaoPlan
    {
        private List<Plan> lista_plan = new List<Plan>();
        public DaoPlan()
        {
            Plan p1 = new Plan()
            {
                IdPlan = "VID01",
                Nombre = "Vida Inicial",
                PolizaActual = "POL120113229",
                PrimaBase = float.Parse("0.5")
            };
            Plan p2 = new Plan()
            {
                IdPlan = "VID02",
                Nombre = "Vida Total",
                PolizaActual = "POL120648575",
                PrimaBase = float.Parse("3.5")
            };
            Plan p3 = new Plan()
            {
                IdPlan = "VID03",
                Nombre = "Vida Conductor",
                PolizaActual = "POL125235079",
                PrimaBase = float.Parse("1.2")
            };
            Plan p4 = new Plan()
            {
                IdPlan = "VID04",
                Nombre = "Vida Senior",
                PolizaActual = "POL120100054",
                PrimaBase = float.Parse("2.0")
            };
            Plan p5 = new Plan()
            {
                IdPlan = "VID05",
                Nombre = "Vida Ahorro",
                PolizaActual = "POL120500489",
                PrimaBase = float.Parse("3.5")
            };
        }
        public List<Plan> ReadAll()
        {
            return lista_plan;
        }
        public Plan Read(string idPlan)
        {
            return lista_plan.Where(p => p.IdPlan.Equals(idPlan)).First();
        }
    }
}
