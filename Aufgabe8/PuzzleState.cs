namespace Aufgabe8;

public class PuzzleState
{
    public int[][] Puzzle { get; set; }
    public (int row, int col) Hole { get; set; }

    public PuzzleState()
    {
        Puzzle = new int[][]
        {
            new int[] { 5, 3, 1 },
            new int[] { 4, 7, 2 },
            new int[] { 0, 8, 6 }
        };
       
        Hole = (2, 0);
    }

    public static PuzzleState GenerateGoalState()
    {
        return new PuzzleState
        {
            Puzzle = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 0 }
            },
            Hole = (2, 2)
        };
    }

    public List<PuzzleState> GetSuccessors()
    {
        var successors = new List<PuzzleState>();

        // Up
        if (Hole.row != 0)
        {
            var puzzle = CopyPuzzle();
            puzzle[Hole.row][Hole.col] = puzzle[Hole.row - 1][Hole.col];
            puzzle[Hole.row - 1][Hole.col] = 0;

            successors.Add(new PuzzleState { Puzzle = puzzle, Hole = (Hole.row - 1, Hole.col) });
        }

        // Right
        if (Hole.col != 2)
        {
            var puzzle = CopyPuzzle();
            puzzle[Hole.row][Hole.col] = puzzle[Hole.row][Hole.col + 1];
            puzzle[Hole.row][Hole.col + 1] = 0;

            successors.Add(new PuzzleState { Puzzle = puzzle, Hole = (Hole.row, Hole.col + 1) });
        }

        // Down
        if (Hole.row != 2)
        {
            var puzzle = CopyPuzzle();
            puzzle[Hole.row][Hole.col] = puzzle[Hole.row + 1][Hole.col];
            puzzle[Hole.row + 1][Hole.col] = 0;

            successors.Add(new PuzzleState { Puzzle = puzzle, Hole = (Hole.row + 1, Hole.col) });
        }

        // Left
        if (Hole.col != 0)
        {
            var puzzle = CopyPuzzle();
            puzzle[Hole.row][Hole.col] = puzzle[Hole.row][Hole.col - 1];
            puzzle[Hole.row][Hole.col - 1] = 0;

            successors.Add(new PuzzleState { Puzzle = puzzle, Hole = (Hole.row, Hole.col - 1) });
        }

        return successors;
    }

    private int[][] CopyPuzzle()
    {
        return Puzzle.Select(row => row.ToArray()).ToArray();
    }
}
