// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day6.txt");
List<Light> lights = new List<Light>();
for(int x = 0; x < 1000; x++)
{
    for (int y = 0; y < 1000; y++)
    {
        lights.Add(new Light() { x =x, y = y, brightness = 0});
    }
}

foreach(string line in file)
{
    switch (line)
    {
        case string on when line.Contains("turn on"):
            string[] cordsOn = line.Split(new string[] { "turn on ", " through " }, StringSplitOptions.RemoveEmptyEntries);
            int startX = Int32.Parse(cordsOn[0].Split(",")[0]);
            int startY = Int32.Parse(cordsOn[0].Split(",")[1]);
            int endX = Int32.Parse(cordsOn[1].Split(",")[0]);
            int endY = Int32.Parse(cordsOn[1].Split(",")[1]);
            foreach(Light light in lights)
            {
                if( light.x >= startX && light.x <= endX && light.y >= startY && light.y <= endY)
                {
                    light.brightness++;
                }
            }
            break;
        case string off when line.Contains("turn off"):
            string[] cordsOff = line.Split(new string[] { "turn off ", " through " }, StringSplitOptions.RemoveEmptyEntries);
            startX = Int32.Parse(cordsOff[0].Split(",")[0]);
            startY = Int32.Parse(cordsOff[0].Split(",")[1]);
            endX = Int32.Parse(cordsOff[1].Split(",")[0]);
            endY = Int32.Parse(cordsOff[1].Split(",")[1]);
            foreach (Light light in lights)
            {
                if (light.x >= startX && light.x <= endX && light.y >= startY && light.y <= endY)
                {
                    if (light.brightness > 0)
                    {
                        light.brightness--;
                    }
                }
            }
            break;
        case string toggle when line.Contains("toggle"):
            string[] cords = line.Split(new string[] { "toggle ", " through " }, StringSplitOptions.RemoveEmptyEntries);
            startX = Int32.Parse(cords[0].Split(",")[0]);
            startY = Int32.Parse(cords[0].Split(",")[1]);
            endX = Int32.Parse(cords[1].Split(",")[0]);
            endY = Int32.Parse(cords[1].Split(",")[1]);
            foreach (Light light in lights)
            {
                if (light.x >= startX && light.x <= endX && light.y >= startY && light.y <= endY)
                {
                  light.brightness += 2;
                }
            }
            break;
    }
}
long totalBrightness = 0;
foreach (Light light in lights)
{
    totalBrightness+= light.brightness;
}
Console.WriteLine(totalBrightness);

public class Light
{
    public int x { get; set; }
    public int y { get; set; }
    public int brightness { get; set; }
}