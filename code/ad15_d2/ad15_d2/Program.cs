// See https://aka.ms/new-console-template for more information
string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day2.txt");

//string[] file = new string[] { "2x3x4", "1x1x10" };
int totalPaper = 0;
int totalRibbon = 0;
foreach(string line in file)
{
    string[] measurements = line.Split('x');
    int length = Int32.Parse(measurements[0]);
    int width = Int32.Parse(measurements[1]);
    int height = Int32.Parse(measurements[2]);
    totalPaper += paperCalculator(length, width, height);
    totalRibbon += ribbonCalculator(length, width, height);
}
Console.WriteLine("paper " + totalPaper);
Console.WriteLine("ribbon " + totalRibbon);
int paperCalculator (int lenght, int width, int height)
{
    int[]  areas = new int[3];
    areas[0] = lenght * width;
    areas[1] = width * height;
    areas[2] = height * lenght;
    int boxArea = 2 * areas[0]+ 2 * areas[1] + 2 * areas[2];
    int paper = boxArea + areas.Min();
    return paper ;
}

int ribbonCalculator(int lenght, int width, int height)
{
    int[] perimeter = new int[3];
    perimeter[0] = 2 * lenght + 2* width;
    perimeter[1] = 2 * width + 2 * height;
    perimeter[2] = 2 * height + 2 * lenght;
    int ribbon = perimeter.Min();
    int withBow = ribbon + (lenght * width * height);

    return withBow;
}