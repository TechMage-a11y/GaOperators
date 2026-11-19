namespace GaOperators;

public sealed class Chromosome
{
    private readonly bool[] _genes;

    public Chromosome(bool[] genes)
    {
        ArgumentNullException.ThrowIfNull(genes);

        if (genes.Length < 1)
        {
            throw new ArgumentException("Хромосома должна содержать хотя бы один ген.", nameof(genes));
        }

        _genes = new bool[genes.Length];
        Array.Copy(genes, _genes, genes.Length);
    }

    public int Length => _genes.Length;

    public double Fitness { get; set; }

    public bool[] Genes
    {
        get
        {
            var copy = new bool[_genes.Length];
            Array.Copy(_genes, copy, _genes.Length);
            return copy;
        }
    }

    public bool this[int index] => _genes[index];

    public Chromosome Clone()
    {
        return new Chromosome(_genes)
        {
            Fitness = Fitness
        };
    }

    internal void SetGene(int index, bool value)
    {
        _genes[index] = value;
    }
}
