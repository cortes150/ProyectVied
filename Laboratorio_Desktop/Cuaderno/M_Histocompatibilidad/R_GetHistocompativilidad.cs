using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_Desktop.Cuaderno.M_Histocompatibilidad
{
    class R_GetHistocompativilidad
    {
        public static List<RC_Histocompativilidad> getHistocompativilidad(int consultaID)
        {
            List<RC_Histocompativilidad> reportes = new List<RC_Histocompativilidad>();
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
                    bool band = true;
                    if (consultaLaboratorio != null)
                    {
                        bioquimico = !string.IsNullOrEmpty(consultaLaboratorio.BioquimicoID.ToString()) ? db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Nombre + " " + db.Bioquimico.Where(c => c.BioquimicoID == consultaLaboratorio.BioquimicoID).FirstOrDefault().Apellido_Paterno : "Desconocido";
                        observacion = !string.IsNullOrEmpty(consultaLaboratorio.Observacion) ? consultaLaboratorio.Observacion : "";
                    }
                    foreach (var item in db.M_Histocompatibilida.Where(c => c.ConsultaID == consultaID))
                    {
                        RC_Histocompativilidad reporte = new RC_Histocompativilidad();
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


                        if (band == true)
                        {


                           
                            reporte.nombre_donante = item.Nom_donante;
                            //reporte.interpretacion = item.Valor_Ref;


                            if (item.Codigo == "9.1")
                            {


                                reporte.G_nombre = db.Variables.Where(c => c.Codigo == "9.1").FirstOrDefault().Nombre;
                                reporte.Alo_Cross1T = item.Alo_Cross1T.TrimStart().TrimEnd();
                                reporte.nom_linfocitos_1 = verificacionLinfocitosSimbolos(item.Alo_Cross1T, false);
                                reporte.dettale_linfocitos_1 = verificacionLinfocitosSimbolos(item.Alo_Cross1T, true);

                                reporte.Alo_Cross1B = item.Alo_Cross1B.TrimStart().TrimEnd();
                                reporte.nom_linfocitos_2 = verificacionLinfocitosSimbolos(item.Alo_Cross1B, false);
                                reporte.dettale_linfocitos_2 = verificacionLinfocitosSimbolos(item.Alo_Cross1B, true);
                                reporte.Alo_Cross2T = item.Alo_Cross2T.TrimStart().TrimEnd();
                                reporte.nom_linfocitos_3 = verificacionLinfocitosSimbolos(item.Alo_Cross2T, false);
                                reporte.dettale_linfocitos_3 = verificacionLinfocitosSimbolos(item.Alo_Cross2T, true);
                                reporte.AloCross2B = item.AloCross2B.TrimStart().TrimEnd();
                                reporte.nom_linfocitos_4 = verificacionLinfocitosSimbolos(item.AloCross2B, false);
                                reporte.dettale_linfocitos_4 = verificacionLinfocitosSimbolos(item.AloCross2B, true);
                                if (item.Valor_Ref != null)
                                {
                                    
                                    reporte.interpretacion = item.Valor_Ref;
                                    reporte.nomInterpretacion1 = "Interpretación:";

                                }
                                else
                                {
                                    reporte.interpretacion = null;
                                   
                                }
                            }


                            //reporte.intercambio = db.M_Histocompatibilida.Where(c => c.Codigo ==   ).FirstOrDefault().Nombre; 
                            if (item.Codigo2 == "9.2")
                            {
                                if (item.Nota2 != null)
                                {
                                    reporte.nota2 = item.Nota2;
                                    reporte.nom_nota2 = "Nota:";

                                }
                                else
                                {
                                    reporte.nota2 = null;
                                    reporte.nom_nota2 = "";
                                }
                                if (item.interpretacion != null &&item.interpretacion!="")
                                {
                                    reporte.interpretacion2 = item.interpretacion;
                                    
                                    reporte.nominterpre2 = "Interpretación:";

                                }
                                else
                                {
                                    reporte.nominterpre2 = "";
                                }
                                reporte.G_nombre2 = db.Variables.Where(c => c.Codigo == "9.2").FirstOrDefault().Nombre;

                              //  reporte.hla_a = db.Variables_Cristal.Where(c => c.Codigo == "9.11").FirstOrDefault().Nombre;
                              //  reporte.hla_b = db.Variables_Cristal.Where(c => c.Codigo == "9.12").FirstOrDefault().Nombre;
                               // reporte.hla_c = db.Variables_Cristal.Where(c => c.Codigo == "9.13").FirstOrDefault().Nombre;
                               // reporte.hla_dr = db.Variables_Cristal.Where(c => c.Codigo == "9.14").FirstOrDefault().Nombre;
                                reporte.GD_hla1 = item.GD_Hla_a1;
                                reporte.GD_hlb1 = item.GD_Hla_b1;
                                reporte.GD_hlb1_1 = item.GD_Hla_b1_1;
                                reporte.GD_hlc1 = item.GD_Hla_c1;
                                reporte.GD_hl_dra1 = item.GD_Hla_dra1;
                                reporte.GD_hl_drb1 = item.GD_Hla_drb1;
                                reporte.GD_hla2 = item.GD_Hla_a2;
                                reporte.GD_hlb2 = item.GD_Hla_b2;
                                reporte.GD_hlb2_2 = item.GD_Hla_b2_2;
                                reporte.GD_hlc2 = item.GD_Hla_c2;
                                reporte.GD_hl_dra2 = item.GD_Hla_dra2;
                                reporte.GD_hl_drb2 = item.GD_Hla_drb2;

                                reporte.GR_hla1 = item.GR_Hla_a1;
                                reporte.GR_hlb1 = item.GR_Hla_b1;
                                reporte.GR_hlb1_1 = item.GR_Hla_b1_1;
                                reporte.GR_hlc1 = item.GR_Hla_c1;
                                reporte.GR_hl_dra1 = item.GR_Hla_dra1;
                                reporte.GR_hl_drb1 = item.GR_Hla_drb1;
                                reporte.GR_hla2 = item.GR_Hla_a2;
                                reporte.GR_hlb2 = item.GR_Hla_b2;
                                reporte.GR_hlb2_2 = item.GR_Hla_b2_2;
                                reporte.GR_hlc2 = item.GR_Hla_c2;
                                reporte.GR_hl_dra2 = item.GR_Hla_dra2;
                                reporte.GR_hl_drb2 = item.GR_Hla_drb2;
                            }

                            band = false;
                        }



                        //reporte.NombreExamen = db.Variables.Where(c => c.Codigo == item.Codigo).FirstOrDefault().Nombre;

                        //if (item.Codigo.Trim() == "5.1" || item.Codigo.Trim() == "5.22")
                        //{

                        //    if (item.Resul.Trim() == "Reactivo")
                        //    {
                        //        reporte.FueraRAngo = item.Resul.Trim();
                        //        reporte.Valor = item.Valor;
                        //    }
                        //    else
                        //    {

                        //        reporte.DentroRango = item.Resul.Trim();
                        //        reporte.Valor = item.Valor;
                        //    }
                        //}
                        //else
                        //{

                        //    //double v = Convert.ToDouble(item.Valor);
                        //    double v = Convert.ToDouble(item.Valor.Replace(',', '.').Trim());
                        //    if (item.Resul.Trim() == "Positivo")
                        //    {
                        //        reporte.FueraRAngo = Convert.ToString(v);
                        //        reporte.Valor = Convert.ToString(v);
                        //    }
                        //    else
                        //    {
                        //        reporte.DentroRango = Convert.ToString(v);
                        //        reporte.Valor = Convert.ToString(v);
                        //    }
                        //}
                        //if (item.Observacion.Trim() == "")
                        //{

                        //}
                        //else
                        //{
                        //    reporte.Observacion = "Observacion: " + item.Observacion;
                        //}

                        ////reporte.Valor = item.Valor;
                        //reporte.Resul = item.Resul.Trim();
                        //reporte.TipoMues = item.TipoMues.Trim();
                        //reporte.Referencia = item.Referencia.Trim();
                        //Bioquimico b = db.Bioquimico.Where(c => c.BioquimicoID == item.BioquimicoID).FirstOrDefault();

                        //if (b == null)
                        //{
                        //    reporte.Bioquimico = "Desconocido";
                        //}
                        //else
                        //{
                        //    reporte.Bioquimico = db.Bioquimico.Where(c => c.BioquimicoID == item.BioquimicoID).FirstOrDefault().Nombre;
                        //}
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
        #region verificacion de linfocitos simbolos 
        private static string verificacionLinfocitosSimbolos(string variable, bool band)
        {

            if (band == true)
            {


                if (variable.TrimStart().TrimEnd().Equals("-"))
                {
                    return "Del 0 al 10% de citotoxicidad = (-) Negativo";
                }
                if (variable.TrimStart().TrimEnd().Equals("+/-"))
                {
                    return "Del 11 al 20% de citotoxicidad = (+/-) Dudoso";
                }
                if (variable.TrimStart().TrimEnd().Equals("+"))
                {
                    return "Del 21 al 50% de citotoxicidad = (+) Débil Positivo";
                }
                if (variable.TrimStart().TrimEnd().Equals("++"))
                {
                    return "Del 51 al 80% de citotoxicidad = (++) Positivo";
                }
                if (variable.TrimStart().TrimEnd().Equals("+++"))
                {
                    return "Del 81 al 100% de citotoxicidad = (+++) Positivo Fuerte";
                }
            }
            else
            {
                if (variable.TrimStart().TrimEnd().Equals("-"))
                {
                    return "Negativo";
                }
                if (variable.TrimStart().TrimEnd().Equals("+/-"))
                {
                    return "Dudoso";
                }
                if (variable.TrimStart().TrimEnd().Equals("+"))
                {
                    return "Débil Positivo";
                }
                if (variable.TrimStart().TrimEnd().Equals("++"))
                {
                    return "Positivo";
                }
                if (variable.TrimStart().TrimEnd().Equals("+++"))
                {
                    return "Positivo Fuerte";
                }
            }
            return "Vacio";
        }
        #endregion
    }
}