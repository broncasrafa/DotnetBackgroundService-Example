using Microsoft.AspNetCore.Mvc;
using API.Models.Request;
using API.Services;


namespace API.Controllers;

[Route("api/solicitacoes")]
[ApiController]
public class SolicitacoesController : ControllerBase
{
    private readonly ISolicitacaoService _service;

    public SolicitacoesController(ISolicitacaoService service)
    {
        _service = service;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
        => Ok(await _service.FindByIdAsync(id));

    [HttpGet("user/{idUsuario}")]
    public async Task<IActionResult> GetAllByUserId([FromRoute]int idUsuario) 
        => Ok(await _service.FindAllByUserIdAsync(idUsuario));

    [HttpGet("day")]
    public async Task<IActionResult> GetByDateNow()
        => Ok(await _service.FindAllByDateNowAsync());



    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SolicitacaoRequest request)
        => Ok(await _service.CreateAsync(request));
}
