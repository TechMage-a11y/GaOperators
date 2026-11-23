namespace GaOperators;

/// <summary>Скрещивает хромосомы в одной случайной точке.</summary>
public sealed class SinglePointCrossover : ICrossover
{
    /// <summary>Создаёт оператор скрещивания.</summary>
    /// <param name="crossoverProbability">Вероятность выполнения скрещивания.</param>
    /// <exception cref="ArgumentOutOfRangeException">Вероятность не входит в диапазон от 0 до 1.</exception>
    public SinglePointCrossover(double crossoverProbability)
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

    /// <summary>Возвращает потомков после обмена частей родителей.</summary>
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

        if (rng.NextDouble() >= CrossoverProbability || parent1.Length == 1)
        {
            return (parent1.Clone(), parent2.Clone());
        }

        var point = rng.Next(1, parent1.Length);
        var parent1Genes = parent1.Genes;
        var parent2Genes = parent2.Genes;

        for (var i = point; i < parent1.Length; i++)
        {
            (parent1Genes[i], parent2Genes[i]) = (parent2Genes[i], parent1Genes[i]);
        }

        return (new Chromosome(parent1Genes), new Chromosome(parent2Genes));
    }
}
