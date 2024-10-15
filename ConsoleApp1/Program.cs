using ConsoleApp1;

using System.ServiceModel;

using ServiceReference1;

try
{

    // http://localhost:5015/MySoapService.svc

    //var binding = new BasicHttpBinding();
    //var endpoint = new EndpointAddress(new Uri(string.Format("http://localhost:5015/MySoapService.svc", Environment.MachineName)));
    //var channelFactory = new ChannelFactory<ConsoleApp1.IMySoapService>(binding, endpoint);
    //var serviceClient = channelFactory.CreateChannel();

    //await Task.Delay(500);

    //var result = serviceClient.SayHello("hey");

    var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;


    var endpoint = new EndpointAddress(new Uri("https://localhost:7289/MySoapService.svc"));

    var channelFactory = new ChannelFactory<ServiceReference1.IMySoapService>(binding, endpoint);


    var serviceClient = channelFactory.CreateChannel();

    var result = await serviceClient.AuthenticateAsync(new ServiceReference1.LoginDto
    {
        UserName = "admin",
        Password = "test"
    });

    Console.WriteLine(result);

    var mySoapService = new MySoapServiceClient();

    var ooo = await mySoapService.SayHelloAsync("Spyros");

    Console.WriteLine(result.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.ReadLine();