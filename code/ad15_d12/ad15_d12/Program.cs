// See https://aka.ms/new-console-template for more information
string input = File.ReadAllText(@"..\..\..\..\..\..\txt\day12.txt");

string[] parts = input.Split(new string[] { "[", "{", "]", "}", ":", ","}, StringSplitOptions.RemoveEmptyEntries);
long total = 0;
foreach(string part in parts)
{
    if (int.TryParse(part, out _))
    {
        Console.WriteLine(part);
        total += int.Parse(part);
    }
}
Console.WriteLine(total);