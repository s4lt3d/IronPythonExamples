# IronPython Integration with C#

This repository demonstrates how to integrate Python scripts with C# using IronPython. Two primary examples are provided to illustrate different functionalities:

## Installation

To get IronPython running in C# the IronPython package should be installed through NuGet.

`Install-Package IronPython -Version 2.7.10`

## Getting a List from Python into C#

This example demonstrates how to:

- Execute a Python script in C# that generates a list of squared numbers.
- Access and retrieve variables from the executed script in C#.
- Convert the Python list to a C# list and print its values.

To run, execute the code within the file `getting_a_list.cs`.

### Code Highlights:
- A Python script is created as a string, and it defines a list `x_squared` using Python's list comprehension.
- The list `x_squared` is then retrieved in C# and printed.
- The Python list is converted to a C# list using a custom wrapper and then printed.

## Basic IronPython Example

This example demonstrates how to:

- Execute a Python script in C#.
- Access and retrieve variables from the executed script in C#.
- Use custom C# functions within the Python script.

To run, execute the code within the file `calling_cs_function_example.cs`.

### Code Highlights:
- A Python script is defined as a string.
- The script utilizes two C# functions, `log` and `custom_add`. 
  - The `log` function is an alternative to Python's `print` function since `print` cannot be called directly. It prints provided arguments to the console.
  - The `custom_add` function is a demonstration of how C# functions can be seamlessly used within the Python script.
- Variables (`x` and `y`) are created within the Python script, and their values are accessed and printed in C#.

---

**Dependencies**:
- IronPython: Install via NuGet in your project. These examples used 2.7.10
`Install-Package IronPython -Version 2.7.10`
---



