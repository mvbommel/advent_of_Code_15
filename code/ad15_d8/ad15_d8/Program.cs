// See https://aka.ms/new-console-template for more information
string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day8.txt");

int totalLength = 0;
foreach(string line in file)
{
    int totalLineLength = line.Length;
    int totalStringLength = totalLineLength -2;
    string temp = line;
    int dashLocation = temp.IndexOf('\\');
    while (dashLocation > 0)
    {
        if (temp[dashLocation + 1] == 'x')
        {
            totalStringLength -= 3;
            temp = temp.Remove(dashLocation, 4);
        }
        else
        {
            totalStringLength -= 1;
            temp = temp.Remove(dashLocation, 2);
        }
        dashLocation = temp.IndexOf("\\");
    }
    Console.WriteLine(temp);
    totalLength += (totalLineLength - totalStringLength);
}
Console.WriteLine(totalLength);