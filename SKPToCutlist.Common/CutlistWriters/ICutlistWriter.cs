using SKPToCutlist.Common.List;

namespace SKPToCutlist.Common.CutlistWriters;

public interface ICutlistWriter
{
    void Write(Cutlist cutlist);
}
