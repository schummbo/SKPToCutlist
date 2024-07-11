namespace SKPToCutlist.Common.DimensionalLumber.Types;

public class OneBySix : RectangularLumberBase, ILumberType
{
    public override NominalDimension NominalDimension => NominalDimension.OneBySix;

    public override double Height => .75;

    public override double Width => 5.5;
}
