
using System.Text.RegularExpressions;

string input;
long sum = 0;
Regex regex = new Regex(@"\d");

if (args.Length > 0)
{
    input = args[0];
}
else
{
    Console.WriteLine("Skriv in en text med tal och tecken");
    input = Console.ReadLine();
}

bool IsNumber(char character)
{
    return regex.IsMatch(char.ToString(character));
}

for (int i = 0; i < input.Length; i++)
{
    if (IsNumber(input[i]))
    {
        for (int j = i + 1; j < input.Length; j++)
        {
            if (input[i] == input[j])
            {
                string substring = input.Substring(i, j - i + 1);
                sum += long.Parse(substring);

                Console.WriteLine();
                Console.Write(input[..i]);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(substring);
                Console.ResetColor();
                Console.WriteLine(input[(j + 1)..]);

                break;
            }
            else if (!IsNumber(input[j]))
            {
                break;
            }
        }
    }
}
Console.WriteLine($"\nTotal: {sum}");