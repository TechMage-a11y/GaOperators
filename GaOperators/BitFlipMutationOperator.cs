namespace GaOperators;

/// <summary>Меняет отдельные гены с заданной вероятностью.</summary>
public sealed class BitFlipMutation : IMutation
{
    /// <summary>Создаёт оператор мутации.</summary>
    /// <param name="mutationProbability">Вероятность инвертировать каждый отдельный ген.</param>
    /// <exception cref="ArgumentOutOfRangeException">Вероятность не входит в диапазон от 0 до 1.</exception>
    public BitFlipMutation(double mutationProbability)
    {
        ProbabilityValidator.Validate(
            mutationProbability,
            nameof(mutationProbability),
            "Вероятность мутации должна быть от 0 до 1.");

        MutationProbability = mutationProbability;
    }

    /// <summary>Вероятность инвертирования каждого гена.</summary>
    public double MutationProbability { get; }

    /// <summary>Возвращает копию хромосомы после мутации.</summary>
    /// <param name="source">Исходная хромосома.</param>
    /// <param name="rng">Генератор случайных чисел.</param>
    /// <returns>Новая хромосома после мутации.</returns>
    /// <exception cref="ArgumentNullException">Хромосома или генератор равен <see langword="null"/>.</exception>
    public Chromosome Mutate(Chromosome source, Random rng)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(rng);

        var result = source.Clone();

        for (var i = 0; i < result.Length; i++)
        {
            if (rng.NextDouble() < MutationProbability)
            {
                result.SetGene(i, !result[i]);
            }
        }

        return result;
    }
}
