// See https://aka.ms/new-console-template for more information
string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day5.txt");
Console.WriteLine(file.Length);
int nice = 0;
// string[] file = { "qjhvhtzxzqqjkmpb", "xxyxx", "uurcxstgmygtbstg", "ieodomkazucvgmuy" };

foreach(string line in file)
{
    List<string> pairs = new List<string>();
    bool duplicatePair = false;
    bool duplicateLetter = false;
    char lastChar = '\0';
    char oneBefore = '\0';
    char[] chars = line.ToCharArray();
    for(int i = 0; i < chars.Length-1; i++)
    {
        string pair = line.Substring(i, 2);
        if(line.IndexOf(pair, i+2)!= -1)
        {
            duplicatePair = true;
        }
    }

    foreach (char c in chars)
    {
        if(c == oneBefore)
        {
            duplicateLetter= true;
        }
        oneBefore = lastChar;
        lastChar= c;
    }

    if(duplicateLetter && duplicatePair)
    {
        nice++;
        Console.WriteLine(line);
    }
    
}
Console.WriteLine(nice);