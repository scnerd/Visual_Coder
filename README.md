Visual_Coder
============

A way to write C# in a GUI-based, visual way

For starters, the code should compile and run fine if you've got .NET 4.0 and Visual Studio 2010 or newer.

Once the program has started, you'll notice a list of some namespaces in the upper left hand corner.
Note that this list is only what's used in my code thus far. Eventually, it will support importing new
namespaces, but for now, this is how it works.

Check one or more namespaces to see the classes available within them.

Select a class to see the functions available within it.
Note that the methods are not (yet) marked static or instance, nor are overloads noted as such. Just guess
for now, and better marking will be implemented later.

Select a function, then click on the canvas on the right half to insert that function.

Alternatively, a few types of constants and a VERY small number of operators are currently supported. Just
select the drop-down above the right list, and select "Constants" or "Operators".

Again, you can select a constant type or operator type and put it on the canvas.

=== EXAMPLE ===

For demonstration purposes, in Visual_Coder.Form1, there's a method called "SampleFunction1" that just takes
a string as a parameter. Put one of those on the canvas (Either by navigating the check boxes and lists, or
by typing "Visual_Coder.Form1" in the search box at the bottom). Then create a string constant and put it on
the canvas. Once you have both, select the OUTPUT button (the only button) on the constant, and the INPUT 
button (the only button) on the method to indicate that the return value of the string should go as an
argument into the method. A line will indicate as much. (Just click both buttons to link them)

Now hit "Preview Code" at the top to see what your output code would look like. Note that the namespace,
class, and codefile name are all currently defaults. Also note that everything you do will take place in the
Main method. All these will eventually be customizable.

Note that, even though all variables are of type "var", the resulting code is actually valid C# code.

You can now hit either "Save" to save this code to a *.cs file, or hit "Compile" to create "a.exe" in the same
directory as the code file. You now have a functional C# console program. Congratulations.

=== TODO ===

Everything.

This is a rough draft, just to demonstrate the idea of what I want to do. At the moment, the most immediate
thing left to do is to implement
1) the x.y operator, to allow use of instance methods.
2) control nodes, to allow use of "if/else" blocks, loops, or any other code that controls the flow of the
    program.
3) a new sorting algorithm (a modification of the currently used Topological Sort) that is capable of
    understanding and properly handling control blocks, which may skip or repeat code through the control node.

After that, there's all sorts of things to do.
  - Increase the canvas size to allow more code (implement the scroll bars)
  - Finish implementing standard operators
  - Finish implementing all control operators
  - Permit custom variable names, or at least expand beyond the 26 lower case characters
  - Allow moving of nodes for clarity's sake
  - Allow creation of custom methods
  - Allow creation of custom files/classes
  - Allow importing of new namespaces
  - Allow renaming/relocation of output executable
  - Be able to parse an input C# file and generate the node list that produces the same code
  - Support lambda functions?
  - Support automatic generation of nodes by typing in code by hand
