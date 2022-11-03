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
    
    public List<KeyValuePair<String, String>> GetAll()
    {
        List<KeyValuePair<String, String>> messages = new()
        {
            new KeyValuePair<string, string>("msg_subject", "Secure software supply chains are great!"),
            new KeyValuePair<string, string>("msg_body", "This is my message body."),
            new KeyValuePair<string, string>("client", _configuration["demoClient"]),
            new KeyValuePair<string, string>("framework", ".Net Core & Razor")
        };

        _logger.Log(LogLevel.Information, "Returning the message group {messages}", messages);
        return messages;
    }
    
}