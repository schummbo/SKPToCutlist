namespace SKPToCutlist.Common.DimensionalLumber.Types;

public class TwoBySix : RectangularLumberBase, ILumberType
{
    public override NominalDimension NominalDimension => NominalDimension.TwoBySix;

    public override double Height => 1.5;

    public override double Width => 5.5;
}
