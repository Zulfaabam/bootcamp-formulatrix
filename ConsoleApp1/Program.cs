// Logic Exercise

PrintFooBar(15);
PrintFooBar(21);
PrintFooBar(35);
PrintFooBar(105);
PrintFooBar(63);

string PrintFooBar(int n)
{
    List<string> output = new List<string> {};

    Dictionary<int, string> divisions = new()
    {
      {3, "foo"},
      {4, "baz"},
      {5, "bar"},
      {7, "jazz"},
      {9, "huzz"},
    };

    for (int i = 1; i <= n; i++)
    {
        string res = "";

        foreach( KeyValuePair<int, string> div in divisions )
        {
          if( i % div.Key == 0 )
          {
            res += div.Value;
          }
        }

        if (string.IsNullOrEmpty(res)) res += i.ToString();

        output.Add(res);
    }

    string outputStr = string.Join(", ", output);

    Console.WriteLine($"======= {n} =======");
    Console.WriteLine(outputStr);
    Console.WriteLine($"======= {n} =======");
    Console.WriteLine();

    return outputStr;
}
