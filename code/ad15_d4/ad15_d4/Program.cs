// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

string input = "ckczppom";
bool found = false;
int i = 0;
while (!found)
{
    string temp = input + i;
    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(temp);
    byte[] hashBytes = MD5.Create().ComputeHash(inputBytes);
    string hex = Convert.ToHexString(hashBytes);
    char[] chars= hex.ToCharArray();
    bool leadingZeros = true;
    for(int j = 0; j <=5; j++)
    {
        char c = chars[j];
        if(c != '0')
        {
            leadingZeros= false;
        }
    }
    if(leadingZeros)
    {
        Console.WriteLine(hex);
        found= true;
        Console.WriteLine(i);
    }
    else
    {
        i++;
    }
}