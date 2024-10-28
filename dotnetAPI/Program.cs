using dotnetAPI.Services;
using dotnetAPI.Services.Impl;
using dotnetAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//date formatting
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverter("yyyy-MM-dd HH:mm:ss"));
    });

//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddCors(options => options.AddPolicy(name: "productsOrigin",
    policy =>
    {
        policy.WithOrigins("http>//localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>(); //connection between Interface and Implementation
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("productsOrigin");
app.UseHttpsRedirection(); //http to https

app.UseAuthorization();

app.MapControllers();

app.Run();
