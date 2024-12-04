using WebApiBurguerMania.Data;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Seed
{
    public static class Seeder
    {
        public static void SeedAll(AppDbContext dbContext)
        {
            SeedCategorias(dbContext);
            SeedUsuarios(dbContext);
            SeedProdutos(dbContext);
            SeedPedidos(dbContext);
            SeedItensPedidos(dbContext);
        }

        private static void SeedCategorias(AppDbContext dbContext)
        {
            if (!dbContext.Categorias.Any())
            {
                dbContext.Categorias.AddRange(
                    new CategoriaModel { Nome = "Vegano", Descricao = "Hambúrgueres sem ingredientes de origem animal", PathImagem = "https://raw.githubusercontent.com/Projetos-ResTic/imagens-burguer-mania/refs/heads/main/burguer.png" },
                    new CategoriaModel { Nome = "Clássico", Descricao = "Os sabores tradicionais que todos amam", PathImagem = "https://raw.githubusercontent.com/Projetos-ResTic/imagens-burguer-mania/refs/heads/main/burguer.png" },
                    new CategoriaModel { Nome = "Gourmet", Descricao = "Para quem busca um sabor sofisticado", PathImagem = "https://raw.githubusercontent.com/Projetos-ResTic/imagens-burguer-mania/refs/heads/main/burguer.png" },
                    new CategoriaModel { Nome = "Frango", Descricao = "Deliciosos hambúrgueres de frango", PathImagem = "https://raw.githubusercontent.com/Projetos-ResTic/imagens-burguer-mania/refs/heads/main/burguer.png" },
                    new CategoriaModel { Nome = "Marinho", Descricao = "Hambúrgueres com peixe e frutos do mar", PathImagem = "https://raw.githubusercontent.com/Projetos-ResTic/imagens-burguer-mania/refs/heads/main/burguer.png" }
                );
                dbContext.SaveChanges();
            }
        }

        private static void SeedUsuarios(AppDbContext dbContext)
        {
            if (!dbContext.Usuarios.Any())
            {
                dbContext.Usuarios.AddRange(
                    new UsuarioModel {  Nome = "Lucas Oliveira", Email = "lucas.oliveira@example.com", Senha= "senha111" },
                    new UsuarioModel { Nome = "Mariana Silva", Email = "mariana.silva@example.com", Senha = "senha111" }
                );
                dbContext.SaveChanges();
            }
        }

        private static void SeedProdutos(AppDbContext dbContext)
        {
            if (!dbContext.Produtos.Any())
            {
                dbContext.Produtos.AddRange(
                    new ProdutoModel
                    {
                        
                        CategoriaId = 1,
                        Nome = "Hambúrguer Tropical",
                        PathImagem = "https://raw.githubusercontent.com/Projetos-ResTic/imagens-burguer-mania/refs/heads/main/burguer.png",
                        Preco = 16.00,
                        DescricaoBasica = "Pão vegano, hambúrguer de lentilha, abacaxi grelhado, alface, tomate e molho especial",
                        DescricaoCompleta = "O Hambúrguer Tropical é uma explosão de sabores frescos e naturais, com abacaxi grelhado e molho especial, perfeito para quem quer algo leve e saboroso."
                    },
                    new ProdutoModel
                    {
                        
                        CategoriaId = 2,
                        Nome = "Clássico Cheddar",
                        PathImagem = "https://raw.githubusercontent.com/Projetos-ResTic/imagens-burguer-mania/refs/heads/main/burguer.png",
                        Preco = 14.50,
                        DescricaoBasica = "Pão com gergelim, hambúrguer de carne bovina, cheddar derretido, alface, tomate e maionese",
                        DescricaoCompleta = "O clássico perfeito! Hambúrguer suculento com queijo cheddar derretido, servidos no pão com gergelim, um verdadeiro ícone da culinária."
                    }
                    // Adicione os outros produtos
                );
                dbContext.SaveChanges();
            }
        }

        private static void SeedPedidos(AppDbContext dbContext)
        {
            if (!dbContext.Pedidos.Any())
            {
                dbContext.Pedidos.AddRange(
                    new PedidoModel {  UsuarioId = 1, Valor = 45.00, DataPedido = DateTime.Now },
                    new PedidoModel {  UsuarioId = 2, Valor = 38.50, DataPedido = DateTime.Now }
                );
                dbContext.SaveChanges();
            }
        }

        private static void SeedItensPedidos(AppDbContext dbContext)
        {
            if (!dbContext.ItensPedidos.Any())
            {
                dbContext.ItensPedidos.AddRange(
                    new ItemPedidoModel
                    {
                        
                        PedidoId = 1,
                        ProdutoId = 1, // Hambúrguer Tropical
                        Quantidade = 2,
                        PrecoUnitario = 16.00
                    },
                    new ItemPedidoModel
                    {
                        
                        PedidoId = 1,
                        ProdutoId = 2, // Clássico Cheddar
                        Quantidade = 1,
                        PrecoUnitario = 14.50
                    }
                    // Adicione os outros itens de pedidos
                );
                dbContext.SaveChanges();
            }
        }
    }
}
