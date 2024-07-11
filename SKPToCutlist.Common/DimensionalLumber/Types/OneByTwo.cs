namespace SKPToCutlist.Common.DimensionalLumber.Types;

public class OneByTwo : RectangularLumberBase, ILumberType
{
    public override NominalDimension NominalDimension => NominalDimension.OneByTwo;

    public override double Height => .75;

    public override double Width => 1.5;
}
