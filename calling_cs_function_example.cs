// Very basic IronPython Example
// Walter Gordy 2020

using System;
using IronPython.Hosting;

public class Program
{
    static void Main(string[] args)
    {
        // python is picking about white space. No whitespace here. 
        string python_script = @"
app.log('Hello World')
x = 5
y = 8
z = app.custom_add(16, 19)
print(x + y) # this prints to the console
app.log(str(x + y)) # this prints through a function
        ";

        var engine = Python.CreateEngine();
        var scope = engine.CreateScope();
        scope.SetVariable("app", new Program());
        var ops = engine.Operations;

        Console.WriteLine("Executing script");
        engine.Execute(python_script, scope);
        Console.WriteLine("Getting variable from script");

        var python_x = scope.GetVariable("x");
        Console.WriteLine("x from script: " + python_x.ToString());
        Console.ReadKey();
    }

    // Our custom c# function which gets called from python. 
    static public object custom_add(params object[] objects) {
        if (objects[0].GetType() == typeof(int))
        {
            return (int)objects[0] + (int)objects[1];
        }
        else
        {
            return (float)objects[0] + (float)objects[1];
        }
    }

    // We cannot call a function named print so we name it log instead. 
    static public void log(params object[] objects)
    {
        foreach(object obj in objects)
            Console.WriteLine((string)obj);
    }
}
