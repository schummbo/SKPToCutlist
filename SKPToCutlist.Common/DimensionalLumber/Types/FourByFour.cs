namespace SKPToCutlist.Common.DimensionalLumber.Types;
public class FourByFour : SquareLumberBase, ILumberType
{
    public override NominalDimension NominalDimension => NominalDimension.FourByFour;

    public override double Height => 3.5;

    public override double Width => 3.5;
}
