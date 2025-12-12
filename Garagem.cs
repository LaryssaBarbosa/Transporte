using System.Collections.Generic;

public class Garagem
{
    public string Nome { get; set; }
    public Stack<Veiculo> Veiculos { get; set; } = new Stack<Veiculo>();

    public Garagem(string nome)
    {
        Nome = nome;
    }

    public void Adicionar(Veiculo v)
    {
        Veiculos.Push(v);
        v.Local = this;
    }

    public Veiculo Remover()
    {
        if (Veiculos.Count == 0) return null;
        return Veiculos.Pop();
    }

    public int Quantidade()
    {
        return Veiculos.Count;
    }

    public int PotencialTotal()
    {
        int total = 0;
        foreach (var v in Veiculos)
            total += v.Capacidade;
        return total;
    }

    public override string ToString()
    {
        return $"Garagem {Nome} – Veículos: {Quantidade()} – Potencial: {PotencialTotal()}";
    }
}
