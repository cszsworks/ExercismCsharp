public class CircularBuffer<T>
{
    private T[] buffer;
    int capacity;

    int count;
    int head; // points to the oldest element
    int tail; // points to the next position to write

    #region helper
    private void stepForward()
    {

    }

    #endregion helper
    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        this.buffer = new T[capacity];
        this.tail = 0;
        this.head = 0;
        this.count = 0;
    }

    public T Read()
    {
            if(count == 0) throw new InvalidOperationException();
            Console.WriteLine($"returning: {buffer[head]}");
            T stuff = buffer[head];
            this.head = (this.head + 1) % capacity;
            this.count--;
            return stuff;

    }

    public void Write(T value)
    {
        if (count == capacity) throw new InvalidOperationException();
        buffer[tail] = value;
        this.tail = (this.tail+1) % capacity;
        this.count++;
    }

    public void Overwrite(T value)
    {
        if (capacity != count)
        {
            buffer[tail] = value;
            this.tail = (this.tail + 1) % capacity;
            this.count++;
            return;
        }
        buffer[head] = value;
        this.head = (this.head + 1) % capacity;
    }

    public void Clear()
    {
        if (this.count != 0)
        {
            this.head = (this.head + 1) % capacity;
            this.count--;
        }
    }
}