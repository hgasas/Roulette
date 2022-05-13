namespace VirtualRoulette.Common;

public static class MathHelper
{
    public static double CalculatePercentageOfNumber(double number, int percentage)
    {
        return number * percentage / 100;
    }
}