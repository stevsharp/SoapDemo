using Microsoft.Extensions.DependencyInjection.Extensions;

using SoapCore;

using SoapDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(5000); // Listen on HTTP port 5000
//    // Do not call Listen on HTTPS port
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSoapCore();
builder.Services.TryAddSingleton<IMySoapService, MySoapService>();
builder.Services.AddMvc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.UseSoapEndpoint<IMySoapService>(opt =>
    {
        opt.Path = "/MySoapService.svc";
        opt.SoapSerializer = SoapSerializer.DataContractSerializer;
    });
});

//app.Urls.Add("https://localhost:7289");
//app.Urls.Add("http://localhost:7289");

app.UseAuthorization();

app.MapControllers();



app.Run();
