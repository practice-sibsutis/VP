// See https://aka.ms/new-console-template for more information
using System.Text;
using ShapeLibrary.Exeptions;
using ShapeLibrary.FileReaders;
using ShapeLibrary.FileReaders.WKTFileReaders;
using ShapeLibrary.IntersectionCheckers;
using ShapeLibrary.IntersectionCheckers.PairShapesIntersectionCheckers;
using ShapeLibrary.Parsers.BaseParsers;
using ShapeLibrary.Parsers.WKTParsers.ShapeParsers;
using ShapeLibrary.Shapes;
using ShapeMain.RunningModes;

List<IShapeParser> parsers = new List<IShapeParser>();
parsers.Add(new CircleWktParser());

ShapesParser shapesParser = new ShapesParser(parsers);

List<IPairShapesIntersectionChecker> pairShapesIntersectionCheckers = new List<IPairShapesIntersectionChecker>();
pairShapesIntersectionCheckers.Add(new CircleCircleIntersectionChecker());

IShapesIntersectionChecker shapesIntersectionChecker = new ShapeIntersectionChecker(pairShapesIntersectionCheckers);



switch (args.Length)
{
    //from stdin
    case 0:
        InteractiveRunningMode runnigMode = new InteractiveRunningMode(shapesParser, shapesIntersectionChecker);
        runnigMode.Run();
        break;

    //from file
    case 1:
        try
        {
            IShapesFileReader shapesFileReader = new WktShapesFileReader(shapesParser);
            ProcessingFileRunningMode runningmode = new ProcessingFileRunningMode(
                shapesFileReader, shapesIntersectionChecker, args[0]);

            runningmode.Run();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File not found: {ex.FileName}");
            return;
        }

        break;

    default:
        return;
}