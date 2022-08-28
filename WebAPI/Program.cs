using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using WebAPI.Entities;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<SysuxDb>();

EmailService emailService = new EmailService(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/contactoCliente", async (SysuxDb db) =>
    await db.ContactoClientes.ToListAsync());



app.MapGet("/contactoCliente/{id}", async (int id, SysuxDb db) =>
    await db.ContactoClientes.FindAsync(id)
        is ContactoCliente contactoCliente
            ? Results.Ok(contactoCliente)
            : Results.NotFound());

app.MapPost("/contactoCliente", async (ContactoCliente cc, SysuxDb db) =>
{
    emailService.SendMail(cc);
    db.ContactoClientes.Add(cc);    
    await db.SaveChangesAsync();  
    return Results.Created($"/contactoCliente/{cc.Id}", cc);
});

app.MapPost("/sendmail", async (ContactoCliente cc) =>
{
    emailService.SendMail(cc);
});

app.MapPut("/contactoCliente/{id}", async (int id, ContactoCliente inputCc, SysuxDb db) =>
{
    var cc = await db.ContactoClientes.FindAsync(id);

    if (cc is null) return Results.NotFound();

    cc.Telefono = inputCc.Telefono;
    cc.Mensaje = inputCc.Mensaje;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/contactoCliente/{id}", async (int id, SysuxDb db) =>
{
    if (await db.ContactoClientes.FindAsync(id) is ContactoCliente cc)
    {
        db.ContactoClientes.Remove(cc);
        await db.SaveChangesAsync();
        return Results.Ok(cc);
    }

    return Results.NotFound();
});

app.Run();
