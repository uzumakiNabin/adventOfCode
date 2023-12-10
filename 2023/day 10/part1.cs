static int getSum(string[] list)
{
    int result = 0;
    int x = 0, y = 0;
    string topAllowed = "|7F", rightAllowed = "-J7", bottomAllowed = "|LJ", leftAllowed = "-LF";
    char dir = 'x', next = 'x';
    for (int i = 0; i < list.Length; i++)
    {
        if (list[i].Contains('S'))
        {
            y = i;
            x = list[i].IndexOf('S');
            break;
        }
    }

    //moving first time
    if (topAllowed.Contains(list[y - 1][x]))
    {
        next = list[--y][x];
        dir = 'T';
    }
    else if (rightAllowed.Contains(list[y][x + 1]))
    {
        next = list[y][++x];
        dir = 'R';
    }
    else if (bottomAllowed.Contains(list[y + 1][x]))
    {
        next = list[++y][x];
        dir = 'B';
    }
    else if (leftAllowed.Contains(list[y][x - 1]))
    {
        next = list[y][--x];
        dir = 'L';
    }

    while (next != 'S')
    {
        switch (next)
        {
            case '|':
                next = dir == 'B' ? list[++y][x] : list[--y][x];
                break;
            case '-':
                next = dir == 'R' ? list[y][++x] : list[y][--x];
                break;
            case 'L':
                next = dir == 'B' ? list[y][++x] : list[--y][x];
                dir = dir == 'B' ? 'R' : 'T';
                break;
            case 'J':
                next = dir == 'B' ? list[y][--x] : list[--y][x];
                dir = dir == 'B' ? 'L' : 'T';
                break;
            case '7':
                next = dir == 'T' ? list[y][--x] : list[++y][x];
                dir = dir == 'T' ? 'L' : 'B';
                break;
            case 'F':
                next = dir == 'T' ? list[y][++x] : list[++y][x];
                dir = dir == 'T' ? 'R' : 'B';
                break;
            default:
                break;
        }
        result++;
    }
    return result % 2 == 0 ? result / 2 : result / 2 + 1;
}