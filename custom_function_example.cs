using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
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
print(z)
        ";

        var engine = Python.CreateEngine();
        var scope = engine.CreateScope();
        scope.SetVariable("app", new Program());
        //var source = engine.CreateScriptSourceFromString("custom_add()", Microsoft.Scripting.SourceCodeKind.Statements);
        //source.Execute(scope);
        var ops = engine.Operations;
            

        engine.Execute(python_script, scope);
        var python_x = scope.GetVariable("x");

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
}
