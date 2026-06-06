namespace Aufgabe7;

public class GameState
{
    private const int FARMER = 0;
    private const int WOLF = 1;
    private const int GOAT = 2;
    private const int CABBAGE = 3;

    private int _state = 0;

    public GameState() { }

    public GameState(int state) 
    { 
        _state = state;
    }

    public bool IsRight(int figure)
    {
        return (_state & (1 << figure)) != 0;
    }

    public bool IsValid()
    {
        if (IsRight(WOLF) && IsRight(GOAT) && !IsRight(FARMER))
        {
            return false;
        }

        if (IsRight(GOAT) && IsRight(CABBAGE) && !IsRight(FARMER))
        {
            return false;
        }

        if (!IsRight(WOLF) && !IsRight(GOAT) && IsRight(FARMER))
        {
            return false;
        }

        if (!IsRight(GOAT) && !IsRight(CABBAGE) && IsRight(FARMER))
        {
            return false;
        }

        return true;
    }

    public bool IsTerminationState()
    {
        return _state == 15; // 1111 == alle rechts
    }

    public List<GameState> GetNeighbours()
    {
        var neighbours = new List<GameState>();

        // Mögliche Züge: Farmer alleine, oder Farmer + eine Figur
        int[] figures = { FARMER, WOLF, GOAT, CABBAGE }; // -1 = alleine

        foreach (var figure in figures)
        {
            // 1. Prüfe ob Farmer die Figur mitnehmen kann
            //    (Figur muss auf derselben Seite wie Farmer sein)
            if (IsRight(figure) == IsRight(FARMER))
            {
                // 2. Erstelle neuen State – flippe Farmer-Bit (und ggf. Figur-Bit)
                var state = _state ^ (1 << FARMER);

                if (figure != FARMER)
                {
                    state = state ^ (1 << figure);
                }                

                var gs = new GameState(state);

                // 3. Prüfe ob neuer State IsValid()
                if (gs.IsValid())
                {
                    // 4. Falls ja → zur Liste hinzufügen
                    neighbours.Add(gs);
                }
            }                      
        }

        return neighbours;
    }

    public override string ToString()
    {
        return $"Farmer={(IsRight(FARMER) ? "R" : "L")} Wolf={(IsRight(WOLF) ? "R" : "L")} Ziege={(IsRight(GOAT) ? "R" : "L")} Kohl={(IsRight(CABBAGE) ? "R" : "L")}";
    }

    public override int GetHashCode()
    {
        return _state;
    }

    public override bool Equals(object? obj)
    {
        if (obj is GameState gs)
        {
            return _state == gs._state;
        }

        return false;
    }
}
