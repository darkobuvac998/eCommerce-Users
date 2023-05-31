using AutoMapper;
using eCommerce.Users.Application.Commands;
using eCommerce.Users.Infrastructure.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Users.Presentation.Controllers;

[Route("/api/[controller]")]
public class PermissionsController : ApiController
{
    public PermissionsController(ISender sender, IMapper mapper)
        : base(sender, mapper) { }

    [HasPermission(Permissions.Permission.View)]
    [HttpGet]
    public async Task<IActionResult> GetAllPermissionsAsync()
    {
        var result = await Sender.Send(new GetAllAvailablePermissionsCommand());
        return Ok(result);
    }
}
