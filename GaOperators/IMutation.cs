namespace GaOperators;

public interface IMutation
{
    Chromosome Mutate(Chromosome source, Random rng);
}
