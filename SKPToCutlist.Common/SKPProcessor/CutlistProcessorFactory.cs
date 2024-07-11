namespace SKPToCutlist.Common.SKPProcessor;

public static class CutlistProcessorFactory
{
    public static ICutlistProcessor CreateCutlistProcessor()
    {
        return new CutlistProcessor();
    }
}
