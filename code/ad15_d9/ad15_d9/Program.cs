﻿// See https://aka.ms/new-console-template for more information
List<Connection> GetAdjecentConnections(Location location, List<Connection> connections, List<Location> locations)
{
    List<Connection> adjecent = new List<Connection>();

    foreach(Connection connection in connections)
    {
        if(connection.placeA.name == location.name)
        {
            Location b = locations.Find(x => x.name == connection.placeB.name);
            if (!b.visited)
            {
                adjecent.Add(connection);
            }
        }
        if (connection.placeB.name == location.name)
        {
            Location a = locations.Find(x => x.name == connection.placeA.name);
            if (!a.visited)
            {
                adjecent.Add(connection);
            }
        }
    }
}

string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day9.txt");

List<Connection> connections = new List<Connection>();
List<Location> locations = new List<Location>();
foreach (string line in file)
{
    string[] parts = line.Split(new string[] { " to ", " = " }, StringSplitOptions.RemoveEmptyEntries);
    Connection connection = new Connection();
    Location locationA = new Location { name = parts[0], visited = false };
    connection.placeA = locationA;
    Location locationB = new Location { name = parts[1], visited = false };
    connection.placeB = locationB;
    connection.weight =Int32.Parse(parts[2]);
    connections.Add(connection);
    if (!locations.Any(x => x.name == locationA.name))
    {
        locations.Add(locationA);
    }
    if(!locations.Any(x => x.name == locationB.name)) 
    { 
        locations.Add(locationB); 
    }
}

foreach(Connection connection in connections)
{
    Console.WriteLine(connection.placeA.name + " to " + connection.placeB.name + ", weight " + connection.weight);
}
Console.WriteLine(locations.Count);

class Connection
{
    public Location placeA { get; set;}
    public Location placeB { get; set;}
    public int weight { get; set;}
}

class Location
{
    public string name { get; set;}
    public bool visited { get; set;}
}