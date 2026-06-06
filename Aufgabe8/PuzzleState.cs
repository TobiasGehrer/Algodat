namespace Aufgabe8;

public class PuzzleState : Node
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

    public List<PuzzleState> GetPuzzleSuccessors()
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

    public int H1()
    {
        var wrongCount = 0;
        var reference = 1;

        for (int row = 0; row < Puzzle.Length; row++)
        {
            for (int col = 0; col < Puzzle[row].Length; col++)
            {
                if (Puzzle[row][col] != reference && Puzzle[row][col] != 0)
                {
                    wrongCount++;
                }

                reference++;
            }
        }

        return wrongCount;
    }
    
    public int H2()
    {
        var manhattenDistance = 0;

        for (int row = 0; row < Puzzle.Length; row++)
        {
            for (int col = 0; col < Puzzle[row].Length; col++)
            {
                int value = Puzzle[row][col];

                if (value != 0)
                {
                    var targetRow = (value - 1) / 3;
                    var targetCol = (value - 1) % 3;
                    manhattenDistance += Math.Abs(row - targetRow) + Math.Abs(col - targetCol);
                }                
            }
        }

        return manhattenDistance;
    }

    public int H3()
    {
        return Math.Max(H1(), H2());
    }

    private int[][] CopyPuzzle()
    {
        return Puzzle.Select(row => row.ToArray()).ToArray();
    }

    public override IEnumerable<Node> GetSuccessors()
    {
        return GetPuzzleSuccessors();
    }

    public override bool IsGoal()
    {
        return H1() == 0;
    }

    public override int Heuristic()
    {
        return H3();
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        foreach (var row in Puzzle)
        {
            sb.AppendLine(string.Join(" ", row.Select(x => x == 0 ? "_" : x.ToString())));
        }
        return sb.ToString();
    }

    public override int GetHashCode()
    {
        return string.Join(",", Puzzle.SelectMany(r => r)).GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is PuzzleState ps)
        {
            return GetHashCode() == ps.GetHashCode();
        }
        return false;
    }
}
