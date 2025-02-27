using OMS.Application.Features.Orders.Events;
using OMS.Application.Features.Users.Handlers;
using OMS.Application.Mappings;
using OMS.Infrastructure.Persistence;
using OMS.Infrastructure.Persistence.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application layer
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetAllUsersQueryHandler)));

// Infrastructure layer

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();

var app = builder.Build();

// Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
