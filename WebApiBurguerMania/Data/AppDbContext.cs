using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ItemPedidoModel> ItensPedidos { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<ItemPedidoModel>()
                .HasOne(ip => ip.Pedido)  
                .WithMany(p => p.ItensPedido)  
                .HasForeignKey(ip => ip.PedidoId)  
                .OnDelete(DeleteBehavior.Cascade); 

            
            modelBuilder.Entity<ItemPedidoModel>()
                .HasOne(ip => ip.Produto)  
                .WithMany(p => p.ItensPedido)  
                .HasForeignKey(ip => ip.ProdutoId)  
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<PedidoModel>()
                .HasOne(p => p.Usuario)  
                .WithMany(u => u.Pedidos)  
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade); 

          
        }

    }
}
