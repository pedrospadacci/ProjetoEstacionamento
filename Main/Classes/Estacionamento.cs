namespace ProjetoEstacionamento.Classes
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Informe a placa do veículo:");
            string? placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo {placa} estacionado!");
            }
            else
            {
                Console.WriteLine("Placa inválida. Operação cancelada.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string? placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Operação cancelada.");
                return;
            }

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite o tempo total de permanência em minutos:");
                string? inputMinutos = Console.ReadLine();
                int minutos = 0;

                if (!int.TryParse(inputMinutos, out minutos) || minutos < 0)
                {
                    Console.WriteLine("Quantidade de minutos inválida. Operação cancelada.");
                    return;
                }

                decimal valorTotal = CalcularValor(minutos);

                veiculos.RemoveAll(x => x.ToUpper() == placa.ToUpper());
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var v in veiculos)
                {
                    Console.WriteLine(v);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        
        private decimal CalcularValor(int totalMinutos)
        {
            
            if (totalMinutos <= 30)
                return precoInicial / 2m;

           
            if (totalMinutos <= 70)
                return precoInicial;

            
            int resto = totalMinutos - 70;
            int adicionais = (int)Math.Ceiling(resto / 60.0);

            return precoInicial + adicionais * precoPorHora;
        }
    }
}
