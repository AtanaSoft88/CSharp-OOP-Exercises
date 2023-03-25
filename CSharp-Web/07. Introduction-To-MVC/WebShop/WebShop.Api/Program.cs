using WebShop.Core.Contracts;
using WebShop.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//This is for better description in the Home Page of API - optional to do this!
builder.Services.AddSwaggerGen(c=> 
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
	{
		Title= "My WebShop",
		Description = "This is my first and best Web Api",
		License = new Microsoft.OpenApi.Models.OpenApiLicense() 
		{ 
			Name = "EUPL v 1.2"
		}
	});

});

//Here we add/register the same Service like we add in WebShop
builder.Services.AddScoped<IProductService, ProductService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// In the solution you may click rignt button and select multiple start project to see WebShop and WebShop.Api simultaneously
// appsettingsjson -> add same data as WebShop appsettingsjson file
//Add Controller -> same as those used in WebShop. Inject Interface - Service