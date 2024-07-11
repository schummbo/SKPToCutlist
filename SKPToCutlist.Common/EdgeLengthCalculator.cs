using SketchUpNET;

namespace SKPToCutlist.Common;

public static class EdgeLengthCalculator
{
    public static double CalculateLength(Vertex v1, Vertex v2)
    {
        double dx = v2.X - v1.X;
        double dy = v2.Y - v1.Y;
        double dz = v2.Z - v1.Z;

        var dist = Math.Sqrt(dx * dx + dy * dy + dz * dz);

        return Math.Round(MetersToInches(dist), 2);
    }

    private static double MetersToInches(double meters)
    {
        const double metersToInchesConversionFactor = 39.3701;
        return meters * metersToInchesConversionFactor;
    }
}