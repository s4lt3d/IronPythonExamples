// Getting a List From Python Into C#, IronPython Example
// Walter Gordy 2020

using System;
using System.Collections.Generic;
using IronPython.Hosting;
using IronPython.Runtime;

public class Program
{
    static void Main(string[] args)
    {
        // python is picking about white space. No whitespace here. 
        string python_script = @"
x_range = range(10)
x_squared = [i**2 for i in x_range]
print(x_squared)
        ";

        var engine = Python.CreateEngine();
        var scope = engine.CreateScope();
        scope.SetVariable("app", new Program());
        var ops = engine.Operations;

        Console.WriteLine("Executing script");
        engine.Execute(python_script, scope);
        Console.WriteLine("Getting variable from script");

        // Grab the variable from the executed script
        var python_x_squared = scope.GetVariable("x_squared");
        // python_x_squared is interable.
        Console.WriteLine("{0}", String.Join(" ", python_x_squared));
        
        // Here we convert it to a list and output the contents of the list
        ListGenericWrapper<int> x_squared = new ListGenericWrapper<int>(python_x_squared);
        Console.WriteLine("{0}", String.Join(" ", x_squared));


        Console.ReadKey();
    }
}
