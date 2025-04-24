using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TorneoITM.Clases;
using TorneoITM.Models;

namespace TorneoITM.Controllers
{
    [RoutePrefix("api/Torneos")]
    public class TorneoController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public string Ingresar([FromBody] Torneo torneo)
        {
            TorneoITM.Clases.TorneoITM gestor = new TorneoITM.Clases.TorneoITM(); 
            gestor.torneo = torneo;
            return gestor.IngresarTorneo(
                torneo.idAdministradorITM,
                torneo.TipoTorneo,
                torneo.NombreTorneo,
                torneo.NombreEquipo,
                torneo.ValorInscripcion,
                torneo.FechaTorneo,
                torneo.Integrantes
            );
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Torneo torneo)
        {
            TorneoITM.Clases.TorneoITM gestor = new TorneoITM.Clases.TorneoITM();
            return gestor.ActualizarTorneo(
                torneo.idTorneos,
                torneo.TipoTorneo,
                torneo.NombreTorneo,
                torneo.NombreEquipo,
                torneo.ValorInscripcion,
                torneo.FechaTorneo,
                torneo.Integrantes
            );
        }

        [HttpGet]
        [Route("Consultar")]
        public Torneo Consultar(string tipoTorneo, string nombreTorneo, DateTime fecha)
        {
            TorneoITM.Clases.TorneoITM gestor = new TorneoITM.Clases.TorneoITM();
            return gestor.ConsultarTorneo(tipoTorneo, nombreTorneo, fecha);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            TorneoITM.Clases.TorneoITM gestor = new TorneoITM.Clases.TorneoITM();
            return gestor.EliminarTorneo(id);
        }
    }
}