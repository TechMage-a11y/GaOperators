namespace GaOperators;

/// <summary>Выбирает особей с помощью турниров.</summary>
public sealed class TournamentSelection : ISelection
{
    /// <summary>Создаёт оператор отбора.</summary>
    /// <param name="tournamentSize">Количество различных участников каждого турнира.</param>
    /// <exception cref="ArgumentOutOfRangeException">Размер турнира меньше двух.</exception>
    public TournamentSelection(int tournamentSize)
    {
        if (tournamentSize < 2)
        {
            throw new ArgumentOutOfRangeException(
                nameof(tournamentSize),
                "Размер турнира должен быть не меньше 2.");
        }

        TournamentSize = tournamentSize;
    }

    /// <summary>Количество участников в каждом турнире.</summary>
    public int TournamentSize { get; }

    /// <summary>Возвращает индексы победителей заданного числа турниров.</summary>
    /// <param name="population">Популяция для отбора.</param>
    /// <param name="count">Количество турниров.</param>
    /// <param name="rng">Генератор случайных чисел.</param>
    /// <returns>Индексы победителей в порядке проведения турниров.</returns>
    /// <exception cref="ArgumentNullException">Популяция или генератор равны <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Популяция пуста.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Количество отрицательно или размер турнира превышает популяцию.</exception>
    public int[] Select(IReadOnlyList<Chromosome> population, int count, Random rng)
    {
        ArgumentNullException.ThrowIfNull(population);
        ArgumentNullException.ThrowIfNull(rng);

        if (population.Count == 0)
        {
            throw new ArgumentException("Популяция не должна быть пустой.", nameof(population));
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Количество турниров не может быть отрицательным.");
        }

        if (TournamentSize > population.Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(population),
                "Размер турнира не может превышать размер популяции.");
        }

        var winners = new int[count];
        var participants = new int[population.Count];

        for (var tournament = 0; tournament < count; tournament++)
        {
            for (var i = 0; i < participants.Length; i++)
            {
                participants[i] = i;
            }

            var winner = -1;
            for (var i = 0; i < TournamentSize; i++)
            {
                var selectedPosition = rng.Next(i, participants.Length);
                (participants[i], participants[selectedPosition]) =
                    (participants[selectedPosition], participants[i]);

                var candidate = participants[i];
                if (winner == -1 || population[candidate].Fitness > population[winner].Fitness)
                {
                    winner = candidate;
                }
            }

            winners[tournament] = winner;
        }

        return winners;
    }
}
