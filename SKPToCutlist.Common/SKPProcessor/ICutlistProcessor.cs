using SKPToCutlist.Common.List;

namespace SKPToCutlist.Common.SKPProcessor;

public interface ICutlistProcessor
{
    Cutlist Process(string path);
}