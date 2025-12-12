using System;

class Program
{
    static void Main()
    {
        SistemaFrota sistema = new SistemaFrota();
        int op;

        do
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("0 – Finalizar");
            Console.WriteLine("1 – Cadastrar veículo");
            Console.WriteLine("2 – Cadastrar garagem");
            Console.WriteLine("3 – Iniciar jornada");
            Console.WriteLine("4 – Encerrar jornada");
            Console.WriteLine("5 – Liberar viagem");
            Console.WriteLine("6 – Listar veículos em garagem");
            Console.WriteLine("7 – Qtd viagens de origem → destino");
            Console.WriteLine("8 – Listar viagens de origem → destino");
            Console.WriteLine("9 – Passageiros transportados de origem → destino");
            Console.Write("Opção: ");
            op = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (op)
            {
                case 1: sistema.CadastrarVeiculo(); break;
                case 2: sistema.CadastrarGaragem(); break;
                case 3: sistema.IniciarJornada(); break;
                case 4: sistema.EncerrarJornada(); break;
                case 5: sistema.LiberarViagem(); break;
                case 6: sistema.ListarVeiculosGaragem(); break;
                case 7: sistema.QtdViagens(); break;
                case 8: sistema.ListarViagens(); break;
                case 9: sistema.QtdPassageiros(); break;
                case 0: Console.WriteLine("Finalizado."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

        } while (op != 0);
    }
}
