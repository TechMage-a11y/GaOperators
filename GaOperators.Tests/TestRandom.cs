namespace GaOperators.Tests;

internal sealed class TestRandom(double nextDouble, params int[] nextValues) : Random
{
    private readonly Queue<int> _nextValues = new(nextValues);

    public override double NextDouble() => nextDouble;

    public override int Next(int maxValue) => Next(0, maxValue);

    public override int Next(int minValue, int maxValue)
    {
        if (!_nextValues.TryDequeue(out var value) || value < minValue || value >= maxValue)
        {
            throw new InvalidOperationException("Неожиданный вызов генератора случайных чисел.");
        }

        return value;
    }
}
