using System.ClientModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using OpenAI;
using OpenAI.Chat;
using Microsoft.Extensions.Configuration;

namespace AIChat
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var token = config["OpenAI:Token"];
            var endpoint = config["OpenAI:Endpoint"];
            var modelName = config["OpenAI:ModelName"];

            var client = new OpenAIClient(
                new ApiKeyCredential(token),
                new OpenAIClientOptions { Endpoint = new Uri(endpoint) });

            var kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelName, client)
                .Build();

            var chat = kernel.GetRequiredService<IChatCompletionService>();
            var history = new ChatHistory();
            history.AddSystemMessage(
            "You are a senior software developer. Provide clear, concise, and professional answers. " +
            "When giving code, follow best practices and explain your reasoning. If you are unsure, say 'I don't know.' " +
            "Offer suggestions for code improvements and guidance where appropriate.");

            while (true)
            {
                Console.Write("Q: ");
                var userQ = Console.ReadLine();
                if (string.IsNullOrEmpty(userQ)) continue;
                history.AddUserMessage(userQ);

                Console.Write("AI: ");
                var sb = new StringBuilder();
                await foreach (var item in chat.GetStreamingChatMessageContentsAsync(history))
                {
                    sb.Append(item);
                    Console.Write(item.Content);
                }
                Console.WriteLine();
                history.AddAssistantMessage(sb.ToString());
            }
        }
    }
}