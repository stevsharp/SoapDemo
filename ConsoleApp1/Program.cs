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

    var binding = new BasicHttpBinding();

    // Set the endpoint address (ensure the URL is correct, matching your service)
    var endpoint = new EndpointAddress(new Uri("http://localhost:5015/MySoapService.svc"));

    // Create the channel factory to connect to the service
    var channelFactory = new ChannelFactory<ServiceReference1.IMySoapService>(binding, endpoint);

    // Create a proxy client
    var serviceClient = channelFactory.CreateChannel();

    // Call the SOAP service method
    string result = await serviceClient.SayHelloAsync("hey");

    Console.WriteLine(result);

    //var mySoapService = new MySoapServiceClient();

    //var ooo = await mySoapService.SayHelloAsync("Spyros");

    Console.WriteLine(result.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.ReadLine();