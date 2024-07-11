using SKPToCutlist.Common.DimensionalLumber;

namespace SKPToCutlist.Common.List;

public record CutlistRow(NominalDimension NominalDimension, double Length, int Quantity)
{
}
