using BLL.Models;
using MassTransit;

namespace MessageConsumer
{
    public class Consumer : IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            await Console.Out.WriteLineAsync($"***\n" +
                $"Title: {context.Message.Title}\n" +
                $"Message: {context.Message.Content}\n");
        }
    }
}
