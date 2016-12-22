using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_Desktop.Cuaderno.M_Microbiologia
{
    public static class R_GetMicro
    {  

        public static List<RC_Microbilogia> getMicrobiologia(int consultaID = 67)
        {
            List<RC_Microbilogia> reportes = new List<RC_Microbilogia>();

            try
            {
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {

                    Consulta consulta = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    int idMedico = Convert.ToInt32(consulta.MedicoID);

                    perPersona medico = db.perPersona.Where(c => c.pperCodPer == idMedico).FirstOrDefault();

                    Consulta_Laboratorio consultaLaboratorio = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Trim().Equals("1.1")).FirstOrDefault();

                    Historial_Temporal historia = db.Historial_Temporal.Where(c => c.Codigo == consulta.HistorialID).FirstOrDefault();

                    string bioquimico = "Desconocido";
                    string observacion = "";

                    if (consultaLaboratorio != null)
                    {
                        bioquimico = !string.IsNullOrEmpty(consultaLaboratorio.BioquimicoID.ToString()) ? db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Nombre + " " + db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Apellido_Paterno : "Desconocido";
                        observacion = !string.IsNullOrEmpty(consultaLaboratorio.Observacion) ? consultaLaboratorio.Observacion : "";
                    }
                    
                    List<M_Microorganismo> microorganismos = db.M_Microorganismo.Where(c => c.ConsultaID == consultaID).ToList();

                    foreach (var item in microorganismos)
                    {
                        RC_Microbilogia reporte = new RC_Microbilogia();
                        reporte.Nombre = historia.Nombre + " " + historia.Apellido_Paterno + " " + historia.Apellido_Materno;
                        reporte.HC = historia.Codigo;
                        reporte.Edad = (DateTime.Now.Year - historia.Fecha_Nacimiento.Value.Year).ToString();
                        reporte.Sexo = historia.Sexo;
                        reporte.Fecha = consulta.Fecha.Value.ToShortDateString();
                        reporte.NReg = consulta.N_Registro.ToString();
                        reporte.Medico = consulta.Nombre_Medico;
                        string servicio = db.Solicitud.Where(c => c.SolicitudID == consulta.SolicitudID).FirstOrDefault().Nombre;
                        reporte.Servicio = servicio.Equals("(en blanco)") ? "" : servicio;
                        reporte.Bioquimico = bioquimico;
                        if (consulta.Convenio == null)
                        {
                            reporte.Tipo = consulta.Tipo_Paciente;
                        }
                        else
                        {
                            reporte.Tipo = consulta.Convenio;
                        }

                        reporte.NotaGral = !string.IsNullOrEmpty(consultaLaboratorio.Nota) ? consultaLaboratorio.Nota : "";
                        reporte.LabelNotaGral = !string.IsNullOrEmpty(consultaLaboratorio.Nota) ? "Nota Gral.:" : "";
                        reporte.ObservacionGral = !string.IsNullOrEmpty(consultaLaboratorio.Observacion) ? consultaLaboratorio.Observacion : "";
                        reporte.Aclaracion = microorganismos.Count.ToString();

                        reporte.TipoMuestra = !string.IsNullOrEmpty(item.Muestra) ? item.TipoMuestra.Trim() : "";
                        reporte.Muestra = !string.IsNullOrEmpty(item.Muestra) ? item.Muestra : "";
                        reporte.Tincion = !string.IsNullOrEmpty(item.Tincion) ? item.Tincion : "";
                        reporte.Recuento = !string.IsNullOrEmpty(item.Colonia) ? item.Colonia : "";

                        reporte.LabelMuestra = !string.IsNullOrEmpty(item.Muestra) ? "Muestra:" : "";
                        reporte.LabelTincion = !string.IsNullOrEmpty(item.Tincion) ? "Tinción Gram:" : "";
                        reporte.LabelRecuento = !string.IsNullOrEmpty(item.Colonia) ? "Rec. de Colonia:" : "";
                        reporte.LabelObservacionGral = !string.IsNullOrEmpty(reporte.ObservacionGral) ? "Observación Gral:" : "";
                        
                        reporte.Metodo = "Bawer Kirby";
                        reporte.Microorganismo = item.Nombre;

                        if (item.Codigo > 1)
                        {
                            switch (item.Codigo)
                            {
                                case 2:
                                    reporte.Resultado = "Negativo hasta las 48 hrs. de incubación";
                                    reporte.Aclaracion = "0";
                                    break;

                                case 3:
                                    reporte.Resultado =  "Negativo hasta el 7mo día de incubación";
                                    reporte.Aclaracion = "0";
                                    break;

                                case 4:
                                    reporte.Resultado = "Sin desarrollo de patógenos intestinales (salmonella - shigela) ";
                                    reporte.Aclaracion = "0";
                                    break;

                                case 5:
                                    reporte.Resultado = "Desarrollo de microbiota normal";
                                    reporte.Aclaracion = "0";
                                    break;
                                case 6:
                                    reporte.Resultado = "Streptococcus pyogenes: negativo";
                                    reporte.Aclaracion = "0";
                                    break;
                            }
                        }
                        else
                        {
                            reporte.Resultado = "POSITIVO";
                        }
                        List<M_Antibiograma> antibiogramas = db.M_Antibiograma.Where(c => c.ConsultaID == consultaID && c.MicroorganismoID == item.MicroorganismoID).ToList();

                        bool flag = true;

                        foreach (var antibiograma in antibiogramas)
                        {
                            RC_Microbilogia report = new RC_Microbilogia();
                            report.Nombre = reporte.Nombre; 
                            report.HC = reporte.HC;
                            report.Resultado = reporte.Resultado;
                            report.Edad = reporte.Edad; 
                            report.Sexo = reporte.Sexo ;
                            report.Fecha = reporte.Fecha;
                            report.NReg = reporte.NReg;
                            report.Medico = reporte.Medico;                            
                            report.Servicio = reporte.Servicio;
                            report.Bioquimico = reporte.Bioquimico;
                            report.Tipo = reporte.Tipo;                                        
                            report.NotaGral = reporte.NotaGral;
                            report.LabelNotaGral = reporte.LabelNotaGral;
                            report.ObservacionGral = reporte.ObservacionGral; 
                            report.Aclaracion = reporte.Aclaracion;
                            report.Muestra = reporte.Muestra;
                            report.TipoMuestra = reporte.TipoMuestra.Trim() ;
                            report.LabelMuestra = reporte.LabelMuestra;
                            report.Tincion = reporte.Tincion;
                            report.LabelTincion = reporte.LabelTincion;
                            report.LabelRecuento = reporte.LabelRecuento;
                            report.Recuento = reporte.Recuento;    
                            report.Microorganismo = reporte.Microorganismo;

                            report.Nota = !string.IsNullOrEmpty(antibiograma.Nota) ? antibiograma.Nota : "";
                            report.LabelNota = !string.IsNullOrEmpty(report.Nota) ? "Nota:" : "";
                            report.Observacion = !string.IsNullOrEmpty(antibiograma.Observacion) ? antibiograma.Observacion : "";
                            report.LabelObservacion = !string.IsNullOrEmpty(antibiograma.Observacion) ? "Observación:" : "";
                            report.LabelObservacionGral = reporte.LabelObservacionGral;
                            report.Metodo = reporte.Metodo;
                            report.Antibiograma = antibiograma.Antibiotico;
                            report.S = antibiograma.Resultado.Equals("S") ? "X": "-";
                            report.I = antibiograma.Resultado.Equals("I") ? "X" : "-";
                            report.R = antibiograma.Resultado.Equals("R") ? "X" : "-";
                            
                            flag = false;
                            reportes.Add(report);
                        }

                        if (flag)
                        {
                            reportes.Add(reporte);
                        }
                       
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
