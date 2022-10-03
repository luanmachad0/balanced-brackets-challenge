using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'isBalanced' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string isBalanced(string s)
    {
        var cc = ")}]";
        char[] chars = s.ToCharArray();
        Stack st = new Stack();
        char[] closingChars = cc.ToCharArray();
        var validation = "is valid";
    
        if (closingChars.Contains(chars[0]))
            return "is not valid";
        
        for (var i = 0; i < chars.Length; i++)
        {
          // Console.WriteLine("--------------------------");
          // Console.WriteLine(st.ToString());
          if (closingChars.Contains(chars[i]))
          {
              // Console.WriteLine((int)chars[i]);
              // Console.WriteLine(((int)st.Peek()));
              // Console.WriteLine(((int)st.Peek()) + 1);
              if (st.Count > 0)
              {
                  if (((int)chars[i] == ((int)st.Peek()) + 1)
                      || ((int)chars[i] == ((int)st.Peek())  + 2))
                  {
                      st.Pop(); // Primeiro caso: st.Peek() == "(" e chars[i] == ")"
                  } 
                  else
                  {
                      validation = "is not valid";
                      return validation;
                  }
              }
          } 
          else 
          {
              st.Push((int)chars[i]);
          }
        }

        if (st.Count > 0)
            validation = "is not valid";

        return validation;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            string result = Result.isBalanced(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
