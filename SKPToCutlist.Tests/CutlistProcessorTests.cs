using FluentAssertions;
using SKPToCutlist.Common.DimensionalLumber;
using SKPToCutlist.Common.List;
using SKPToCutlist.Common.SKPProcessor;

namespace SKPToCutlist.Tests
{
    [TestClass]
    public class CutlistProcessorTests
    {
        [TestMethod]
        public void ShouldGetOnePiece()
        {
            var c = GetCutlist("./SKPs/TwoByFour.skp");

            c.Count.Should().Be(1);

            var firstPiece = c.First();
            firstPiece.NominalDimension.Should().Be(NominalDimension.TwoByFour);
            firstPiece.Length.Should().Be(48);
        }

        [TestMethod]
        public void ShouldGetMultiplePieces()
        {
            var c = GetCutlist("./SKPs/MultiplePieces.skp");

            c.Count.Should().Be(5);

            Validate(c, NominalDimension.OneByTwo, 36, 1);
            Validate(c, NominalDimension.TwoByTwo, 12, 1);
            Validate(c, NominalDimension.TwoByFour, 24, 1);
            Validate(c, NominalDimension.TwoBySix, 72, 1);
            Validate(c, NominalDimension.FourByFour, 90, 1);
        }

        [TestMethod]
        public void ShouldGetPiecesWithinGroups()
        {
            var c = GetCutlist("./SKPs/PiecesInGroups.skp");

            c.Count.Should().Be(5);
        }

        [TestMethod]
        public void ShouldGetCubePieces()
        {
            var c = GetCutlist("./SKPs/Cube.skp");

            Validate(c, NominalDimension.FourByFour, 3.5, 1);
        }

        [TestMethod]
        public void ShouldNotGetIrregularPieces()
        {
            var c = GetCutlist("./SKPs/Irregular.skp");

            Validate(c, NominalDimension.Irregular, -1, 1);
        }


        private static void Validate(List<CutlistRow> c, NominalDimension nominalDimension, double length, int quantity)
        {
            var pieces = c.Where(x => x.NominalDimension == nominalDimension);
            pieces.Count().Should().Be(1);
            pieces.First().Should().BeEquivalentTo(new CutlistRow(nominalDimension, length, quantity));
        }

        private static List<CutlistRow> GetCutlist(string path)
        {
            ICutlistProcessor cutlistProcessor = CutlistProcessorFactory.CreateCutlistProcessor();
            var cutlist = cutlistProcessor.Process(path);
            return cutlist.GetCutlist();
        }
    }
}