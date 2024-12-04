using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Seed;
using WebApiBurguerMania.Services.Categoria;
using WebApiBurguerMania.Services.ItemPedido;
using WebApiBurguerMania.Services.Pedido;
using WebApiBurguerMania.Services.Produto;
using WebApiBurguerMania.Services.Usuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuario, UsuarioService>();
builder.Services.AddScoped<ICategoria,  CategoriaService>();
builder.Services.AddScoped<IPedido, PedidoService>();
builder.Services.AddScoped<IProduto, ProdutoService>();
builder.Services.AddScoped<IItemPedido, ItemPedidoService>();

// conexão com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("BurguerApp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BurguerApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



// Aplica as migrações pendentes e realiza o seeding
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Aplica as migrações pendentes no banco de dados
    dbContext.Database.Migrate();

    // Chama o Seeder para inserir os dados
    Seeder.SeedAll(dbContext);
}


app.Run();
