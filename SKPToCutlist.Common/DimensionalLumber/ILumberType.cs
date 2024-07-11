using SketchUpNET;

namespace SKPToCutlist.Common.DimensionalLumber;

public interface ILumberType
{
    NominalDimension NominalDimension { get; }

    double Height { get; }

    double Width { get; }

    bool IsSurfaceLumberType(SurfaceContext surface);
}
