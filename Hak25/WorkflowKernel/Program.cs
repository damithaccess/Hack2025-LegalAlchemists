using Hack2025_LegalAlchemists;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
var builder = Kernel.CreateBuilder();


// Services
builder.AddAzureOpenAIChatCompletion("workflow-agent",
    "https://hack2025-legalalchemists.openai.azure.com/",
    "89priIbW1LuMjaeVPK0zkGhcEXmjs2yKVmxkzsROx03hYrki59X2JQQJ99BEACYeBjFXJ3w3AAABACOGnIj7");

// Plugins
//builder.Plugins.AddFromType<MatterPlugin>();
//builder.Plugins.AddFromType<AddDaryNotePlugin>();

Kernel kernel = builder.Build();

var chatService = kernel.GetRequiredService<IChatCompletionService>();

ChatHistory chatMessages = new ChatHistory("cricket");

while (true)
{
    Console.Write("Prompt:");
    chatMessages.AddUserMessage(Console.ReadLine());

    var completion = chatService.GetStreamingChatMessageContentsAsync(chatMessages,
        executionSettings: new OpenAIPromptExecutionSettings() { 
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions }, kernel: kernel);

    string fullMessage = "";
    await foreach (var content in completion)
    {
        Console.Write(content.Content);
        fullMessage += content.Content;
    }

}

