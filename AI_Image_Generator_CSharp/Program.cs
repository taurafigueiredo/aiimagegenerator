using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI.Managers;
using OpenAI;

// See https://aka.ms/new-console-template for more information

class Program
{
    static async Task Main(string[] args)
    {
        var openAiApiKey = "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"; // Replace with your OpenAI API key

        APIAuthentication aPIAuthentication = new APIAuthentication(openAiApiKey);
        OpenAIAPI openAiApi = new OpenAIAPI(aPIAuthentication);


        try
        {
            var sdk = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = "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"
            });

            var completionResult = await sdk.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromSystem("You are a helpful assistant."),
                    ChatMessage.FromUser("Who won the world series in 2020?"),
                    ChatMessage.FromAssistant("The Los Angeles Dodgers won the World Series in 2020."),
                    ChatMessage.FromUser("Where was it played?")
                },
                Model = Models.Gpt_3_5_Turbo
            });
            if (completionResult.Successful)
            {
                Console.WriteLine(completionResult.Choices.First().Message.Content);
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknown Error");
                }

                Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}