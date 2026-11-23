namespace GaOperators;

/// <summary>Общий контракт оператора мутации.</summary>
public interface IMutation
{
    /// <summary>Возвращает копию хромосомы после мутации.</summary>
    /// <param name="source">Исходная хромосома.</param>
    /// <param name="rng">Генератор случайных чисел.</param>
    /// <returns>Новая хромосома после мутации.</returns>
    Chromosome Mutate(Chromosome source, Random rng);
}
