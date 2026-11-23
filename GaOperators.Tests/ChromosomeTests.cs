namespace GaOperators.Tests;

public class ChromosomeTests
{
    [Fact]
    public void Clone_CopiesGenesAndFitness()
    {
        var input = new[] { true, false, true };
        var chromosome = new Chromosome(input) { Fitness = 3.5 };
        input[0] = false;

        var clone = chromosome.Clone();
        var cloneGenes = clone.Genes;
        cloneGenes[0] = false;

        Assert.NotSame(chromosome, clone);
        Assert.Equal(new[] { true, false, true }, chromosome.Genes);
        Assert.Equal(new[] { true, false, true }, clone.Genes);
        Assert.Equal(chromosome.Fitness, clone.Fitness);
        Assert.Equal(3, chromosome.Length);
    }

    [Fact]
    public void Constructor_RejectsNullAndEmptyGenes()
    {
        Assert.Throws<ArgumentNullException>(() => new Chromosome(null!));
        Assert.Throws<ArgumentException>(() => new Chromosome(Array.Empty<bool>()));
    }
}
