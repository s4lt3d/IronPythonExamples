using System;
using IronPython.Hosting;

public class Program
{
    static void Main(string[] args)
    {
        string python_script = @"
x = 5
y = 8
print(x + y)
z = app.custom_add(16, 19)
app.log('hello')

        ";

        var engine = Python.CreateEngine();
        var scope = engine.CreateScope();
        scope.SetVariable("app", new Program());
        var ops = engine.Operations;

        engine.Execute(python_script, scope);
        var python_x = scope.GetVariable("x");

        Console.ReadKey();
    }

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

    static public void log(params object[] objects)
    {
        foreach(object obj in objects)
            Console.WriteLine((string)obj);
    }
}
