using Microsoft.AspNetCore.Mvc;
using MultiplicationTable.Models;
using System;

namespace MultiplicationTable.Controllers {
    [ApiController]
    public class MultiplicationTablesController : ControllerBase {
        private readonly IMultiplyer _multiplyer;

        public MultiplicationTablesController(IMultiplyer multiplyer) {
            _multiplyer = multiplyer;
        }

        [HttpGet("api/multiplication-table")]
        public ActionResult<string[][]> Get(int matrixSize = 10, MatrixBase matrixBase = MatrixBase.Decimal) {
            try {
                return Ok(_multiplyer.GetMultiplicationTable(matrixSize, matrixBase));
            } catch (ArgumentException e) {
                ModelState.AddModelError(nameof(matrixSize), e.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
