using System.ServiceModel;

namespace ConsoleApp1;

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

public record LoginDto(string userName, string password);