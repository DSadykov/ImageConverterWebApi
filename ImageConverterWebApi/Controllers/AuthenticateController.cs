﻿using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImageConverterWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticateController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthenticateController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        AuthenticateResponse? response = _userService.Authenticate(model);
        return CheckResponse(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AuthenticateRequest userModel)
    {
        AuthenticateResponse? response = await _userService.Register(userModel);
        return CheckResponse(response);
    }

    private IActionResult CheckResponse(AuthenticateResponse response)
    {
        return response.Token is null ? BadRequest(new { message = response.ErrorMessage }) : Ok(response);
    }
}
