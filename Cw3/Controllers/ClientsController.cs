using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        [HttpDelete("{idClient")]
        public async Task<IActionResult> DeleteClient([FromRoute] int idClient)
        {
            try
            {
                await DeleteClient(idClient);
                return Ok($"Client ID: {idClient} deleted");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
