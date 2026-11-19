namespace GaOperators;

public sealed class SinglePointCrossover : ICrossover
{
    public SinglePointCrossover(double crossoverProbability)
    {
        if (double.IsNaN(crossoverProbability) || crossoverProbability < 0.0 || crossoverProbability > 1.0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(crossoverProbability),
                "Вероятность скрещивания должна находиться в диапазоне от 0 до 1 включительно.");
        }

        CrossoverProbability = crossoverProbability;
    }

    public double CrossoverProbability { get; }

    public (Chromosome Child1, Chromosome Child2) Cross(
        Chromosome parent1,
        Chromosome parent2,
        Random rng)
    {
        ArgumentNullException.ThrowIfNull(parent1);
        ArgumentNullException.ThrowIfNull(parent2);
        ArgumentNullException.ThrowIfNull(rng);

        if (parent1.Length != parent2.Length)
        {
            throw new ArgumentException("Родители должны иметь одинаковую длину хромосомы.");
        }

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
