using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using TuraRandi.Data; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// API controllerek hozz�ad�sa
builder.Services.AddControllers();

// Endpoint API Explorer hozz�ad�sa a Swagger-hez
builder.Services.AddEndpointsApiExplorer();

// Swagger szolg�ltat�sok hozz�ad�sa
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "T�ra Randi API",
		Version = "v1",
		Description = "API tesztel�shez haszn�lhat� v�gpontok"
	});
});

// SQLite adatb�zis konfigur�l�sa a Data k�nyvt�rban TuraRandi.db n�ven
builder.Services.AddDbContext<TuraRandiDbContext>(opt =>opt.UseSqlite("Data Source=Data\\TuraRandi.db"));






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();

	// Swagger middleware hozz�ad�sa fejleszt�i k�rnyezetben
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "T�ra Randi API v1"));
}
else
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}
app.UseCors(builder =>
{
	builder.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader();
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
