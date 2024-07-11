namespace SKPToCutlist.Common.DimensionalLumber.Types;

public abstract class SquareLumberBase : ILumberType
{
    public abstract NominalDimension NominalDimension { get; }

    public abstract double Height { get; }

    public abstract double Width { get; }

    public bool IsSurfaceLumberType(SurfaceContext surfaceContext)
    {
        return surfaceContext.Surface.OuterEdges.Edges.Count(edge =>
        EdgeLengthCalculator.CalculateLength(
            surfaceContext.Transformation.GetTransformed(edge.Start),
            surfaceContext.Transformation.GetTransformed(edge.End)) == Height) == 4;
    }
}
