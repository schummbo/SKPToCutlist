using SKPToCutlist.Common.CutlistWriters;
using SKPToCutlist.Common.SKPProcessor;

namespace SKPToCutlist;

internal class Program
{
    static void Main(string[] args)
    {
        ICutlistProcessor s2c = CutlistProcessorFactory.CreateCutlistProcessor();
        Common.List.Cutlist cutlist = s2c.Process(args[0]);

        ICutlistWriter cutlistWriter = CutlistWriterFactory.CreateCutlistWriter();
        cutlistWriter.Write(cutlist);
    }
}
