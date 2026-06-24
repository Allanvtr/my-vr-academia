using System.Threading.Channels;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VrAudioCena.WebApi.Infrastructure.Background
{
    public class EventQueue
    {
        private readonly Channel<INotification> _channel = Channel.CreateUnbounded<INotification>(
            new UnboundedChannelOptions
            {
                SingleReader = true,
                SingleWriter = false
            });

        public async Task EnqueueAsync(INotification newEvent, CancellationToken cancellationToken)
        {
            await _channel.Writer.WriteAsync(newEvent, cancellationToken);
        }

        public async Task<INotification> ReadQueueAsync(CancellationToken cancellationToken)
        {
            return await _channel.Reader.ReadAsync(cancellationToken);
        }
    }
}