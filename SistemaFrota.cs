using System;
using System.Collections.Generic;
using System.Linq;

public class SistemaFrota
{
    public List<Garagem> Garagens { get; set; } = new List<Garagem>();
    public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    public List<Viagem> Viagens { get; set; } = new List<Viagem>();
    public bool JornadaAtiva { get; set; } = false;

    public void CadastrarVeiculo()
    {
        if (JornadaAtiva)
        {
            Console.WriteLine("Não é possível cadastrar com jornada ativa.");
            return;
        }

        Console.Write("ID do veículo: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Capacidade: ");
        int capacidade = int.Parse(Console.ReadLine());

        Veiculos.Add(new Veiculo(id, capacidade));
        Console.WriteLine("Veículo cadastrado.");
    }

    public void CadastrarGaragem()
    {
        if (JornadaAtiva)
        {
            Console.WriteLine("Não é possível cadastrar com jornada ativa.");
            return;
        }

        Console.Write("Nome da garagem: ");
        string nome = Console.ReadLine();

        Garagens.Add(new Garagem(nome));
        Console.WriteLine("Garagem cadastrada.");
    }


    public void IniciarJornada()
    {
        if (JornadaAtiva)
        {
            Console.WriteLine("Jornada já está ativa.");
            return;
        }

        if (Garagens.Count < 2)
        {
            Console.WriteLine("Necessário pelo menos duas garagens.");
            return;
        }

   
        int g = 0;
        foreach (var v in Veiculos)
        {
            Garagens[g].Adicionar(v);
            g = (g + 1) % Garagens.Count;
        }

        JornadaAtiva = true;
        Console.WriteLine("Jornada iniciada.");
    }


    public void EncerrarJornada()
    {
        if (!JornadaAtiva)
        {
            Console.WriteLine("Jornada ainda não iniciada.");
            return;
        }

        Console.WriteLine("\n===== RELATÓRIO DO DIA =====");
        foreach (var v in Veiculos)
        {
            Console.WriteLine($"Veículo {v.Id} transportou {v.TotalPessoas} passageiros.");
            v.TotalPessoas = 0;
        }

        Viagens.Clear();

        JornadaAtiva = false;
        Console.WriteLine("Jornada encerrada.");
    }

    public void LiberarViagem()
    {
        if (!JornadaAtiva)
        {
            Console.WriteLine("Jornada não iniciada.");
            return;
        }

        Console.Write("Origem: ");
        string o = Console.ReadLine();

        Console.Write("Destino: ");
        string d = Console.ReadLine();

        var origem = Garagens.FirstOrDefault(x => x.Nome == o);
        var destino = Garagens.FirstOrDefault(x => x.Nome == d);

        if (origem == null || destino == null)
        {
            Console.WriteLine("Garagem inválida.");
            return;
        }

        if (origem.Quantidade() == 0)
        {
            Console.WriteLine("Nenhum veículo disponível.");
            return;
        }

        Veiculo v = origem.Remover();

        int passageiros = v.Capacidade;
        v.TotalPessoas += passageiros;

        Viagens.Add(new Viagem(origem, destino, passageiros));

        destino.Adicionar(v);

        Console.WriteLine($"Viagem liberada! Veículo {v.Id} foi para {destino.Nome}.");
    }

 
    public void ListarVeiculosGaragem()
    {
        Console.Write("Garagem: ");
        string n = Console.ReadLine();

        var g = Garagens.FirstOrDefault(x => x.Nome == n);

        if (g == null)
        {
            Console.WriteLine("Garagem inválida.");
            return;
        }

        Console.WriteLine($"\n{g}");

        foreach (var v in g.Veiculos)
            Console.WriteLine(v);
    }

   
    public void QtdViagens()
    {
        Console.Write("Origem: ");
        string o = Console.ReadLine();

        Console.Write("Destino: ");
        string d = Console.ReadLine();

        int qtd = Viagens.Count(x => x.Origem.Nome == o && x.Destino.Nome == d);

        Console.WriteLine($"Total de viagens {o} → {d}: {qtd}");
    }

  
    public void ListarViagens()
    {
        Console.Write("Origem: ");
        string o = Console.ReadLine();

        Console.Write("Destino: ");
        string d = Console.ReadLine();

        var lista = Viagens.Where(x => x.Origem.Nome == o && x.Destino.Nome == d);

        foreach (var v in lista)
            Console.WriteLine(v);
    }


    public void QtdPassageiros()
    {
        Console.Write("Origem: ");
        string o = Console.ReadLine();

        Console.Write("Destino: ");
        string d = Console.ReadLine();

        int total = Viagens
            .Where(v => v.Origem.Nome == o && v.Destino.Nome == d)
            .Sum(v => v.PessoasTransportadas);

        Console.WriteLine($"Passageiros transportados de {o} → {d}: {total}");
    }
}
