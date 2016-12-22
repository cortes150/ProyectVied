using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_Desktop.Cuaderno.M_Lepra
{
    public static class R_GetLepra
    {
        public static List<RC_Lepra> getLepra(int consultaID = 67)
        {
            List<RC_Lepra> reportes = new List<RC_Lepra>();

            try
            {
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {

                    Consulta consulta = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    int idMedico = Convert.ToInt32(consulta.MedicoID);

                    perPersona medico = db.perPersona.Where(c => c.pperCodPer == idMedico).FirstOrDefault();

                    Consulta_Laboratorio consultaLaboratorio = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Trim().Equals("16.1")).FirstOrDefault();

                    Historial_Temporal historia = db.Historial_Temporal.Where(c => c.Codigo == consulta.HistorialID).FirstOrDefault();

                    string bioquimico = "Desconocido";
                    string observacion = "";

                    if (consultaLaboratorio != null)
                    {
                        bioquimico = !string.IsNullOrEmpty(consultaLaboratorio.BioquimicoID.ToString()) ? db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Nombre + " " + db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Apellido_Paterno : "Desconocido";
                        observacion = !string.IsNullOrEmpty(consultaLaboratorio.Observacion) ? consultaLaboratorio.Observacion : "";
                    }

                    foreach (var item in db.T_Lepra.Where(c => c.ConsultaID == consultaID))
                    {
                        RC_Lepra reporte = new RC_Lepra();
                        reporte.Nombre = historia.Nombre + " " + historia.Apellido_Paterno + " " + historia.Apellido_Materno;
                        reporte.HC = historia.Codigo;
                        reporte.Edad = (DateTime.Now.Year - historia.Fecha_Nacimiento.Value.Year).ToString();
                        reporte.Sexo = historia.Sexo;
                        reporte.Fecha = consulta.Fecha.Value.ToShortDateString();
                        reporte.NReg = consulta.N_Registro.ToString();
                        reporte.Medico = consulta.Nombre_Medico;

                        if (consulta.Convenio == null)
                        {
                            reporte.Tipo = consulta.Tipo_Paciente;
                        }
                        else
                        {
                            reporte.Tipo = consulta.Convenio;
                        }

                        string servicio = db.Solicitud.Where(c => c.SolicitudID == consulta.SolicitudID).FirstOrDefault().Nombre;
                        reporte.Servicio = servicio.Equals("(en blanco)") ? "" : servicio;

                        reporte.Marcador = "LEPRA";

                        if (string.IsNullOrEmpty(item.Resultado))
                        {
                            item.Resultado = " ";
                        }

                        reporte.Resultado = item.Resultado;

                        reporte.Bioquimico = bioquimico;

                        reportes.Add(reporte);
                    }

                    return reportes;
                }
            }
            catch (Exception)
            {      
                return reportes;
            }
        }
    }
}
