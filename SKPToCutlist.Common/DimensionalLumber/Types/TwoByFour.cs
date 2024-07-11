namespace SKPToCutlist.Common.DimensionalLumber.Types;

public class TwoByFour : RectangularLumberBase, ILumberType
{
    public override NominalDimension NominalDimension => NominalDimension.TwoByFour;

    public override double Height => 1.5;

    public override double Width => 3.5;
}
