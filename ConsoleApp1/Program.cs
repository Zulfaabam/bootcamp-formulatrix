// Task: Print FooBar

PrintFooBar(15);

string PrintFooBar(int n)
{
    List<string> output = new List<string> {};

    for (int i = 1; i <= n; i++)
    {
        string res = "";

        if (i % 3 == 0) res += "foo";

        if (i % 5 == 0) res += "bar";

        if (i % 3 != 0 && i % 5 != 0) res += i.ToString();

        output.Add(res);
        res = "";
    }

    string outputStr = string.Join(", ", output);
    Console.WriteLine(outputStr);

    return outputStr;
}