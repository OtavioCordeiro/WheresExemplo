using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheresExemplo
{
    public static class Ultils
    {
        public static List<Cliente> GetClientes()
        {
            var clientes = new List<Cliente>();

            for (int i = 1; i <= 10; i++)
            {
                var pedidos = new List<Pedido>();
                for (int j = 1; j <= 2; j++)
                {
                    var produtos = new List<Produto>();
                    for (int k = 1; k <= 2; k++)
                    {
                        produtos.Add(GetProdutoAleatorio());
                    }

                    pedidos.Add(GetPedidoAleatorio(produtos));
                }

                clientes.Add(new Cliente
                {
                    Nome = $"Cliente {i}",
                    Pedidos = pedidos
                });
            }

            return clientes;
        }

        private static Pedido GetPedidoAleatorio(List<Produto> produtos)
        {
            Random random = new Random();


            var pedidos = new List<Pedido>
                {
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now },
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now.AddDays(-1) },
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now.AddDays(-2) },
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now.AddDays(-3) },
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now.AddDays(-4) },
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now.AddDays(-5) },
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now.AddDays(-6) },
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now.AddDays(-7) },
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now.AddDays(-8) },
                    new Pedido { Produtos = produtos, Numero = random.Next(1000, 9999), Data = DateTime.Now.AddDays(-9) }
                };

            int index = random.Next(pedidos.Count);
            return pedidos[index];
        }

        private static Produto GetProdutoAleatorio()
        {
            List<Produto> produtos = new List<Produto>()
                {
                    new Produto() { Nome = "Caneta", Preco = 1.50M },
                    new Produto() { Nome = "Lápis", Preco = 0.50M },
                    new Produto() { Nome = "Borracha", Preco = 0.75M },
                    new Produto() { Nome = "Caderno", Preco = 8.00M },
                    new Produto() { Nome = "Mochila", Preco = 45.00M },
                    new Produto() { Nome = "Estojo", Preco = 5.50M },
                    new Produto() { Nome = "Livro", Preco = 12.00M },
                    new Produto() { Nome = "Caneca", Preco = 7.00M },
                    new Produto() { Nome = "Mousepad", Preco = 9.00M },
                    new Produto() { Nome = "Camiseta", Preco = 20.00M }
                };

            Random random = new Random();
            int index = random.Next(produtos.Count);
            return produtos[index];
        }
    }
}
