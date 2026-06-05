namespace Aufgabe2;

public class InsertionSortService : ISortService
{
    public void Sort(int[] C)
    {
        InsertionSort(C);
    }

    private void InsertionSort(int[] C)
    {
        for (int j = 1; j < C.Length; j++)
        {
            int key = C[j];
            int insertPos = j - 1;

            while (insertPos >= 0 && C[insertPos] > key)
            {
                C[insertPos + 1] = C[insertPos];
                insertPos = insertPos - 1;
            }

            C[insertPos + 1] = key;
        }
    }
}
