﻿using AutoMapper;
using eCommerce.Users.Application.Commands;
using eCommerce.Users.Presentation.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Users.Presentation.Controllers;

[AllowAnonymous]
[Route("/api/[controller]")]
public class AuthController : ApiController
{
    public AuthController(ISender sender, IMapper mapper)
        : base(sender, mapper) { }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
    {
        var command = Mapper.Map<LoginCommand>(request);
        var result = await Sender.Send(command);
        return Ok(result);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignInAsync([FromBody] SignInRequest request)
    {
        var command = Mapper.Map<SignInCommand>(request);
        var result = await Sender.Send(command);
        return Ok(result);
    }
}
