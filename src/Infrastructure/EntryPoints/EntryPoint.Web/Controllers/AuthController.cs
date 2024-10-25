using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Template.Service.Api.Rest.Domain.Model;
using Template.Service.Api.Rest.Domain.UseCase;
using Template.Service.Api.Rest.EntryPoint.Web.Dtos;

namespace None.Template.Service.Api.Rest.EntryPoint.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IOptions<JwtSettings> jwtSettings) : ControllerBase
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;

        [HttpPost("login")]
        [ProducesResponseType(typeof(ResponseBaseDto<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseBaseDto<AccessToken>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseBaseDto<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] ApiUser request,
            [FromServices] IUseCase<Task<AccessToken>,ApiUser > useCase)
        {
            var result = await useCase.Execute(request);
            return  Ok(new ResponseBaseDto<AccessToken>().Success(result));

        }
    }
}
