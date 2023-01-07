// See https://aka.ms/new-console-template for more information
string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day7.txt");

Dictionary<string, int> map = new Dictionary<string, int>();
bool linesToRun = true;

List<string> rejects = bitOporator(file);
while(rejects.Count > 0)
{
    rejects = bitOporator(rejects.ToArray());
    Console.WriteLine(rejects.Count);
}


foreach(KeyValuePair<string, int> pair in map)
{
    Console.WriteLine("wire " + pair.Key + " value " + pair.Value);
}


List<string> bitOporator(string[] lines)
{
    List<string> Rejects = new List<string>();
    foreach (string line in lines)
    {
        string[] parts = line.Split(new string[] { " -> ", " " }, StringSplitOptions.None);

        switch (line)
        {
            case string x when line.Contains("RSHIFT"):
                try
                {
                    int PreValue = map[parts[0]];
                    map.Add(parts[3], PreValue >> Int32.Parse(parts[2]));
                }
                catch
                {
                    Rejects.Add(line);
                }
                break;
            case string x when line.Contains("LSHIFT"):
                try
                {
                    int PreValue = map[parts[0]];
                    map.Add(parts[3], PreValue << Int32.Parse(parts[2]));
                }
                catch
                {
                    Rejects.Add(line);
                }
                break;
            case string x when line.Contains("AND"):
                try
                {
                    try
                    {
                        int valueOne = Int32.Parse(parts[0]);
                        int valueTwo = map[parts[2]];
                        map.Add(parts[3], valueOne & valueTwo);
                    }
                    catch
                    {
                        int valueOne = map[parts[0]];
                        int valueTwo = map[parts[2]];
                        map.Add(parts[3], valueOne & valueTwo);
                    }
                }
                catch
                {
                    Rejects.Add(line);
                }
                break;
            case string x when line.Contains("OR"):
                try
                {
                    int valueOne = map[parts[0]];
                    int valueTwo = map[parts[2]];
                    map.Add(parts[3], valueOne ^ valueTwo);
                }
                catch
                {
                    Rejects.Add(line);
                }
                break;
            case string x when line.Contains("NOT"):
                try
                {
                    int valueOne = map[parts[1]];
                    map.Add(parts[2], ~valueOne);
                }
                catch
                {
                    Rejects.Add(line);
                }
                break;
            default:
                try
                {
                    int value = Int32.Parse(parts[0]);
                    map.Add(parts[1], value);
                }
                catch
                {
                    try
                    {
                        int value = map[parts[0]];
                        map.Add(parts[1], value);
                    }
                    catch
                    {
                        Rejects.Add(line);
                    }
                }
                break;
        }
    }

    return Rejects;
}