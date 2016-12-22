using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_Desktop.Cuaderno.Mb_Sanguinea
{
    class R_GetSanguineo
    {
        public static List<RC_Sanguineo> getHistoria(int consultaID)
        {
            List<RC_Sanguineo> reportes = new List<RC_Sanguineo>();
            try
            {

                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {

                    Consulta consulta = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    int idMedico = Convert.ToInt32(consulta.MedicoID);

                    perPersona medico = db.perPersona.Where(c => c.pperCodPer == idMedico).FirstOrDefault();

                    Consulta_Laboratorio consultaLaboratorio = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Trim().Equals("2")).FirstOrDefault();

                    Historial_Temporal historia = db.Historial_Temporal.Where(c => c.Codigo == consulta.HistorialID).FirstOrDefault();

                    string bioquimico = "Desconocido";
                    string observacion = "";

                    if (consultaLaboratorio != null)
                    {
                        bioquimico = !string.IsNullOrEmpty(consultaLaboratorio.BioquimicoID.ToString()) ? db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Nombre + " " + db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Apellido_Paterno : "Desconocido";
                        observacion = !string.IsNullOrEmpty(consultaLaboratorio.Observacion) ? consultaLaboratorio.Observacion : "";
                    }
                    List<M_Sanguinea> me = db.M_Sanguinea.Where(c => c.ConsultaID == consultaID).ToList();

                    foreach (var item in me)
                    {
                        RC_Sanguineo reporte = new RC_Sanguineo();
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

                       
                        var sang = db.SubCategoria.Where(x => x.Codigo == item.Codigo).FirstOrDefault().Descripcion;
                        reporte.Marcador = db.SubCategoria.Where(x => x.Codigo == item.Codigo).FirstOrDefault().Nombre ;
                        if (string.IsNullOrEmpty(item.Valor))
                        {
                            item.Valor = "0";
                        }

                        if (sang.Contains("-"))
                        {
                            char[] va = { '-', '\'' };

                            string[] limite = sang.Split(va);

                            double compar = Convert.ToDouble(item.Valor.Replace('.', ',').Trim());
                            double compar1 = Convert.ToDouble(limite[0].Replace('.', ',').Trim());
                            string[] limite2 = limite[1].Split(' ');
                            double compar2 = Convert.ToDouble(limite2[0].Replace('.', ',').Trim());

                            if (compar1 <= compar && compar2 >= compar)
                            {
                                reporte.Resultado_D = item.Valor;
                            }
                            else
                            {
                                reporte.Resultado_F = item.Valor;
                            }
                        }
                        else
                        {
                            if (sang.Contains("'"))
                            {
                                string[] limite = sang.Split('\'');
                                double compar = Convert.ToDouble(item.Valor.Replace('.', ',').Trim());
                                double compar1 = Convert.ToDouble(limite[1].Replace('.', ',').Replace('=', ' ').Replace('>', ' ').Replace('<', ' ').Trim());

                                if (compar <= compar1)
                                {
                                    reporte.Resultado_D = item.Valor;
                                }
                                else
                                {
                                    reporte.Resultado_F = item.Valor;
                                }
                            }
                        }

                        reporte.Val_Ref = sang;
                        
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
