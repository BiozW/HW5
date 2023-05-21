using System;

class program
{
    static void Main()
    {
        string currentPos = "A1";

        List<string> mainRollbacks = new List<string>();

        List<string> secondaryRollbacks = new List<string>();

        while (true)
        {
            int move = int.Parse(Console.ReadLine());

            switch (move)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    int spaces = int.Parse(Console.ReadLine());

                    string newPos = CalculateNewPosition(currentPos, move, spaces);

                    if (IsValidPosition(newPos))
                    {
                        mainRollbacks.Add(newPos);
                        secondaryRollbacks.Clear();
                        currentPos = newPos;
                    }
                    else
                    {
                    }
                    break;

                case 9:
                    if (mainRollbacks.Count > 0)
                    {
                        string lastMove = mainRollbacks[mainRollbacks.Count - 1];
                        mainRollbacks.RemoveAt(mainRollbacks.Count - 1);
                        secondaryRollbacks.Add(lastMove);
                        currentPos = lastMove;
                    }
                    else
                    {
                    }
                    break;

                case 10:
                    if (secondaryRollbacks.Count > 0)
                    {
                        string lastMove = secondaryRollbacks[secondaryRollbacks.Count - 1];
                        secondaryRollbacks.RemoveAt(secondaryRollbacks.Count - 1);
                        mainRollbacks.Add(lastMove);
                        currentPos = lastMove;
                    }
                    else
                    {
                    }
                    break;

                case 11:
                    Console.WriteLine(currentPos);
                    return;

                default:
                    break;
            }
        }
    }

    static string CalculateNewPosition(string currentPosition, int move, int spaces)
    {
        int currentRow = currentPosition[1] - '0';
        int currentCol = currentPosition[0] - 'A';

        int newRow = currentRow;
        int newCol = currentCol;

        switch (move)
        {
            case 1:
                newRow += spaces;
                break;
            case 2:
                newRow += spaces;
                newCol -= spaces;
                break;
            case 3:
                newCol -= spaces;
                break;
            case 4:
                newRow -= spaces;
                newCol -= spaces;
                break;
            case 5:
                newRow -= spaces;
                break;
            case 6:
                newRow -= spaces;
                newCol += spaces;
                break;
            case 7:
                newCol += spaces;
                break;
            case 8:
                newRow += spaces;
                newCol += spaces;
                break;
        }

        char newColChar = (char)('A' + newCol);
        string newPos = newColChar.ToString() + newRow.ToString();
        return newPos;
    }

    static bool IsValidPosition(string position)
    {
        int row = position[1] - '0';
        char col = position[0];

        return row >= 1 && row <= 8 && col >= 'A' && col <= 'H';
    }
}
