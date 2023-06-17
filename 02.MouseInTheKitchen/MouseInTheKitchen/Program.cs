int[] dimensions = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
int rows = dimensions[0];
int cols = dimensions[1];
char[,] matrix = new char[rows, cols];
int totalCheese = 0;
int eatenCheese = 0;
int mouseRow = 0;
int mouseCol = 0;
for (int row = 0; row < rows; row++)
{
    string rowData = Console.ReadLine();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = rowData[col];
        if (matrix[row, col] == 'M')
        {
            mouseRow = row;
            mouseCol = col;
        }

        if (matrix[row, col] == 'C')
        {
            totalCheese++;
        }
    }
}

string command;
while ((command = Console.ReadLine()) != "danger")
{
    switch (command)
    {
        case "up":
            mouseRow--;
            if (isInsideMatrix(mouseRow, mouseCol, matrix))
            {
                if (matrix[mouseRow, mouseCol] == 'C')
                {
                    eatenCheese++;
                    matrix[mouseRow + 1, mouseCol] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                }
                else if (matrix[mouseRow, mouseCol] == '*')
                {
                    matrix[mouseRow + 1, mouseCol] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                }

                else if (matrix[mouseRow, mouseCol] == 'T')
                {
                    matrix[mouseRow + 1, mouseCol] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    PrintMatrix(matrix);
                    return;
                }
                else if (matrix[mouseRow, mouseCol] == '@')
                {
                    mouseRow++;
                }
            }
            else
            {
                Console.WriteLine("No more cheese for tonight!");
                PrintMatrix(matrix);
                return;
            }
            break;

        case "down":
            mouseRow++;
            if (isInsideMatrix(mouseRow, mouseCol, matrix))
            {
                if (matrix[mouseRow, mouseCol] == 'C')
                {
                    eatenCheese++;
                    matrix[mouseRow - 1, mouseCol] = '*';
                    matrix[mouseRow, mouseCol] = 'M';

                }
                else if (matrix[mouseRow, mouseCol] == '*')
                {
                    matrix[mouseRow - 1, mouseCol] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                }

                else if (matrix[mouseRow, mouseCol] == 'T')
                {
                    matrix[mouseRow - 1, mouseCol] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    PrintMatrix(matrix);
                    return;
                }
                else if (matrix[mouseRow, mouseCol] == '@')
                {
                    mouseRow--;
                }
            }
            else
            {
                Console.WriteLine("No more cheese for tonight!");
                PrintMatrix(matrix);
                return;
            }
            break;

        case "left":
            mouseCol--;
            if (isInsideMatrix(mouseRow, mouseCol, matrix))
            {
                if (matrix[mouseRow, mouseCol] == 'C')
                {
                    eatenCheese++;
                    matrix[mouseRow, mouseCol + 1] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                }
                else if (matrix[mouseRow, mouseCol] == '*')
                {
                    matrix[mouseRow, mouseCol + 1] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                }
                else if (matrix[mouseRow, mouseCol] == 'T')
                {
                    matrix[mouseRow, mouseCol + 1] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    PrintMatrix(matrix);
                    return;
                }
                else if (matrix[mouseRow, mouseCol] == '@')
                {
                    mouseCol++;
                }
            }
            else
            {
                Console.WriteLine("No more cheese for tonight!");
                PrintMatrix(matrix);
                return;
            }
            break;
        case "right":
            mouseCol++;
            if (isInsideMatrix(mouseRow, mouseCol, matrix))
            {
                if (matrix[mouseRow, mouseCol] == 'C')
                {
                    eatenCheese++;
                    matrix[mouseRow, mouseCol - 1] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                }
                else if (matrix[mouseRow, mouseCol] == '*')
                {
                    matrix[mouseRow, mouseCol - 1] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                }

                else if (matrix[mouseRow, mouseCol] == 'T')
                {
                    matrix[mouseRow, mouseCol - 1] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    PrintMatrix(matrix);
                    return;
                }
                else if (matrix[mouseRow, mouseCol] == '*')
                {
                    matrix[mouseRow, mouseCol - 1] = '*';
                    matrix[mouseRow, mouseCol] = 'M';
                }
                else if (matrix[mouseRow, mouseCol] == '@')
                {
                    mouseCol--;
                }
            }
            else
            {
                Console.WriteLine("No more cheese for tonight!");
                PrintMatrix(matrix);
                return;

            }
            break;
    }

    if (eatenCheese == totalCheese)
    {
        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
        PrintMatrix(matrix);
        return;
    }

}

Console.WriteLine("Mouse will come back later!");
PrintMatrix(matrix);
bool isInsideMatrix(int row, int col, char[,] matrix)
{
    bool isValidMove = row >= 0 && row < matrix.GetLength(0)
                                && col >= 0 && col < matrix.GetLength(1);

    return isValidMove;
}
void PrintMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write($"{matrix[row, col]}");
        }

        Console.WriteLine();
    }
}