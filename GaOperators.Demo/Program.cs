using GaOperators;

var rng = new Random(42);

var population = new[]
{
    CreateChromosome([true, false, true, false], 1.5),
    CreateChromosome([false, true, false, true], 3.8),
    CreateChromosome([true, true, false, false], 2.7),
    CreateChromosome([false, false, true, true], 4.2)
};

Console.WriteLine("Популяция:");
PrintPopulation(population);

ISelection selection = new TournamentSelection(tournamentSize: 2);
var parentIndices = selection.Select(population, count: 2, rng);

var parent1 = population[parentIndices[0]];
var parent2 = population[parentIndices[1]];

Console.WriteLine($"\nВыбранные родители: {parentIndices[0]} и {parentIndices[1]}");
PrintChromosome("Родитель 1", parent1);
PrintChromosome("Родитель 2", parent2);

ICrossover crossover = new SinglePointCrossover(crossoverProbability: 0.9);
var (child1, child2) = crossover.Cross(parent1, parent2, rng);

Console.WriteLine("\nПотомки после одноточечного скрещивания:");
PrintChromosome("Потомок 1", child1);
PrintChromosome("Потомок 2", child2);

IMutation mutation = new BitFlipMutation(mutationProbability: 0.25);
var mutated = mutation.Mutate(child1, rng);


Console.WriteLine("\nПотомок после мутации:");
PrintChromosome("Мутант", mutated);

static Chromosome CreateChromosome(bool[] genes, double fitness)
{
    return new Chromosome(genes)
    {
        Fitness = fitness
    };
}

static void PrintPopulation(IReadOnlyList<Chromosome> population)
{
    for (var i = 0; i < population.Count; i++)
    {
        Console.Write($"{i}: ");
        PrintGenes(population[i]);
        Console.WriteLine($" Fitness={population[i].Fitness}");
    }
}

static void PrintChromosome(string name, Chromosome chromosome)
{
    Console.Write($"{name}: ");
    PrintGenes(chromosome);
    Console.WriteLine($" Fitness={chromosome.Fitness}");
}

static void PrintGenes(Chromosome chromosome)
{
    foreach (var gene in chromosome.Genes)
    {
        Console.Write(gene ? '1' : '0');
    }
}
