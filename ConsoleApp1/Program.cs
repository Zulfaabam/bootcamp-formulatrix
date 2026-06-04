// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

void PrintFishBash(int n)
{
    // string output = "";

    for (int i = 0; i <= n; i++)
    {
        // string res = "";
        if (n % 3 == 0) Console.WriteLine("Fish");
        if (n % 5 == 0) Console.WriteLine("Bash");
    }
}