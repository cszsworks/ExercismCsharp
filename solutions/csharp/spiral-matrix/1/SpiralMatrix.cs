public class SpiralMatrix
{
    public enum Direction { right, down, left, up }

    public static Direction NextDirection(Direction d)
    {
        return (Direction)(((int)d + 1) % 4);
    }

    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        int currentElement = 1;
        int i = 0, j = 0;
        Direction dir = Direction.right;

        while (currentElement <= size * size)
        {
            matrix[i, j] = currentElement++;

            // calculate next indices
            int nextI = i, nextJ = j;
            switch (dir)
            {
                case Direction.right: nextJ++; break;
                case Direction.down: nextI++; break;
                case Direction.left: nextJ--; break;
                case Direction.up: nextI--; break;
            }

            // if next step is invalid, turn clockwise
            if (nextI < 0 || nextI >= size || nextJ < 0 || nextJ >= size || matrix[nextI, nextJ] != 0)
            {
                dir = NextDirection(dir);
                // recalc next step after turn
                switch (dir)
                {
                    case Direction.right: nextI = i; nextJ = j + 1; break;
                    case Direction.down: nextI = i + 1; nextJ = j; break;
                    case Direction.left: nextI = i; nextJ = j - 1; break;
                    case Direction.up: nextI = i - 1; nextJ = j; break;
                }
            }

            i = nextI;
            j = nextJ;
        }

        return matrix;
    }

    public static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
                Console.Write(matrix[x, y].ToString().PadLeft(3));
            Console.WriteLine();
        }
    }
}
