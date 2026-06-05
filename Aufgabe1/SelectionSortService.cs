namespace Aufgabe2;

public class SelectionSortService : ISortService
{
    public void Sort(int[] D)
    {
        SelectionSort(D);
    }

    private void SelectionSort(int[] D)
    {
        for (int j = 0; j < D.Length - 1; j++)
        {
            int minPos = j;

            for (int i = j + 1; i < D.Length; i++)
            {
                if (D[i] < D[minPos])
                {
                    minPos = i;
                }
            }

            if (minPos > j)
            {
                int temp = D[minPos];
                D[minPos] = D[j];
                D[j] = temp;
            }
        }
    }
}
