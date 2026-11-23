namespace GaOperators.Tests;

public class SelectionTests
{
    [Fact]
    public void TournamentSelection_ReturnsValidIndicesAndIsReproducible()
    {
        var population = CreatePopulation();
        var selection = new TournamentSelection(2);

        var first = selection.Select(population, 20, new Random(15));
        var second = selection.Select(population, 20, new Random(15));

        Assert.Equal(20, first.Length);
        Assert.All(first, index => Assert.InRange(index, 0, population.Length - 1));
        Assert.Equal(first, second);
    }

    [Fact]
    public void TournamentSelection_SelectsBestMemberOfEachTournament()
    {
        var population = CreatePopulation();

        var winners = new TournamentSelection(2).Select(
            population, 2, new TestRandom(0, 0, 2, 1, 3));

        Assert.Equal(new[] { 2, 3 }, winners);
    }

    [Fact]
    public void TournamentSelection_ValidatesArguments()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new TournamentSelection(1));

        var selection = new TournamentSelection(2);
        Assert.Throws<ArgumentException>(() => selection.Select(
            Array.Empty<Chromosome>(), 0, new Random(16)));
        Assert.Throws<ArgumentOutOfRangeException>(() => selection.Select(
            new[] { new Chromosome(new[] { true }) }, 1, new Random(16)));
        Assert.Throws<ArgumentOutOfRangeException>(() => selection.Select(
            CreatePopulation(), -1, new Random(16)));
    }

    [Fact]
    public void TournamentSelection_AllowsZeroCount()
    {
        var result = new TournamentSelection(2).Select(CreatePopulation(), 0, new Random(17));

        Assert.Empty(result);
    }

    private static Chromosome[] CreatePopulation()
    {
        return new[]
        {
            new Chromosome(new[] { false }) { Fitness = 1 },
            new Chromosome(new[] { false }) { Fitness = 2 },
            new Chromosome(new[] { false }) { Fitness = 3 },
            new Chromosome(new[] { false }) { Fitness = 4 }
        };
    }
}
