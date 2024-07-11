using SKPToCutlist.Common.DimensionalLumber.Types;

namespace SKPToCutlist.Common.DimensionalLumber;

public static class DimensionalLumberFactory
{
    private static readonly Lazy<List<ILumberType>> allLumberTypes =
        new(() =>
        [
            new OneByTwo(),
            new OneBySix(),
            new TwoByTwo(),
            new TwoByFour(),
            new TwoBySix(),
            new FourByFour()
        ]);

    public static List<ILumberType> GetAllLumberTypes()
    {
        return allLumberTypes.Value;
    }
}
