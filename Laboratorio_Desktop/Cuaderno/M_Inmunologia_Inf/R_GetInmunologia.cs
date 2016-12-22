using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_Desktop.Cuaderno.M_Inmunologia_Inf
{
    class R_GetInmunologia
    {
        public static List<RC_Inmunologia> getInmunologia(int consultaID)
        {
            List<RC_Inmunologia> reportes = new List<RC_Inmunologia>();

            try
            {
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {

                    Consulta consulta = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    int idMedico = Convert.ToInt32(consulta.MedicoID);

                    perPersona medico = db.perPersona.Where(c => c.pperCodPer == idMedico).FirstOrDefault();

                    Consulta_Laboratorio consultaLaboratorio = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Trim().Equals("16.1")).FirstOrDefault();

                    Historial_Temporal historia = db.Historial_Temporal.Where(c => c.Codigo == consulta.HistorialID).FirstOrDefault();

                  //  string bioquimico = "Desconocido";
                   // string observacion = "";
                    string observacion;
                    string bioquimico;
                    if (consultaLaboratorio != null)
                    {
                     bioquimico = !string.IsNullOrEmpty(consultaLaboratorio.BioquimicoID.ToString()) ? db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Nombre + " " + db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Apellido_Paterno : "Desconocido";
                     observacion = !string.IsNullOrEmpty(consultaLaboratorio.Observacion) ? consultaLaboratorio.Observacion : "";
                    }
                    
                     
                    foreach (var item in db.M_InmunologiaInf.Where(c => c.ConsultaID == consultaID))
                    {
                        RC_Inmunologia reporte = new RC_Inmunologia();
                        reporte.Nombre = historia.Nombre + " " + historia.Apellido_Paterno + " " + historia.Apellido_Materno;
                        reporte.HC = historia.Codigo;
                        reporte.Edad = (DateTime.Now.Year - historia.Fecha_Nacimiento.Value.Year).ToString();
                        reporte.Sexo = historia.Sexo.ElementAt(0).ToString();
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
                       
                        reporte.NombreExamen = db.Variables.Where(c => c.Codigo== item.Codigo).FirstOrDefault().Nombre;
                         
                        if (item.Codigo.Trim()=="5.1" || item.Codigo.Trim()=="5.22")
                        {
                            
                            if (item.Resul.Trim() == "Reactivo")
                            {
                                reporte.FueraRAngo = item.Resul.Trim();
                                reporte.Valor = item.Valor;
                            }
                            else
                            {
                                
                                reporte.DentroRango = item.Resul.Trim();
                                reporte.Valor = item.Valor;
                            }
                        }
                        else
                        {
                            
                            //double v = Convert.ToDouble(item.Valor);
                            double v = Convert.ToDouble(item.Valor.Replace(',', '.').Trim());
                            if (item.Resul.Trim() == "Positivo")
                            {
                                reporte.FueraRAngo = Convert.ToString(v);
                                reporte.Valor = Convert.ToString(v);
                            }
                            else
                            {
                                reporte.DentroRango =  Convert.ToString(v);
                                reporte.Valor = Convert.ToString(v);
                            }
                        }
                        if (item.Observacion.Trim()=="")
                        {

                        }
                        else
                        {
                            reporte.Observacion = "Observacion: " + item.Observacion;
                        }
                       
                        //reporte.Valor = item.Valor;
                        reporte.Resul = item.Resul.Trim();
                        reporte.TipoMues = item.TipoMues.Trim();
                        reporte.Referencia=item.Referencia.Trim();
                        Bioquimico b = db.Bioquimico.Where(c => c.BioquimicoID == item.BioquimicoID).FirstOrDefault();

                        if (b==null)
                        {
                            reporte.Bioquimico = "Desconocido";
                        }
                        else
                        {
                            reporte.Bioquimico = db.Bioquimico.Where(c => c.BioquimicoID == item.BioquimicoID).FirstOrDefault().Nombre;
                        }
                       // reporte.Bioquimico = !string.IsNullOrEmpty(consultaLaboratorio.BioquimicoID.ToString()) ? db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Nombre + " " + db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Apellido_Paterno : "Desconocido";
                        

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
