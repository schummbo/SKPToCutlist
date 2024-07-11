using SKPToCutlist.Common.List;

namespace SKPToCutlist.Common.CutlistWriters;

public class ConsoleWriter : ICutlistWriter
{
    public void Write(Cutlist cutlist)
    {
        foreach (var c in cutlist.GetCutlist().OrderBy(p => p.NominalDimension))
        {
            Console.WriteLine(c);
        }
    }
}
