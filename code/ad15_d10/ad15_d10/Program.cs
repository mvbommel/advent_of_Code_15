// See https://aka.ms/new-console-template for more information
using System.Collections.Specialized;
using System.Text;

string breakdown(char[] input)
{
    StringBuilder temp = new StringBuilder();
    List<NumberCount> numCount = new List<NumberCount>();
    int count = 1;
    for (int i = 0; i < input.Length; i++)
    {
        if (i > 0 && i < input.Length - 1)
        {
            if (input[i] - '0' == input[i - 1] - '0')
            {
                count++;
            }
            else
            {
                int value = input[i - 1] - '0';
                temp.Append(Convert.ToString(count) + value);
                count = 1;
            }
        }
        else if (i == input.Length - 1)
        {
            if (input[i] - '0' == input[i - 1] - '0')
            {
                count++;
                int value = input[i - 1] - '0';
                temp.Append(Convert.ToString(count) + value);
            }
            else
            {
                int value = input[i - 1] - '0';
                temp.Append(Convert.ToString(count) + value);
                count = 1;
                value = input[i] - '0';
                temp.Append(Convert.ToString(count) + value);
            }
        }
    }
    Console.WriteLine(temp.Length);
    return temp.ToString();

}

char[] input = "3113322113".ToCharArray();

for (int i = 0; i <50 ; i++)
{
    input= breakdown(input).ToCharArray();
}

class NumberCount
{
    public int number { get; set;}
    public int count { get; set;}
}

