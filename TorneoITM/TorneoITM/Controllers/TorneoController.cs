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
        public string Ingresar([FromBody] Torneos torneo)
        {
            Torneo gestor = new Torneo();
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
        public string Actualizar([FromBody] Torneos torneo)
        {
            Torneo gestor = new Torneo();
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
        public Torneos Consultar(string tipoTorneo, string nombreTorneo, DateTime fecha)
        {
            Torneo gestor = new Torneo();
            return gestor.ConsultarTorneo(tipoTorneo, nombreTorneo, fecha);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            Torneo gestor = new Torneo();
            return gestor.EliminarTorneo(id);
        }
    }
}
