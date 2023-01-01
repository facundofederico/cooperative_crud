using Microsoft.AspNetCore.Mvc;

namespace Cooperative.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}