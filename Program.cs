using Karavan.Repository;
using Karavan.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PersonDbContext>(opt => opt.UseInMemoryDatabase("karavanDB"));
builder.Services.AddDbContext<OrderDbContext>(opt => opt.UseInMemoryDatabase("karavanDB"));
builder.Services.AddDbContext<BranchDbContext>(opt => opt.UseInMemoryDatabase("karavanDB"));
builder.Services.AddTransient<IPerson, PersonRepository>();
builder.Services.AddTransient<IOrder, OrderRepository>();
builder.Services.AddTransient<IBranch, BranchRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
