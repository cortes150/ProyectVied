using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_Desktop.Cuaderno.M_Otros
{
    public static class R_Otros
    {
        public static List<RC_Ferritina> getHistoria(int consultaID = 67)
        {
            List<RC_Ferritina> reportes = new List<RC_Ferritina>();

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

                    foreach (var item in db.M_Otros.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals("1")))
                    {
                        RC_Ferritina reporte = new RC_Ferritina();
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

                        reporte.Marcador = item.Marcador;

                        if (string.IsNullOrEmpty(item.Resultado))
                        {
                            item.Resultado = "0";
                        }

                        if (item.Valor_Ref.Contains("-"))
                        {
                            char[] va = { '-', '\'' };

                            string[] limite = item.Valor_Ref.Split(va);

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
                            if (item.Valor_Ref.Contains("'"))
                            {
                                string[] limite = item.Valor_Ref.Split('\'');
                                double compar = Convert.ToDouble(item.Resultado.Replace('.', ',').Trim());
                                double compar1 = Convert.ToDouble(limite[1].Replace('.', ',').Replace('=', ' ').Replace('>', ' ').Replace('<', ' ').Trim());

                                if (compar1 <= compar)
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
                        reporte.Observacion = observacion;
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

        public static List<RC_Inmunoglobulina> getInmunologia(int consultaID = 67)
        {

            List<RC_Inmunoglobulina> reportes = new List<RC_Inmunoglobulina>();
            try
            {
                

                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {


                    Consulta consulta = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    int idMedico = Convert.ToInt32(consulta.MedicoID);

                    perPersona medico = db.perPersona.Where(c => c.pperCodPer == idMedico).FirstOrDefault();

                    Consulta_Laboratorio consultaLaboratorio = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Trim().Equals("16.2")).FirstOrDefault();

                    Historial_Temporal historia = db.Historial_Temporal.Where(c => c.Codigo == consulta.HistorialID).FirstOrDefault();

                    string bioquimico = "Desconocido";
                    string observacion = "";

                    if (consultaLaboratorio != null)
                    {
                        bioquimico = !string.IsNullOrEmpty(consultaLaboratorio.BioquimicoID.ToString()) ? db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Nombre + " " + db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Apellido_Paterno : "Desconocido";
                        observacion = !string.IsNullOrEmpty(consultaLaboratorio.Observacion) ? consultaLaboratorio.Observacion : "";
                    }

                    foreach (var item in db.M_Otros.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals("2")))
                    {
                        RC_Inmunoglobulina reporte = new RC_Inmunoglobulina();
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

                        reporte.Marcador = item.Marcador;

                        if (string.IsNullOrEmpty(item.Resultado))
                        {
                            item.Resultado = "0";
                        }

                        if (item.Valor_Ref.Contains("-"))
                        {
                            char[] va = { '-', '\'' };

                            string[] limite = item.Valor_Ref.Split(va);

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
                            if (item.Valor_Ref.Contains("'"))
                            {
                                string[] limite = item.Valor_Ref.Split('\'');
                                double compar = Convert.ToDouble(item.Resultado.Replace('.', ',').Trim());
                                double compar1 = Convert.ToDouble(limite[1].Replace('.', ',').Replace('=', ' ').Replace('>', ' ').Replace('<', ' ').Trim());

                                if (compar1 <= compar)
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
                        reporte.Observacion = observacion;
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
       
        static void ValueDentroFuera(ref RC_Ferritina reporte, string Valor_Ref, string Resultado)
        {

            try
            {
                if (Valor_Ref.Contains("-"))
                {
                    char[] va = { '-', '\'' };

                    string[] limite = Valor_Ref.Split(va);

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
                    if (Valor_Ref.Contains("'"))
                    {
                        string[] limite = Valor_Ref.Split('\'');
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

            }
            catch (Exception)
            {
                
                
            }
        }
    }
}
