public class Veiculo
{
    public int Id { get; set; }
    public int Capacidade { get; set; }
    public int TotalPessoas { get; set; } = 0;
    public Garagem Local { get; set; }

    public Veiculo(int id, int capacidade)
    {
        Id = id;
        Capacidade = capacidade;
    }

    public override string ToString()
    {
        return $"Veículo {Id} - Capacidade: {Capacidade} - Total transportado hoje: {TotalPessoas}";
    }
}
