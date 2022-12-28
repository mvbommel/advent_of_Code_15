// See https://aka.ms/new-console-template for more information
char[] file = File.ReadAllText(@"..\..\..\..\..\..\txt\day1.txt").ToCharArray();

int position = 1;
int floor = 0;
foreach(char c in file)
{
    if(c== '(')
    {
        floor++;
    }
    else if( c ==')')
    {
        floor--;
    }
    if(floor <= -1)
    {

        break;
    }
    position++;
}
Console.WriteLine(position);
