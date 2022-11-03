namespace WebAppDemoCode;

public interface IMessagesService
{
    List<KeyValuePair<String, String>> GetAll();
}