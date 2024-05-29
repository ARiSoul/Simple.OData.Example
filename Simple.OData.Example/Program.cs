using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Simple.OData.Example.Data;
using Simple.OData.Example.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(opts =>
    {
        opts.EnableQueryFeatures();
        opts.AddRouteComponents("api/odata", GetEdmModel());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ApplicationDbContext>();

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

app.UseODataRouteDebug();

app.Run();

IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    
    builder.EntitySet<Child>("Children").EntityType
        .HasKey(e => e.Key);

    builder.EntitySet<Parent>("Parents").EntityType
        .HasKey(e => e.Key)
        .HasMany(p => p.Children);

    builder.EnableLowerCamelCase();

    return builder.GetEdmModel();
}
