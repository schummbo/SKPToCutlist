namespace SKPToCutlist.Common.DimensionalLumber.Types;

public class TwoByTwo : SquareLumberBase, ILumberType
{
    public override NominalDimension NominalDimension => NominalDimension.TwoByTwo;

    public override double Height => 1.5;

    public override double Width => 1.5;
}
