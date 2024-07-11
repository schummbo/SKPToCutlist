namespace SKPToCutlist.Common.List;

public class Cutlist
{
    private readonly Dictionary<CutlistPart, int> cutlist = new Dictionary<CutlistPart, int>();

    public void AddPart(CutlistPart part)
    {
        if (cutlist.ContainsKey(part))
        {
            cutlist[part]++;
        }
        else
        {
            cutlist[part] = 1;
        }
    }

    public List<CutlistRow> GetCutlist()
    {
        var cutlistRows = new List<CutlistRow>();

        foreach (var part in cutlist.Keys)
        {
            cutlistRows.Add(new CutlistRow(part.NominalDimension, part.Length, cutlist[part]));
        }

        return cutlistRows;
    }
}
