namespace GaOperators.Tests;

public class CrossoverTests
{
    [Fact]
    public void SinglePointCrossover_WithZeroProbabilityReturnsClones()
    {
        var parent1 = new Chromosome(new[] { true, true, false });
        var parent2 = new Chromosome(new[] { false, false, true });

        var (child1, child2) = new SinglePointCrossover(0).Cross(parent1, parent2, new Random(12));

        Assert.NotSame(parent1, child1);
        Assert.NotSame(parent2, child2);
        Assert.Equal(parent1.Genes, child1.Genes);
        Assert.Equal(parent2.Genes, child2.Genes);
    }

    [Fact]
    public void SinglePointCrossover_ExchangesGenesAfterBreakPoint()
    {
        var parent1 = new Chromosome(new[] { true, true, false, false });
        var parent2 = new Chromosome(new[] { false, false, true, true });

        var (child1, child2) = new SinglePointCrossover(1).Cross(
            parent1, parent2, new TestRandom(0, 2));

        Assert.Equal(new[] { true, true, true, true }, child1.Genes);
        Assert.Equal(new[] { false, false, false, false }, child2.Genes);
        Assert.Equal(new[] { true, true, false, false }, parent1.Genes);
        Assert.Equal(new[] { false, false, true, true }, parent2.Genes);
    }

    [Fact]
    public void SinglePointCrossover_WithOneGeneReturnsClones()
    {
        var parent1 = new Chromosome(new[] { true });
        var parent2 = new Chromosome(new[] { false });

        var (child1, child2) = new SinglePointCrossover(1).Cross(parent1, parent2, new Random(13));

        Assert.NotSame(parent1, child1);
        Assert.NotSame(parent2, child2);
        Assert.Equal(parent1.Genes, child1.Genes);
        Assert.Equal(parent2.Genes, child2.Genes);
    }

    [Fact]
    public void SinglePointCrossover_RejectsDifferentParentLengths()
    {
        var crossover = new SinglePointCrossover(1);
        var parent1 = new Chromosome(new[] { true });
        var parent2 = new Chromosome(new[] { true, false });

        Assert.Throws<ArgumentException>(() => crossover.Cross(parent1, parent2, new Random(14)));
    }

    [Fact]
    public void UniformCrossover_WithZeroProbabilityReturnsClones()
    {
        var parent1 = new Chromosome(new[] { true, false });
        var parent2 = new Chromosome(new[] { false, true });

        var (child1, child2) = new UniformCrossover(0).Cross(parent1, parent2, new Random(18));

        Assert.NotSame(parent1, child1);
        Assert.NotSame(parent2, child2);
        Assert.Equal(parent1.Genes, child1.Genes);
        Assert.Equal(parent2.Genes, child2.Genes);
    }

    [Fact]
    public void UniformCrossover_ExchangesSelectedGenesAndPreservesParents()
    {
        var parent1 = new Chromosome(new[] { true, false, true, false });
        var parent2 = new Chromosome(new[] { false, true, false, true });

        var (child1, child2) = new UniformCrossover(1).Cross(
            parent1, parent2, new TestRandom(0, 0, 1, 0, 1));

        Assert.Equal(new[] { true, true, true, true }, child1.Genes);
        Assert.Equal(new[] { false, false, false, false }, child2.Genes);
        Assert.Equal(new[] { true, false, true, false }, parent1.Genes);
        Assert.Equal(new[] { false, true, false, true }, parent2.Genes);
        Assert.Equal(parent1.Length, child1.Length);
        Assert.Equal(parent2.Length, child2.Length);
    }
}
