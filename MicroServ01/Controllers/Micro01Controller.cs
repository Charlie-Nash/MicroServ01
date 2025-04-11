using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MicroServ01.Application.Interfaces;
using MicroServ01.Domain.Models;

[ApiController]
[Route("api/v1/micro01")]
public class Micro01Controller : ControllerBase
{
    private readonly ITablaService _tablaService;

    public Micro01Controller(ITablaService authService)
    {
        _tablaService = authService;
    }

    [HttpPost("listado")]
    public async Task<IActionResult> Listado([FromBody] TablaRequest request)
    {
        var listado = await _tablaService.ListadoAsync(request);

        return Ok(listado);
    }
}