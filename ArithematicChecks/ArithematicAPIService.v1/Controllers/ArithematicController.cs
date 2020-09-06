using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArithematicLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArithematicAPIService.v1.Controllers
{
    [ApiController]
    public class ArithematicController : ControllerBase
    {
        [HttpPost]
        [Route("Arithematics/Sum")]
        public int Add(ArithematicAdditionRequest additionRequest)
        {
            return Arithematic.Add(additionRequest.A, additionRequest.B);
        }
    }
}
