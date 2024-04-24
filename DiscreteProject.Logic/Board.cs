using System.Drawing;
using System.Globalization;

namespace DiscreteProject.Logic;

public class Board
{
    public static event Action ElementOfHHasBeenAdded;
    public int Size { get; set; }
    private Row[] rows;
    public Row[] Rows { get => rows; }
    public static event Action ElementOfHAdded;
    public Board(int size)
    {
        Size = size;
        rows = new Row[size];
        for (int i = 0; i < size; i++)
        {
            rows[i] = new Row(size);
        }
    }
    public void SetRowConfiguration(int rowNumber, string input)
    {
        if (input.Length != Size)
        {
            throw new Exception("Invalid row configuration");
        }
        for (int i = 0; i < Size; i++)
        {
            rows[rowNumber].SetText(input);
        }
    }
    public async Task SolveBoard()
    {
        bool changed;
        do
        {
            changed = false;

            // Check from top to bottom and bottom to top
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (await CheckAndUpdateCells(i, j, true))
                    {
                        changed = true;
                    }
                }
            }

            // Check from left to right and right to left
            for (int j = 0; j < Size; j++)
            {
                for (int i = 0; i < Size; i++)
                {
                    if (await CheckAndUpdateCells(i, j, false))
                    {
                        changed = true;
                    }
                }
            }

        } while (changed);

        if (IsBoardSolvable())
        {
            throw new Exception("Board is solvable");
        }
        else
        {
            throw new Exception("Board is not automatically solvable");
        }
    }

    private async Task<bool> CheckAndUpdateCells(int i, int j, bool checkRows)
    {
        if (checkRows)
        {
            if (i + 2 < Size && rows[i].Cells[j].Value == '0' && rows[i + 1].Cells[j].Value == '0' && rows[i + 2].Cells[j].Value != '0')
            {
                await AddElementOfH(rows[i].Cells[j], rows[i + 1].Cells[j], rows[i + 2].Cells[j]);
                return true;
            }
            else if (i > 1 && rows[i].Cells[j].Value != '0' && rows[i - 1].Cells[j].Value == '0' && rows[i - 2].Cells[j].Value == '0')
            {
                await AddElementOfH(rows[i].Cells[j], rows[i - 1].Cells[j], rows[i - 2].Cells[j]);
                return true;
            }
        }
        else
        {
            if (j + 2 < Size && rows[i].Cells[j].Value == '0' && rows[i].Cells[j + 1].Value == '0' && rows[i].Cells[j + 2].Value != '0')
            {
                await AddElementOfH(rows[i].Cells[j], rows[i].Cells[j + 1], rows[i].Cells[j + 2]);
                return true;
            }
            else if (j > 1 && rows[i].Cells[j].Value != '0' && rows[i].Cells[j - 1].Value == '0' && rows[i].Cells[j - 2].Value == '0')
            {
                await AddElementOfH(rows[i].Cells[j], rows[i].Cells[j - 1], rows[i].Cells[j - 2]);
                return true;
            }
        }
        return false;
    }



    private async Task AddElementOfH(Cell a, Cell b, Cell c)
    {
        a.InvertValue();
        b.InvertValue();
        c.InvertValue();
        ElementOfHAdded?.Invoke();
        await Task.Delay(100);

    }

    public bool IsBoardSolvable()
    {
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < rows[i].Cells.Count; j++)
            {
                if (i == rows.Length - 1 && j == rows[i].Cells.Count - 1 && rows[i].Cells[j].Value == '0')
                {
                    continue;
                }
                else if (rows[i].Cells[j].Value == '0')
                {
                    return false;
                }
            }
        }
        return true;

    }
    public void ModifyCell(Cell cell)
    {
        cell.InvertValue();
    }
}
