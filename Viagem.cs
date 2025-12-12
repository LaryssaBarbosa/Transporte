public class Viagem
{
    public Garagem Origem { get; set; }
    public Garagem Destino { get; set; }
    public int PessoasTransportadas { get; set; }

    public Viagem(Garagem origem, Garagem destino, int pessoas)
    {
        Origem = origem;
        Destino = destino;
        PessoasTransportadas = pessoas;
    }

    public override string ToString()
    {
        return $"{Origem.Nome} → {Destino.Nome} | Passageiros: {PessoasTransportadas}";
    }
}
