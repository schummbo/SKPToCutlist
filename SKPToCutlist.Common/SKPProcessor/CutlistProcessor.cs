using SketchUpNET;
using SKPToCutlist.Common.DimensionalLumber;
using SKPToCutlist.Common.List;

namespace SKPToCutlist.Common.SKPProcessor
{
    public class CutlistProcessor : ICutlistProcessor
    {
        private readonly Cutlist cutlist = new();

        public Cutlist Process(string path)
        {
            var sketchup = new SketchUp();

            LoadSketchupFile(path, sketchup);

            AddPartsFromGroups(sketchup.Groups);

            return cutlist;
        }

        private static void LoadSketchupFile(string path, SketchUp sketchup)
        {
            if (!Path.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            if (!sketchup.LoadModel(path))
            {
                throw new Exception($"Unable to load sketchup model at {path}");
            }

            if (!sketchup.Groups.Any())
            {
                throw new Exception("No groups found in SKP. Be sure pieces are grouped.");
            }
        }

        private void AddPartsFromGroups(IEnumerable<Group> groups)
        {
            foreach (var group in groups)
            {
                if (group.Surfaces.Count != 0)
                {
                    try
                    {
                        var part = GetCutlistPart(group);
                        cutlist.AddPart(part);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (group.Groups.Count != 0)
                {
                    AddPartsFromGroups(group.Groups);
                }
            }
        }

        private CutlistPart GetCutlistPart(Group group)
        {
            if (!DimensionHelper.TryGetNominalDimensionFromGroup(group, out NominalDimension dimension))
            {
                return new CutlistPart(NominalDimension.Irregular, -1);
            }

            if (!DimensionHelper.TryGetLengthOfGroup(group, dimension, out double length))
            {
                return new CutlistPart(dimension, -1);
            }

            return new CutlistPart(dimension, length);
        }
    }
}
