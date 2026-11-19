namespace GaOperators;

public interface ISelection
{
    int[] Select(IReadOnlyList<Chromosome> population, int count, Random rng);
}
