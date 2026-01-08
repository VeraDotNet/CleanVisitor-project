using Microsoft.AspNetCore.Mvc;

namespace CleanVisitor.Api.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Get() => "Swagger OK";
}
