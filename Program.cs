var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var secrets = new Secrets();
app.Configuration.GetSection("Secrets").Bind(secrets);

var connectionString = app.Configuration.GetConnectionString("DefaultConnection");

app.MapGet("/", () => new
{
  ConnectionString = connectionString,
  Secrets = secrets,
  ApiUrl = app.Configuration.GetValue<string>("ApiUrl")
});

app.Run();


public class Secrets
{
  public string JwtTokenSecret { get; set; } = string.Empty;
  public string ApiKey { get; set; } = string.Empty;
  public string PrivateKey { get; set; } = string.Empty;
}