namespace GaOperators;

public sealed class BitFlipMutation : IMutation
{
    public BitFlipMutation(double mutationProbability)
    {
        if (double.IsNaN(mutationProbability) || mutationProbability < 0.0 || mutationProbability > 1.0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(mutationProbability),
                "Вероятность мутации должна находиться в диапазоне от 0 до 1 включительно.");
        }

        MutationProbability = mutationProbability;
    }

    public double MutationProbability { get; }

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
