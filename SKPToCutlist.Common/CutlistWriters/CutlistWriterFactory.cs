namespace SKPToCutlist.Common.CutlistWriters;

public static class CutlistWriterFactory
{
    public static ICutlistWriter CreateCutlistWriter()
    {
        return new ConsoleWriter();
    }
}
