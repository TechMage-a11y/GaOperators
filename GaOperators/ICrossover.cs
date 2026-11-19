namespace GaOperators;

public interface ICrossover
{
    (Chromosome Child1, Chromosome Child2) Cross(
        Chromosome parent1,
        Chromosome parent2,
        Random rng);
}
