namespace Aufgabe2;

public class QuicksortService : ISortService
{
    public void Sort(int[] A)
    {
        Quicksort(A, 0, A.Length - 1);
    }

    private void Quicksort(int[] A, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(A, left, right);
            Quicksort(A, left, pivotIndex - 1);
            Quicksort(A, pivotIndex + 1, right);
        }
    }

    private int Partition(int[] A, int left, int right)
    {
        int pivotValue = A[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (A[j] <= pivotValue)
            {
                i = i + 1;
                int temp1 = A[i];
                A[i] = A[j];
                A[j] = temp1;
            }
        }

        int temp2 = A[i + 1];
        A[i + 1] = A[right];
        A[right] = temp2;

        return i + 1;

    }
}
