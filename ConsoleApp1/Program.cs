// Logic Exercise

IntToStringWithRules intToStringWithRules = new IntToStringWithRules();

intToStringWithRules.Print(15);

intToStringWithRules.AddRule(13, "qux");

intToStringWithRules.Print(26);

intToStringWithRules.Print(21);

intToStringWithRules.Print(35);

intToStringWithRules.AddRule(17, "saya akan lawan!");

intToStringWithRules.ChangeRule(5, "heehee");

intToStringWithRules.Print(105);

intToStringWithRules.RemoveRule(9);

intToStringWithRules.Print(63);

class IntToStringWithRules
{
  public Dictionary<int, string> rules = new()
  {
    {3, "foo"},
    {4, "baz"},
    {5, "bar"},
    {7, "jazz"},
    {9, "huzz"},
  };

  public IntToStringWithRules() {}

  public void AddRule(int divisor, string output)
  {
    if (!rules.ContainsKey(divisor))
    {
      rules[divisor] = output;
    } else {
      Console.WriteLine($"Rule for divisor {divisor} already exists. Use ChangeRule to modify it.");
      Console.WriteLine();
    }
  }

  public void RemoveRule(int divisor)
  {
    if (!rules.ContainsKey(divisor))
    {
      Console.WriteLine($"Rule for divisor {divisor} does not exist.");
      Console.WriteLine();
      return;
    }
    
    rules.Remove(divisor);
  }

  public void ChangeRule(int divisor, string output)
  {
    if (rules.ContainsKey(divisor))
    {
      rules[divisor] = output;
    } else {
      Console.WriteLine($"Rule for divisor {divisor} does not exist. Use AddRule to add it.");
      Console.WriteLine();
    }
  }

  public string Print(int n)
  {
      List<string> output = new();

      for (int i = 1; i <= n; i++)
      {
          string res = "";

          foreach( KeyValuePair<int, string> rule in rules )
          {
            if( i % rule.Key == 0 )
            {
              res += rule.Value;
            }
          }

          if (string.IsNullOrEmpty(res)) res += i.ToString();

          output.Add(res);
      }

      string outputStr = string.Join(", ", output);

      Console.WriteLine($"======= Print {n} =======");
      Console.WriteLine(outputStr);
      Console.WriteLine($"======= Print {n} =======");
      Console.WriteLine();

      return outputStr;
  }
}


