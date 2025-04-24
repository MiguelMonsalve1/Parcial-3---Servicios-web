using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TorneoITM.Models;

namespace TorneoITM.Clases
{
    public class TorneoITM
    {
        ///Objeto para manipular la base de datos
        private TorneoITMEntities dbsuper = new TorneoITMEntities();

        ///Propiedades que necesitamos para el código

        public Torneo torneo { get; set; }

        public AdministradorITM admin { get; set; }


        //Aquí ya van los métodos que necesitamos hacer (insertar torneos y eso)

        public string IngresarTorneo(int idAdministrador, string tipoTorneo, string nombreTorneo, string nombreEquipo, int valorInscripcion, DateTime fecha, string integrantes)
        {
            try
            {

                torneo.idAdministradorITM = idAdministrador;
                torneo.TipoTorneo = tipoTorneo;
                torneo.NombreTorneo = nombreTorneo;
                torneo.NombreEquipo = nombreEquipo;
                torneo.ValorInscripcion = valorInscripcion;
                torneo.FechaTorneo = fecha;
                torneo.Integrantes = integrantes;

                dbsuper.Torneos.Add(torneo);
                dbsuper.SaveChanges();

                return "El torneo del ITM se registró con éxito";

            }
            catch (Exception ex)
            {
                Exception innermost = ex;
                string detailedMessage = ex.Message;

                while (innermost.InnerException != null)
                {
                    innermost = innermost.InnerException;
                    detailedMessage += " -> " + innermost.Message;
                }

                return "El error al ingresar el torneo fue: " + detailedMessage;
            }

        }

        public string ActualizarTorneo(int id, string tipoTorneo, string nombreTorneo, string nombreEquipo, int valorInscripcion, DateTime fecha, string integrantes)
        {

            try
            {
                torneo = dbsuper.Torneos.FirstOrDefault(t => t.idTorneos == id);
                if (torneo == null)
                {
                    return "El torneo no existe";
                }
                else
                {
                    torneo.TipoTorneo = tipoTorneo;
                    torneo.NombreTorneo = nombreTorneo;
                    torneo.NombreEquipo = nombreEquipo;
                    torneo.ValorInscripcion = valorInscripcion;
                    torneo.FechaTorneo = fecha;
                    torneo.Integrantes = integrantes;

                    dbsuper.SaveChanges();
                    return "Se actualizó el torneo correctamente";
                }



            }
            catch (Exception ex)
            {
                return "El error al actualizar el torneo fue: " + ex.Message;
            }
        }

        public Models.Torneo ConsultarTorneo(string tipoTorneo, string nombreTorneo, DateTime fecha)
        {
            return dbsuper.Torneos.FirstOrDefault(p => p.TipoTorneo == tipoTorneo && p.NombreTorneo == nombreTorneo && p.FechaTorneo == fecha);
        }

        public string EliminarTorneo(int id)
        {
            try
            {

                torneo = dbsuper.Torneos.FirstOrDefault(t => t.idTorneos == id);

                if (torneo == null)
                {
                    return "El torneo no existe";
                }

                dbsuper.Torneos.Remove(torneo);
                dbsuper.SaveChanges();

                return "El torneo se eliminó correctamente";
            }
            catch (Exception ex)
            {
                return "El error al eliminar el torneo fue: " + ex.Message;
            }
        }
    }
}