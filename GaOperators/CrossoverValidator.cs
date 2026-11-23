namespace GaOperators;

internal static class CrossoverValidator
{
    public static void Validate(Chromosome parent1, Chromosome parent2, Random rng)
    {
        ArgumentNullException.ThrowIfNull(parent1);
        ArgumentNullException.ThrowIfNull(parent2);
        ArgumentNullException.ThrowIfNull(rng);

        if (parent1.Length != parent2.Length)
        {
            throw new ArgumentException("Родители должны иметь одинаковую длину хромосомы.");
        }
    }
}
