using ProjetoEstacionamento.Classes;

Console.WriteLine("=== Sistema de Estacionamento ===\n");

Console.Write("Digite o preço inicial: ");
decimal precoInicial = decimal.Parse(Console.ReadLine() ?? "0");

Console.Write("Digite o preço por hora adicional: ");
decimal precoPorHora = decimal.Parse(Console.ReadLine() ?? "0");

Estacionamento estacionamento = new(precoInicial, precoPorHora);

string opcao;
do
{
    Console.WriteLine("\n--- Menu ---");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");
    Console.Write("Opção: ");
    opcao = Console.ReadLine() ?? "";

    switch (opcao)
    {
        case "1":
            estacionamento.AdicionarVeiculo();
            break;
        case "2":
            estacionamento.RemoverVeiculo();
            break;
        case "3":
            estacionamento.ListarVeiculos();
            break;
        case "4":
            Console.WriteLine("Encerrando...");
            break;
        default:
            Console.WriteLine("Opção Inexistente.");
            break;
    }

} while (opcao != "4");
