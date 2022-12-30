// See https://aka.ms/new-console-template for more information
string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day5.txt");
int nice = 0;
foreach(string line in file)
{
    int vowels = 0;
    bool duplicate = false;
    bool naughty = false;
    char lastChar = '\0';
    char[] chars = line.ToCharArray();
    Console.WriteLine("chars " + chars.Length);
    foreach (char c in chars)
    {
        if(c == 'a' || c == 'e'|| c == 'i' || c == 'o' || c == 'u') vowels++;
        if(lastChar != '\0')
        {
            if(c == lastChar)
            {
                duplicate= true;
            }

            char[] two = { lastChar, c };
            string s = new string(two);
            if( s == "ab" || s == "cd" || s == "pq" || s == "xy")
            {
                naughty= true;
            }
        }
        lastChar= c;
    }
    if(vowels >= 3 && duplicate && !naughty)
    {
        nice++;
    }
}
Console.WriteLine(nice);