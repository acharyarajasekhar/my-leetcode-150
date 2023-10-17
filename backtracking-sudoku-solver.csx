private bool IsValid(char[,] board, int row, int col, char c)
{
    for (int i = 0; i < 9; i++)
    {
        if (board[i, col] == c) return false;
        if (board[row, i] == c) return false;
        if (board[(3 * (row / 3)) + i / 3, (3 * (col / 3) + i % 3)] == c) return false;
    }

    return true;
}

private bool Solve(char[,] board)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (board[i, j] == '.')
            {
                for (char k = '1'; k <= '9'; k++)
                {
                    if (IsValid(board, i, j, k))
                    {
                        board[i, j] = k;
                        if (Solve(board))
                            return true;
                        else
                            board[i, j] = '.';
                    }
                }
                return false;
            }
        }
    }
    return true;
}

private void Print(char[,] board)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write("" + board[i, j] + " ");
        }
        Console.WriteLine();
    }
}

var n = 9;
char[,] board = { { '.', '.', '6', '.', '.', '4', '.', '.', '.' }, { '.', '3', '.', '.', '1', '.', '.', '9', '5' }, { '.', '.', '.', '.', '.', '.', '8', '.', '.' }, { '.', '.', '.', '.', '8', '.', '3', '.', '.' }, { '4', '.', '.', '.', '.', '1', '.', '8', '2' }, { '.', '2', '.', '.', '.', '.', '7', '.', '.' }, { '.', '.', '.', '.', '.', '.', '.', '.', '7' }, { '.', '5', '.', '.', '9', '.', '.', '2', '1' }, { '3', '.', '.', '5', '.', '.', '.', '.', '.' } };

Print(board);
Console.WriteLine("*********************");
Solve(board);
Print(board);