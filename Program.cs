using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddDbContext<DatabaseCtx>(o => o.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNSTRING")));
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MigrateDatabase();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseExceptionHandler();

app.MapHealthChecks("/healthcheck");
app.MapGet("/products", async (IMediator mediator) => await mediator.Send(new GetProductListQuery())); //TODO: use outbound dto
app.MapGet("/products/{id}", async (IMediator mediator, [FromRoute] int id) => await mediator.Send(new GetProductByIdQuery { Id = id }));
app.MapPost("/products", async (IMediator mediator, [FromBody] CreateProductInboundDto dto) => await mediator.Send(new CreateProductCommand { Name = dto.Name, Stock = dto.Stock, Type = dto.Type, WarehouseName = dto.WarehouseName }));
app.MapPut("/products/{id}", async (IMediator mediator, [FromRoute] int id, [FromBody] UpdateProductInboundDto dto) => await mediator.Send(new UpdateProductCommand { Id = id, Name = dto.Name, Stock = dto.Stock, Type = dto.Type, WarehouseName = dto.WarehouseName }));
app.MapDelete("/products/{id}", async (IMediator mediator, [FromRoute] int id) => await mediator.Send(new DeleteProductCommand { Id = id }));

app.Run();
