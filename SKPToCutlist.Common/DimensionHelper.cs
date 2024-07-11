using SketchUpNET;
using SKPToCutlist.Common.DimensionalLumber;

namespace SKPToCutlist.Common;

public static class DimensionHelper
{
    public static bool TryGetNominalDimensionFromGroup(Group group, out NominalDimension dimension)
    {
        foreach (Surface surface in group.Surfaces)
        {
            if (TryGetNominalDimension(group, surface, out dimension))
            {
                return true;
            }
        }

        dimension = NominalDimension.Irregular;

        return false;
    }

    public static bool TryGetNominalDimension(Group group, Surface surface, out NominalDimension dimension)
    {
        foreach (ILumberType lumberType in DimensionalLumberFactory.GetAllLumberTypes())
        {
            if (lumberType.IsSurfaceLumberType(new SurfaceContext(surface, group.Transformation)))
            {
                dimension = lumberType.NominalDimension;
                return true;
            }
        }

        dimension = NominalDimension.Irregular;
        return false;
    }

    public static bool TryGetLengthOfGroup(Group group, NominalDimension dimension, out double length)
    {
        double? objectLength = null;

        foreach (var surface in group.Surfaces)
        {
            // get the surface that isn't the nominal dimension
            if (!TryGetNominalDimension(group, surface, out _))
            {
                foreach (var edge in surface.OuterEdges.Edges)
                {
                    var edgeLength = EdgeLengthCalculator.CalculateLength(group.Transformation.GetTransformed(edge.Start), group.Transformation.GetTransformed(edge.End));

                    // get the length that isn't part of the nominal dimension
                    if (!IsNominalLength(dimension, edgeLength))
                    {
                        length = edgeLength;
                        return true;
                    }
                }

                // its at least a square
                if (objectLength == null)
                {
                    double maxLength = -1;
                    foreach (var edge in surface.OuterEdges.Edges)
                    {
                        var l = EdgeLengthCalculator.CalculateLength(group.Transformation.GetTransformed(edge.Start), group.Transformation.GetTransformed(edge.End));

                        if (l > maxLength)
                        {
                            maxLength = l;
                        }
                    }

                    length = maxLength;
                    return true;
                }


            }
        }

        // its a cube?  just pick a side
        if (objectLength == null)
        {
            var edge = group.Surfaces[0].OuterEdges.Edges[0];

            length = EdgeLengthCalculator.CalculateLength(group.Transformation.GetTransformed(edge.Start), group.Transformation.GetTransformed(edge.End));
            return true;
        }

        length = 0;
        return false;
    }

    private static bool IsNominalLength(NominalDimension dimension, double edgeLength)
    {
        return dimension switch
        {
            NominalDimension.OneByTwo => edgeLength == .75 || edgeLength == 1.5,
            NominalDimension.TwoByTwo => edgeLength == 1.5,
            NominalDimension.TwoByFour => edgeLength == 1.5 || edgeLength == 3.5,
            NominalDimension.TwoBySix => edgeLength == 1.5 || edgeLength == 5.5,
            NominalDimension.FourByFour => edgeLength == 3.5,
            _ => false,
        };
    }
}
