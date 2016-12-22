using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_Desktop.Cuaderno.M_Marcador_Tumoral
{
    public static class R_GetMarTum
    {  
        
        public static List<RC_MarTum> getHistoria(int consultaID = 67)
        {
            List<RC_MarTum> reportes = new List<RC_MarTum>();
            try
            {

                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {

                    Consulta consulta = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    int idMedico = Convert.ToInt32(consulta.MedicoID);

                    perPersona medico = db.perPersona.Where(c => c.pperCodPer == idMedico).FirstOrDefault();

                    Consulta_Laboratorio consultaLaboratorio = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Trim().Equals("13")).FirstOrDefault();

                    Historial_Temporal historia = db.Historial_Temporal.Where(c => c.Codigo == consulta.HistorialID).FirstOrDefault();

                    string bioquimico = "Desconocido";
                    string observacion = "";

                    if (consultaLaboratorio != null)
                    {
                        bioquimico = !string.IsNullOrEmpty(consultaLaboratorio.BioquimicoID.ToString()) ? db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Nombre + " " + db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Apellido_Paterno : "Desconocido";
                        observacion = !string.IsNullOrEmpty(consultaLaboratorio.Observacion) ? consultaLaboratorio.Observacion : "";
                    }

                    foreach (var item in db.T_MarcadorTumoral.Where(c => c.ConsultaID == consultaID))
                    {
                        RC_MarTum reporte = new RC_MarTum();
                        reporte.Nombre = historia.Nombre + " " + historia.Apellido_Paterno + " " + historia.Apellido_Materno;
                        reporte.HC = historia.Codigo;
                        reporte.Edad = (DateTime.Now.Year - historia.Fecha_Nacimiento.Value.Year).ToString();
                        reporte.Sexo = historia.Sexo;
                        reporte.Fecha = consulta.Fecha.Value.ToShortDateString();
                        reporte.Hora = consulta.Fecha.Value.TimeOfDay.ToString();
                        DateTime entrada = consulta.Fecha.Value;
                        DateTime salida = entrada.AddHours(24);
                        reporte.Hora = salida.ToString("hh:mm tt");
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

                        reporte.Marcador = item.Marcador;

                        if (string.IsNullOrEmpty(item.Resultado))
                        {
                           item.Resultado = "0";
                        }

                        if (item.Val_Ref.Contains("-"))
                        {
                            char[] va = { '-', '\'' };

                            string[] limite = item.Val_Ref.Split(va);

                            double compar = Convert.ToDouble(item.Resultado.Replace('.', ',').Trim());
                            double compar1 = Convert.ToDouble(limite[1].Replace('.', ',').Trim());
                            double compar2 = Convert.ToDouble(limite[2].Replace('.', ',').Trim());

                            if (compar1 <= compar && compar2 >= compar)
                            {
                                reporte.Resultado_D = item.Resultado;
                            }
                            else
                            {
                                reporte.Resultado_F = item.Resultado;
                            }
                        }
                        else
                        {
                            if (item.Val_Ref.Contains("'"))
                            {
                                string[] limite = item.Val_Ref.Split('\'');
                                double compar = Convert.ToDouble(item.Resultado.Replace('.', ',').Trim());
                                double compar1 = Convert.ToDouble(limite[1].Replace('.', ',').Replace('=', ' ').Replace('>', ' ').Replace('<', ' ').Trim());

                                if (compar <= compar1)
                                {
                                    reporte.Resultado_D = item.Resultado;
                                }
                                else
                                {
                                    reporte.Resultado_F = item.Resultado;
                                }
                            }
                        }

                        reporte.Val_Ref = item.Intervalo;
                        reporte.Unidad = item.Unidad;
                        if (observacion.Trim() == "")
                        {

                        }
                        else
                        {
                            reporte.Observacion = "Observacion: " + observacion;
                        }
                       //reporte.Observacion = observacion;
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
