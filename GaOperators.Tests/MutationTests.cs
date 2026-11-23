namespace GaOperators.Tests;

public class MutationTests
{
    [Fact]
    public void BitFlipMutation_WithZeroProbabilityReturnsClone()
    {
        var source = new Chromosome(new[] { true, false, true }) { Fitness = 2.0 };

        var result = new BitFlipMutation(0).Mutate(source, new Random(11));

        Assert.NotSame(source, result);
        Assert.Equal(source.Genes, result.Genes);
        Assert.Equal(source.Fitness, result.Fitness);
    }

    [Fact]
    public void BitFlipMutation_WithProbabilityOneFlipsEveryGene()
    {
        var source = new Chromosome(new[] { true, false, true });

        var result = new BitFlipMutation(1).Mutate(source, new Random(11));

        Assert.Equal(new[] { false, true, false }, result.Genes);
        Assert.Equal(new[] { true, false, true }, source.Genes);
    }

    [Theory]
    [InlineData(-0.1)]
    [InlineData(1.1)]
    [InlineData(double.NaN)]
    public void BitFlipMutation_RejectsInvalidProbability(double probability)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new BitFlipMutation(probability));
    }
}
