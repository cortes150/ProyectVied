using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_Desktop.Reportes
{
    public static class R_Cuaderno
    {
        private static DBLaboratorioDataContext db = new DBLaboratorioDataContext();

        public static List<RC_Reporte> getReporteCuaderno(DateTime inicio, DateTime fin)
        {
            List<RC_Reporte> reportes = new List<RC_Reporte>();
  
            int numero = 1;

            foreach (var item in db.Cuadernos)
            {   

                List<Consulta_Laboratorio> consulta = db.Consulta_Laboratorio.Where(c=> c.Codigo.Equals(item.CuadernoID.ToString())).ToList();
                int m = 0;
                int f = 0;
                foreach (var item2 in consulta)
                {
                    Consulta consul = db.Consulta.Where(c => c.ConsultaID == item2.ConsultaID).FirstOrDefault();
                    Historial_Temporal historia = db.Historial_Temporal.Where(c => c.Codigo == consul.HistorialID).FirstOrDefault();

                    if (historia != null)
                    {
                        if (historia.Sexo.StartsWith("Mas"))
                        {
                            m++;
                        }
                        else
                        {
                            f++;
                        } 
                    }


                }

                RC_Reporte reporte = new RC_Reporte();
                reporte.Numero = numero.ToString();
                reporte.Cuaderno = item.Nombre.ToUpper();
                reporte.CantidadM = m.ToString();
                reporte.CantidadF = f.ToString();
                reporte.Inicio = inicio.ToShortDateString();
                reporte.Fin = fin.ToShortDateString();
                ++numero;

                reportes.Add(reporte);                
            }
            

            return reportes;
        }
    }
}
