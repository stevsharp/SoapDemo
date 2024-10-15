using System.ServiceModel;

namespace SoapDemo;

[ServiceContract]
public interface IMySoapService
{
    [OperationContract]
    string SayHello(string name);

    [OperationContract]
    int Add(int x, int y);
}


public class MySoapService : IMySoapService
{
    public string SayHello(string name)
    {
        return $"Hello, {name}!";
    }

    public int Add(int x, int y)
    {
        return x + y;
    }
}