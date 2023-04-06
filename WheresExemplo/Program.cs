namespace WheresExemplo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var clientes = Ultils.GetClientes();

            Console.WriteLine("Clientes que fez pedido ontem");
            var clientesPedidosOntem = GetClientesComPedidosOntem(clientes);
            EscrevaNoCmd(clientesPedidosOntem);


            Console.WriteLine("\n\nClientes que contem Caneta");
            var clientesComCaneta = GetClientesQueContemCaneta(clientes);
            EscrevaNoCmd(clientesComCaneta);


            Console.WriteLine("\n\nClientes e pedidos que contem Caneta ");
            var clientesEPedidosComCaneta = GetClientesEOsPedidosQueContemCaneta(clientes);
            EscrevaNoCmd(clientesEPedidosComCaneta);

        }

        private static List<Cliente> GetClientesComPedidosOntem(List<Cliente> clientes)
        {
            return clientes.Where(c =>
                c.Pedidos.Any(p => p.Data >= DateTime.Now.Date.AddDays(-1) && p.Data <= DateTime.Now.Date.AddMilliseconds(-1))
            ).Select(c => new Cliente
            {
                Nome = c.Nome,
                Pedidos = c.Pedidos.Where(p => p.Data >= DateTime.Now.Date.AddDays(-1) && p.Data <= DateTime.Now.Date.AddMilliseconds(-1)).ToList()
            }).ToList();
        }

        static List<Cliente> GetClientesQueContemCaneta(List<Cliente> clientes)
        {
            return clientes.Where(c => c.Pedidos.Any(p => p.Produtos.Any(pr => pr.Nome == "Caneta"))).ToList();
        }

        static List<Cliente> GetClientesEOsPedidosQueContemCaneta(List<Cliente> clientes)
        {
            return clientes.Where(c => c.Pedidos.Any(p => p.Produtos.Any(pr => pr.Nome == "Caneta")))
                                         .Select(c => new Cliente
                                         {
                                             Nome = c.Nome,
                                             Pedidos = c.Pedidos.Where(p => p.Produtos.Any(pr => pr.Nome == "Caneta"))
                                                                .Select(p => new Pedido
                                                                {
                                                                    Numero = p.Numero,
                                                                    Data = p.Data,
                                                                    Produtos = p.Produtos.Where(pr => pr.Nome == "Caneta")
                                                                                        .ToList()
                                                                })
                                                                .ToList()
                                         })
                                         .ToList();
        }


        private static void EscrevaNoCmd(List<Cliente> clientes)
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Cliente: {cliente.Nome}");
                foreach (var pedido in cliente.Pedidos)
                {
                    Console.WriteLine($"\tPedido número {pedido.Numero}, data: {pedido.Data}");
                    foreach (var produto in pedido.Produtos)
                    {
                        Console.WriteLine($"\t\tProduto: {produto.Nome}, preço: {produto.Preco}");
                    }
                }
            }
        }
    }
}