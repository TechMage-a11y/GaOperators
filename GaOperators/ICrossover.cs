namespace GaOperators;

/// <summary>Общий контракт оператора скрещивания.</summary>
public interface ICrossover
{
    /// <summary>Создаёт двух потомков.</summary>
    /// <param name="parent1">Первый родитель.</param>
    /// <param name="parent2">Второй родитель.</param>
    /// <param name="rng">Генератор случайных чисел.</param>
    /// <returns>Пара новых хромосом-потомков.</returns>
    (Chromosome Child1, Chromosome Child2) Cross(
        Chromosome parent1,
        Chromosome parent2,
        Random rng);
}
