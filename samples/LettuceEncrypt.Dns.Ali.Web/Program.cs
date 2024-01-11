using LettuceEncrypt;
using LettuceEncrypt.Dns.Ali;
using Microsoft.AspNetCore.Server.Kestrel.Https;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(options =>
{
    var appServices = options.ApplicationServices;
    options.ConfigureHttpsDefaults(h =>
    {
        h.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
        h.UseLettuceEncrypt(appServices);
    });
});

builder.Services.AddLettuceEncrypt().PersistDataToDirectory(new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "record")), "abc123456").Services.AddAliDnsChallengeProvider();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.Run();
