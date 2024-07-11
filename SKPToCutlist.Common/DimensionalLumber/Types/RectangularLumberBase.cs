using SketchUpNET;

namespace SKPToCutlist.Common.DimensionalLumber.Types;

public abstract class RectangularLumberBase : ILumberType
{
    public abstract NominalDimension NominalDimension { get; }

    public abstract double Height { get; }

    public abstract double Width { get; }

    public bool IsSurfaceLumberType(SurfaceContext surfaceContext)
    {
        return HasTwoEdgesMatching(surfaceContext, Width) && HasTwoEdgesMatching(surfaceContext, Height);
    }

    private bool HasTwoEdgesMatching(SurfaceContext surfaceContext, double dimension)
    {
        return surfaceContext.Surface.OuterEdges.Edges.Count(edge =>
            EdgeLengthCalculator.CalculateLength(
                surfaceContext.Transformation.GetTransformed(edge.Start),
                surfaceContext.Transformation.GetTransformed(edge.End)) == dimension) == 2;
    }
}
