namespace GaOperators;

/// <summary>Скрещивает хромосомы, выбирая источник каждого гена.</summary>
public sealed class UniformCrossover : ICrossover
{
    /// <summary>Создаёт оператор скрещивания.</summary>
    /// <param name="crossoverProbability">Вероятность выполнения скрещивания.</param>
    /// <exception cref="ArgumentOutOfRangeException">Вероятность не входит в диапазон от 0 до 1.</exception>
    public UniformCrossover(double crossoverProbability)
    {
        ProbabilityValidator.Validate(
            crossoverProbability,
            nameof(crossoverProbability),
            "Вероятность скрещивания должна быть от 0 до 1.");

        CrossoverProbability = crossoverProbability;
    }

    /// <summary>
    /// Возвращает вероятность выполнения скрещивания.
    /// </summary>
    public double CrossoverProbability { get; }

    /// <summary>Возвращает двух потомков.</summary>
    /// <param name="parent1">Первый родитель.</param>
    /// <param name="parent2">Второй родитель.</param>
    /// <param name="rng">Генератор случайных чисел.</param>
    /// <returns>Два новых потомка или клоны родителей.</returns>
    /// <exception cref="ArgumentNullException">Родитель или генератор равен <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Родители имеют разную длину.</exception>
    public (Chromosome Child1, Chromosome Child2) Cross(
        Chromosome parent1,
        Chromosome parent2,
        Random rng)
    {
        CrossoverValidator.Validate(parent1, parent2, rng);

        if (rng.NextDouble() >= CrossoverProbability)
        {
            return (parent1.Clone(), parent2.Clone());
        }

        var child1Genes = new bool[parent1.Length];
        var child2Genes = new bool[parent1.Length];

        for (var i = 0; i < parent1.Length; i++)
        {
            if (rng.Next(2) == 0)
            {
                child1Genes[i] = parent1[i];
                child2Genes[i] = parent2[i];
            }
            else
            {
                child1Genes[i] = parent2[i];
                child2Genes[i] = parent1[i];
            }
        }

        return (new Chromosome(child1Genes), new Chromosome(child2Genes));
    }
}
