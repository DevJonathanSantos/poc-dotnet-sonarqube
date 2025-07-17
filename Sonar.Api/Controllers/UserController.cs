using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sonar.Application.UseCases.User;

namespace Sonar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Buscando usuário com id {Id}", id);
            var user = await _mediator.Send(new GetUserQuery(id));
            if (user == null)
            {
                _logger.LogWarning("Usuário com id {Id} não encontrado", id);
                return NotFound();
            }
            _logger.LogInformation("Usuário encontrado: {@User}", user);
            return Ok(user);
        }

        [HttpGet()]
        public async Task<IActionResult> List()
        {
            _logger.LogInformation("Buscando usuários");
            var users = await _mediator.Send(new ListUsersQuery());
            if (users == null)
            {
                _logger.LogWarning("Usuários não encontrados");
                return NotFound();
            }
            _logger.LogInformation("Usuários encontrado: {@User}", users);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto dto)
        {
            _logger.LogInformation("Criando usuário: {@UserDto}", dto);
            var created = await _mediator.Send(new CreateUserCommand(dto.Name));
            _logger.LogInformation("Usuário criado: {@Created}", created);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto dto)
        {
            _logger.LogInformation("Atualizando usuário com id {Id}: {@UserDto}", id, dto);
            var success = await _mediator.Send(new UpdateUserCommand(id, dto.Name));
            if (!success)
            {
                _logger.LogWarning("Usuário com id {Id} não encontrado para atualização", id);
                return NotFound();
            }
            _logger.LogInformation("Usuário com id {Id} atualizado com sucesso", id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Removendo usuário com id {Id}", id);
            var success = await _mediator.Send(new DeleteUserCommand(id));
            if (!success)
            {
                _logger.LogWarning("Usuário com id {Id} não encontrado para remoção", id);
                return NotFound();
            }
            _logger.LogInformation("Usuário com id {Id} removido com sucesso", id);
            return NoContent();
        }
    }
}
