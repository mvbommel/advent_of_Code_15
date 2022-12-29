// See https://aka.ms/new-console-template for more information
char[] file = File.ReadAllText(@"..\..\..\..\..\..\txt\day3.txt").ToCharArray();

Console.WriteLine(file.Length);
List<house> houses = new List<house>();
houses.Add(new house() { x = 0, y = 0 });
int santaX = 0;
int santaY = 0;
int robotX = 0;
int robotY = 0;
for (int i = 0; i < file.Length; i++)
{
    house house = new house();
    if (i % 2 == 0)
    {
        switch (file[i])
        {
            case '^':
                robotY++;
                house.x = robotX;
                house.y = robotY;
                break;
            case 'v':
                robotY--;
                house.x = robotX;
                house.y = robotY;
                break;
            case '>':
                robotX++;
                house.x = robotX;
                house.y = robotY;
                break;
            case '<':
                robotX--;
                house.x = robotX;
                house.y = robotY;
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
    else
    {
        switch (file[i])
        {
            case '^':
                santaY++;
                house.x = santaX;
                house.y = santaY;
                break;
            case 'v':
                santaY--;
                house.x = santaX;
                house.y = santaY;
                break;
            case '>':
                santaX++;
                house.x = santaX;
                house.y = santaY;
                break;
            case '<':
                santaX--;
                house.x = santaX;
                house.y = santaY;
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
}

Console.WriteLine(houses.Count);

class house
{
    public int x { get; set; }
    public int y { get; set; }
}
