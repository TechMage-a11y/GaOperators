namespace GaOperators;

/// <summary>
/// Бинарная хромосома фиксированной длины.
/// </summary>
public sealed class Chromosome
{
    private readonly bool[] _genes;

    /// <summary>Создаёт хромосому и копирует гены.</summary>
    /// <param name="genes">Массив генов хромосомы.</param>
    /// <exception cref="ArgumentNullException">Массив генов равен <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Массив пуст.</exception>
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

    /// <summary>
    /// Возвращает количество генов.
    /// </summary>
    public int Length => _genes.Length;

    /// <summary>
    /// Получает или задаёт значение приспособленности хромосомы.
    /// </summary>
    public double Fitness { get; set; }

    /// <summary>
    /// Возвращает копию массива генов.
    /// </summary>
    public bool[] Genes
    {
        get
        {
            var copy = new bool[_genes.Length];
            Array.Copy(_genes, copy, _genes.Length);
            return copy;
        }
    }

    /// <summary>
    /// Возвращает значение гена по индексу.
    /// </summary>
    /// <param name="index">Индекс гена.</param>
    /// <exception cref="IndexOutOfRangeException">Индекс находится вне диапазона хромосомы.</exception>
    public bool this[int index] => _genes[index];

    /// <summary>Возвращает копию хромосомы.</summary>
    /// <returns>Новая хромосома с теми же генами и Fitness.</returns>
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
