// See https://aka.ms/new-console-template for more information
string input = "hxbxwxba";

string updatePassword(string input)
{
    char last = input.Last();
    if (last != 'z')
    {
        if (last != 'h' && last != 'n' && last != 'k')
        {
            char next = (char)((int)last + 1);
            input = input.Remove(input.Length - 1, 1) + (next);
        }
        else
        {
            char next = (char)((int)last + 2);
            input = input.Remove(input.Length - 1, 1) + (next);
        }
    }
    else
    {
        input = input.Remove(input.Length - 1, 1);
        input = updatePassword(input);
        input += 'a';
    }
    return input;
}

bool straight = false;
bool NoForbidden = true;
bool acceptable = false;
int pairs = 0;
while(!acceptable)
{
    input = updatePassword(input);
    if(input.Contains("i") || input.Contains("o") || input.Contains("l")){
        NoForbidden= false;
    }
    for(int i = 2; i <input.Length; i++)
    {
        if (input[i] - input[i - 1] == 1 && input[i] - input[i-2] == 2) { 
            straight= true;
        }
    }
    for (int i =12; i < input.Length; i++)
    {
        if (input[i] == input[i-1])
        {
            pairs++;
        }
    }

    if (straight && NoForbidden && pairs >= 2)
    {
        acceptable= true;
    }
    Console.WriteLine(input);
}
Console.WriteLine(input);
