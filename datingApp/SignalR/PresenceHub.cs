﻿ 
using datingApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace datingApp.SignalR;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
[Authorize]
public class PresenceHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Others.SendAsync("UserIsOnline", Context.User.GetUsername());
    }
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Clients.Others.SendAsync("UserIsOffline", Context.User.GetUsername());
        await base.OnDisconnectedAsync(exception);
    }
}