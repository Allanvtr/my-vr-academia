using Microsoft.AspNetCore.SignalR;

namespace VrAudioCena.WebApi.Hubs
{
    public class SceneHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Cliente conectado: {Context.ConnectionId}");

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"Cliente desconectado: {Context.ConnectionId}");

            await base.OnDisconnectedAsync(exception);
        }

        public async Task JoinOperation(string operationId)
        {
            await Groups.AddToGroupAsync(
                Context.ConnectionId,
                operationId);

            Console.WriteLine($"{Context.ConnectionId} entrou na operação {operationId}");
        }
    }
}