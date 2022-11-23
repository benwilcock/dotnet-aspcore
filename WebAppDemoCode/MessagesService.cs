namespace WebAppDemoCode;

public class MessagesService : IMessagesService
{
    private readonly ILogger<MessagesService> _logger;
    private readonly IConfiguration _configuration;
    
    public MessagesService(ILogger<MessagesService> logger,IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IDictionary<String, String> GetAll()
    {
        IDictionary<String, String> message = new Dictionary<string, string>();

        message.Add("msg_subject", "Secure software supply chains are great!");
        message.Add("msg_body", "This is my message body.");
        message.Add("client", _configuration["demoClient"]);
        message.Add("framework", ".Net Core & Razor");
        
        _logger.Log(LogLevel.Information, "Returning the message group {messages}", message);
        return message;
    }

}