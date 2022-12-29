// See https://aka.ms/new-console-template for more information
char[] file = File.ReadAllText(@"..\..\..\..\..\..\txt\day3.txt").ToCharArray();

Console.WriteLine(file.Length);
List<house> houses = new List<house>();
houses.Add(new house() { x = 0, y = 0 });
int x = 0;
int y = 0;
foreach(char c in file)
{
    house house = new house();
    switch (c)
    {
        case '^':
            y++;
            house.x = x;
            house.y = y;
            break;
        case 'v':
            y--;
            house.x = x;
            house.y = y;
            break;
        case '>':
            x++;
            house.x = x;
            house.y = y;
            break;
        case '<':
            x--;
            house.x = x;
            house.y = y;
            break;
    }
    bool contained = false;
    foreach (house h in houses)
    {
        if (h.x == house.x && h.y == house.y)
        {
            contained = true;
        }
    }
    if (!contained)
    {
        houses.Add(house);
    }
}

Console.WriteLine(houses.Count);

class house
{
    public int x { get; set; }
    public int y { get; set; }
}
