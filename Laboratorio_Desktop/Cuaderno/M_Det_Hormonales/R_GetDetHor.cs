using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_Desktop.Cuaderno.M_Det_Hormonales
{
    public static class R_GetDetHor
    {  
      
        public static List<RC_DetHor> getHistoria(int consultaID = 67)
        {
            List<RC_DetHor> reportes = new List<RC_DetHor>();

            try
            {
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {

                    Consulta consulta = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    int idMedico = Convert.ToInt32(consulta.MedicoID);

                    perPersona medico = db.perPersona.Where(c => c.pperCodPer == idMedico).FirstOrDefault();

                    Consulta_Laboratorio consultaLaboratorio = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Trim().Equals("3")).FirstOrDefault();

                    Historial_Temporal historia = db.Historial_Temporal.Where(c => c.Codigo == consulta.HistorialID).FirstOrDefault();

                    string bioquimico = "Desconocido";
                    string observacion = "";

                    if (consultaLaboratorio != null)
                    {
                        bioquimico = !string.IsNullOrEmpty(consultaLaboratorio.BioquimicoID.ToString()) ? db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Nombre + " " + db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Apellido_Paterno : "Desconocido";
                        observacion = !string.IsNullOrEmpty(consultaLaboratorio.Observacion) ? consultaLaboratorio.Observacion : "";
                    }

                   // var lis = db.M_DetHormonales.Where(c => c.ConsultaID == consultaID);

                    foreach (var item in db.M_DetHormonales.Where(c => c.ConsultaID == consultaID))
                    {
                        RC_DetHor reporte = new RC_DetHor();
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
                        //Solicitud solicitud = db.Solicitud.Where(c => c.SolicitudID == consulta.SolicitudID).FirstOrDefault();
                        string servicio = db.Solicitud.Where(c => c.SolicitudID == consulta.SolicitudID).FirstOrDefault().Nombre;
                        reporte.Servicio = servicio.Equals("(en blanco)") ? "" : servicio;

                        reporte.Marcador = item.Marcador;

                        ValueDentroFuera(ref reporte, item.Valor_Ref, item.Resultado);

                        
                        reporte.Val_Ref = item.Intervalo;
                        reporte.Unidad = item.Unidad;
                        if (observacion.Trim() == "")
                        {

                        }
                        else
                        {
                            reporte.Observacion = "Observacion: " + observacion;
                        }
                       // reporte.Observacion = observacion;
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

        static void ValueDentroFuera(ref RC_DetHor reporte, string Valor_Ref, string Resultado)
        {


            try
            {
                if (string.IsNullOrEmpty(Resultado))
                {
                    Resultado = "0";
                }
                
                if (Valor_Ref.Contains("-"))
                {
                    char[] va = { '-', '\'' };

                    string[] limite = Valor_Ref.Split(va);

                    if (limite[1].Contains(".") && limite[2].Contains("."))
                    {
                        double compar = Convert.ToDouble(Resultado.Replace('.', ',').Trim());
                        double compar1 = Convert.ToDouble(limite[1].Replace('.', ',').Trim());
                        double compar2 = Convert.ToDouble(limite[2].Replace('.', ',').Trim());

                        if (compar1 <= compar && compar2 >= compar)
                        {
                            reporte.Resultado_D = Resultado;
                        }
                        else
                        {
                            reporte.Resultado_F = Resultado;
                        }
                    }
                    else
                    {
                        double compar = Convert.ToDouble(Resultado.Trim());
                        double compar1 = Convert.ToDouble(limite[1].Trim());
                        double compar2 = Convert.ToDouble(limite[2].Trim());

                        if (compar1 <= compar && compar2 >= compar)
                        {
                            reporte.Resultado_D = Resultado;
                        }
                        else
                        {
                            reporte.Resultado_F = Resultado;
                        }
                    }

                }
                else
                {
                    if (Valor_Ref.Contains("'"))
                    {
                        string[] limite = Valor_Ref.Split('\'');
                        if (limite[1].Contains("."))
                        {
                            double compar = Convert.ToDouble(Resultado.Replace('.', ',').Trim());
                            double compar1 = Convert.ToDouble(limite[1].Replace('.', ',').Trim());

                            if (compar1 == compar)
                            {
                                reporte.Resultado_D = Resultado;
                            }
                            else
                            {
                                reporte.Resultado_F = Resultado;
                            }
                        }
                        else
                        {
                            double compar = Convert.ToDouble(Resultado.Trim());
                            double compar1 = Convert.ToDouble(limite[1].Trim());

                            if (compar1 == compar)
                            {
                                reporte.Resultado_D = Resultado;
                            }
                            else
                            {
                                reporte.Resultado_F = Resultado;
                            }
                        }
                    }
                    else
                    {
                        int compar = Convert.ToInt32(Valor_Ref.Trim());
                        if (compar == 1)
                        {
                            reporte.Resultado_D = Resultado;
                        }
                        else
                        {
                            reporte.Resultado_F = Resultado;
                        }
                    }


                }

                //return reporte;
            }
            catch (Exception)
            {
                
                 
            }
        }
    }
}
