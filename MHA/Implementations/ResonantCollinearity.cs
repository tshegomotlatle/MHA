namespace MHA.Implementations;

using System;
using System.Collections.Generic;
using MHA.Interfaces;

public class ResonantCollinearity : IBaseImplementation
{
    private readonly List<List<char>> _map;
    private readonly int _rows;
    private readonly int _cols;
    private readonly HashSet<(int r, int c)> _antinodes;

    public ResonantCollinearity(List<List<char>> map)
    {
        _map = map;
        _rows = map.Count;
        _cols = map[0].Count;
        _antinodes = [];
    }

    public int Calculate()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                char ch = _map[i][j];
                if (IsAntenna(ch))
                {
                    CheckTopBottom(i, j);
                    CheckLeftRight(i, j);
                    CheckLeftDiagonal(i, j);
                    CheckRightDiagonal(i, j);
                }
            }
        }

        return _antinodes.Count;
    }

    private  bool IsAntenna(char c)
    {
        return char.IsLetterOrDigit(c);
    }

    private void CheckTopBottom(int i, int j)
    {
        char freq = _map[i][j];

        for (int k = i + 1; k < _rows; k++)
        {
            if (_map[k][j] == freq)
            {
                AddAntinode(2 * i - k, j); // above
                AddAntinode(2 * k - i, j); // below
            }
        }
    }

    private void CheckLeftRight(int i, int j)
    {
        char freq = _map[i][j];

        for (int k = j + 1; k < _cols; k++)
        {
            if (_map[i][k] == freq)
            {
                AddAntinode(i, 2 * j - k); // left
                AddAntinode(i, 2 * k - j); // right
            }
        }
    }

    private void CheckLeftDiagonal(int i, int j)
    {
        char freq = _map[i][j];

        int step = 1;
        while (i + step < _rows && j - step >= 0)
        {
            if (_map[i + step][j - step] == freq)
            {
                AddAntinode(2 * i - (i + step), 2 * j - (j - step)); // up-left
                AddAntinode(2 * (i + step) - i, 2 * (j - step) - j); // down-right
            }
            step++;
        }
    }

    private void CheckRightDiagonal(int i, int j)
    {
        char freq = _map[i][j];

        int step = 1;
        while (i + step < _rows && j + step < _cols)
        {
            if (_map[i + step][j + step] == freq)
            {
                AddAntinode(2 * i - (i + step), 2 * j - (j + step)); // up-right
                AddAntinode(2 * (i + step) - i, 2 * (j + step) - j); // down-left
            }
            step++;
        }
    }

    private void AddAntinode(int r, int c)
    {
        if (r >= 0 && r < _rows && c >= 0 && c < _cols)
        {
            _antinodes.Add((r, c));
        }
    }
}
