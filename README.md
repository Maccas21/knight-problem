# Knight's shortest path / Knight's Travails

Given a standard 8x8 chessboard, design an application that accepts two squares identified by algebraic chess notation. The first square is the starting position, and the second
square is the ending position. Find the shortest sequence of valid moves
to take a Knight piece from the starting position to the ending position. Each move must be a legal move by a Knight. For any two squares there may be more than one valid solution.

### Input

Must be two squares identified in algebraic chess notation representing the starting and ending positions of the Knight.

### Output

Must be a list of squares through which the Knight passes, in algebraic chess notation. This must include the ending position, but exclude the starting position.

## Usage

Use **dotnet run** within terminal in VS Code

Alternatively press **F5** or click **Run -> Start Debugging**

Otherwise run file with prefered method

Once prompted enter two chess coordinates seperated with a space

E.g "A8 B7"

## Example Usage

```
$ dotnet run
Enter start position and end position seperated with a space
A8 B7
Possible path from A8 to B7:
B6 D7 C5 B7
```