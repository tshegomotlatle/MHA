


using MHA.Interfaces;

namespace MHA.Implementations;

public class CeresSearch : IBaseImplementation
{
    private readonly List<List<char>> _text;

    public CeresSearch(List<List<char>> text)
    {
        _text = text;
    }

    public int Calculate()
    {
        int countXmas = 0;
        for (int k = 0; k < _text.Count; k++)
        {
            for (int i = 0; i < _text[k].Count; i++)
            {
                int count = CheckAdjacentLetters(k, i);
                countXmas += count;
            }
        }

        return countXmas;
    }

    private int CheckAdjacentLetters(int k, int i)
    {
        int counter = 0;

        if (CheckHorizontal(k,i))
        {
            counter++;
        }
        if (CheckVeritical(k,i))
        {
            counter++;
        }
        if (CheckDiagonalRight(k,i))
        {
            counter++;
        }
        if (CheckDiagonalLeft(k,i))
        {
            counter++;
        }

        return counter;
    }

    private bool CheckDiagonalRight(int k, int i)
    {
        if ((k + 4 > _text.Count) || (i + 4 > _text[k].Count))
        {
            return false;
        }
        else
        {
            string word = string.Empty;
            int r = k;
            int m = i;
            for (; (r < k + 4) && (m < i + 4); r++, m++)
            {
                word += _text[r][m];
            }

            if (word.Equals("xmas", StringComparison.CurrentCultureIgnoreCase) || word.Equals("samx", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckDiagonalLeft(int k, int i)
    {
        if ((k + 4 > _text.Count) || (i - 3 < 0))
        {
            return false;
        }
        else
        {
            string word = string.Empty;
            int r = k;
            int m = i;
            for (; (r < k + 4) && (m >= i - 3); r++, m--)
            {
                word += _text[r][m];
            }

            if (word.Equals("xmas", StringComparison.CurrentCultureIgnoreCase) || word.Equals("samx", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckVeritical(int k, int i)
    {
        if (k + 4 > _text.Count)
        {
            return false;
        }
        else
        {
            string word = string.Empty;
            for (int r = k; r < k + 4; r++)
            {
                word += _text[r][i];
            }

            if (word.Equals("xmas", StringComparison.CurrentCultureIgnoreCase) || word.Equals("samx", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckHorizontal(int k, int i)
    {
        if (i + 4 > _text[k].Count)
        {
            return false;
        }
        else
        {
            string word = string.Empty;
            for (int r = i; r < i + 4; r++)
            {
                word += _text[k][r];
            }

            if (word.Equals("xmas", StringComparison.CurrentCultureIgnoreCase) || word.Equals("samx", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}