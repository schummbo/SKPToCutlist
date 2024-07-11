Utility project that attempts to read a Sketchup save file that contains dimensional lumber and generates a cutlist for that project.

This utility should read a Sketchup file containing any number of lengths of the following nominal dimensions of lumber:

- 1 x 2
- 1 x 6
- 2 x 2
- 2 x 4
- 2 x 6
- 4 x 4

It also attempts to make it relatively easy to add new nominal dimensions. It will generate a cutlist of said dimensions.  
If the SKP contains a piece that isn't a standard, nominal dimension, it will be printed simply as "irregular".

Future goals:
- Print dimensions of irregular pieces
- Calculate a bill of materials based on available lengths of lumber
