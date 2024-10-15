using System.Runtime.Serialization;
using System.ServiceModel;

namespace SoapDemo;

[ServiceContract]
public interface IMySoapService
{
    [OperationContract]
    string SayHello(string name);

    [OperationContract]
    int Add(int x, int y);

    [OperationContract]
    bool Authenticate(LoginDto login);

}
[DataContract]
public record LoginDto
{
    [DataMember]
    public string UserName { get; init; }

    [DataMember]
    public string Password { get; init; }

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

    public bool Authenticate(LoginDto login)
    {
        if (login == null)
        {
            return false;
        }

        return login.UserName == "admin" && login.Password == "test";
    }
}