namespace GaOperators;

/// <summary>Общий контракт оператора отбора.</summary>
public interface ISelection
{
    /// <summary>Выбирает индексы особей.</summary>
    /// <param name="population">Популяция для отбора.</param>
    /// <param name="count">Количество индексов, которые нужно выбрать.</param>
    /// <param name="rng">Генератор случайных чисел.</param>
    /// <returns>Индексы выбранных особей в исходной популяции.</returns>
    int[] Select(IReadOnlyList<Chromosome> population, int count, Random rng);
}
