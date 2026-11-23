namespace GaOperators;

internal static class ProbabilityValidator
{
    public static void Validate(double probability, string parameterName, string message)
    {
        if (double.IsNaN(probability) || probability < 0.0 || probability > 1.0)
        {
            throw new ArgumentOutOfRangeException(parameterName, message);
        }
    }
}
