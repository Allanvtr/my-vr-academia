var builder = WebApplication.CreateBuilder(args);

// 1. DEFINIR A POLÍTICA DE CORS (Antes do builder.Build())
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirReactEUnity", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5000") // URLs do seu Front-end
              .AllowAnyHeader()                                      // Permite qualquer cabeçalho (JSON, Content-Type, etc)
              .AllowAnyMethod()                                      // Permite POST, GET, PUT, DELETE, etc
              .AllowCredentials();                                   // Importante para o SignalR funcionar!
    });
});

builder.Services.AddControllers();
builder.Services.AddSignalR(); // Seu SignalR

var app = builder.Build();

// 2. ATIVAR O CORS (Logo após o app.Build() e ANTES da Autorização/Endpoints)
app.UseCors("PermitirReactEUnity");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
// app.MapHub<CenaHub>("/cenaHub"); // Exemplo do seu Hub do SignalR

app.Run();