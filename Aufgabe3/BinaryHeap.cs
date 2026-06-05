namespace Aufgabe3;

public class BinaryHeap
{
    private int[] _heap;
    private int _size;

    public BinaryHeap(int maxSize)
    {
        _heap = new int[maxSize + 1];
        _size = 0;
    }

    public void Print()
    {
        for (int i = 1; i <= _size; i++)
        {
            Console.Write(_heap[i] + " ");
        }

        Console.WriteLine();
    }

    public void Insert(int value)
    {
        _size++;
        _heap[_size] = value;

        for (int i = _size; i > 0; i = i / 2)
        {
            if (_heap[i / 2] > _heap[i])
            {
                int temp = _heap[i / 2];
                _heap[i / 2] = _heap[i];
                _heap[i] = temp;
            }
            else
            {
                break;

            }
        }
    }

    public int ExtractMin()
    {
        int min = _heap[1];
        
        _heap[1] = _heap[_size];       
        _size--;

        int i = 1;
        while (i * 2 <= _size)
        {
            int smallest;

            if (i * 2 + 1 <= _size && _heap[i * 2 + 1] < _heap[i * 2])
            {
                smallest = i * 2 + 1;
            }
            else
            {
                smallest = i * 2;
            }

            if (_heap[i] > _heap[smallest])
            {
                int temp = _heap[i];
                _heap[i] = _heap[smallest];
                _heap[smallest] = temp;
                i = smallest;
            }
            else
            {
                break;
            }
        }       

        return min;
    }
}
