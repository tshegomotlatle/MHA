
using System.Collections.Generic;
using MHA.Interfaces;
using MHA.Models.Enums;

namespace MHA.Implementations;

public class GuardGallivant : IBaseImplementation
{
    private readonly List<List<char>> _map;
    (int X, int Y) _postion;
    Directions _direction;

    public GuardGallivant(List<List<char>> map)
    {
        _map = map;
        _postion = FindArrow();

        if (_postion == (-1,-1))
        {
            throw new ArgumentException("No Starting point specified, please specifiy with ^ on the map.");
        }

        _direction = FindDirection() ?? throw new ArgumentException("Direction of the starting position could not be determined");
    }

    private Directions? FindDirection()
    {
        return _map[_postion.X][_postion.Y] switch
        {
            '^' => (Directions?)Directions.Up,
            '>' => (Directions?)Directions.Right,
            '<' => (Directions?)Directions.Left,
            'v' => (Directions?)Directions.Down,
            _ => null,
        };
    }

    private (int X, int Y) FindArrow()
    {
        for (int i = 0; i < _map.Count; i++)
        {
            for (int j = 0; j < _map[i].Count; j++)
            {
                if (_map[i][j] == '^' ||
                    _map[i][j] == '>' || 
                    _map[i][j] == '<' || 
                    _map[i][j].ToString().Equals("v", StringComparison.CurrentCultureIgnoreCase))
                {
                    return (i, j);
                }
            }
        }

        return (-1, -1);
    }

    public int Calculate()
    {
        while (true)
        {

            if (((_postion.X + 1 == _map.Count && _direction == Directions.Down) || 
                (_postion.X - 1 == -1 && _direction == Directions.Up) || 
                (_postion.Y - 1 == -1 && _direction == Directions.Left) || 
                (_postion.Y + 1 == _map[_postion.X].Count)) || 
                (_postion.X == _map.Count && _postion.X == 0))
            {
                _map[_postion.X][_postion.Y] = 'X';
                break;
            }

            switch (_direction)
            {
                case Directions.Up:
                    if (_map[_postion.X - 1][_postion.Y] != '#')
                    {
                        _map[_postion.X][_postion.Y] = 'X';
                        _postion.X--;
                    }
                    else
                    {
                        _direction = Directions.Right;
                    }
                    break;
                case Directions.Down:
                    if (_map[_postion.X + 1][_postion.Y] != '#')
                    {
                        _map[_postion.X][_postion.Y] = 'X';
                        _postion.X++;
                    }
                    else
                    {
                        _direction = Directions.Left;
                    }
                    break;
                case Directions.Left:
                    if (_map[_postion.X][_postion.Y - 1] != '#')
                    {
                        _map[_postion.X][_postion.Y] = 'X';
                        _postion.Y--;
                    }
                    else
                    {
                        _direction = Directions.Up;
                    }
                    break;
                case Directions.Right:
                    if (_map[_postion.X][_postion.Y + 1] != '#')
                    {
                        _map[_postion.X][_postion.Y] = 'X';
                        _postion.Y++;
                    }
                    else
                    {
                        _direction = Directions.Down;
                    }
                    break;

            }
        }

        int distinctPostions = CountDistinctPostions();
        return distinctPostions;
    }

    private int CountDistinctPostions()
    {
        int distinctPostions = 0;

        for (int i = 0; i < _map.Count; i++)
        {
            for (int j = 0;j < _map[i].Count; j++)
            {
                if (_map[i][j] == 'X')
                {
                    distinctPostions++;
                }
                Console.Write(_map[i][j]);
            }
            Console.WriteLine();
        }

        return distinctPostions;
    }
}
