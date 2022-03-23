using Microsoft.AspNetCore.Http.Json;
using MinimalAPIs;
using MinimalAPIs.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddCors();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/", () => "hello Khh");


//app.MapGet("/syscodes", async (SqlDbContext context) => 
//    await context.SYSCODE.ToListAsync());

app.MapGet("/syscodes", async (SqlDbContext context) =>
{
    return await context.SYSCODE.ToListAsync();
});


app.MapGet("/syscodes/{ckind}", async (SqlDbContext context, string ckind) =>
    await context.SYSCODE.Where(m=>m.CKIND.Equals(ckind)).ToListAsync());

app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowCredentials()); // allow credentials

app.Run();

 