namespace Aufgabe2;

public class BubbleSortService : ISortService
{
    public void Sort(int[] B)
    {
        BubbleSort(B);
    }

    private void BubbleSort(int[] B)
    {
        for (int i = 0; i < B.Length; i++)
        {
            for (int j = B.Length - 1; j > i; j--)
            {
                if (B[j] < B[j - 1])
                {
                    int temp = B[j];
                    B[j] = B[j - 1];
                    B[j - 1] = temp;
                }
            }
        }
    }
}
