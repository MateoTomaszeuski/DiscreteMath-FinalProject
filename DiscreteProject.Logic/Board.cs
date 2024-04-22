using System.Drawing;
using System.Globalization;

namespace DiscreteProject.Logic;

public class Board
{
    public int Size { get; set; }
    private Row[] rows;
    public Row[] Rows { get => rows; }
    public Action ElementOfHAdded { get; set; }
    public Board(int size)
    {
        Size = size;
        rows = new Row[size];
        for (int i = 0; i < size; i++)
        {
            rows[i] = new Row(size);
        }
    }
    public Board(Board old)
    {
        Size = old.Size;
        rows = new Row[Size];
        for (int i = 0; i < Size; i++)
        {
            rows[i] = old.rows[i];
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
    public void ReduceBoardTo2x2()
    {
        int n = Size;
        while (n >= 2)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (rows[i].Cells[0].Value == '0' && rows[i + 1].Cells[0].Value == '0' && rows[i + 2].Cells[0].Value != '0')
                {
                    var newCells = AddElementOfH(rows[i].Cells[0], rows[i + 1].Cells[0], rows[i + 2].Cells[0]);
                    rows[i].Cells[0] = newCells.a;
                    rows[i + 1].Cells[0] = newCells.b;
                    rows[i + 2].Cells[0] = newCells.c;
                }
                else if (rows[0].Cells[i].Value == '0' && rows[0].Cells[i + 1].Value == '0' && rows[0].Cells[i + 2].Value != '0')
                {
                    var newCells = AddElementOfH(rows[0].Cells[i], rows[0].Cells[i + 1], rows[0].Cells[i + 2]);
                    rows[0].Cells[i] = newCells.a;
                    rows[0].Cells[i + 1] = newCells.b;
                    rows[0].Cells[i + 2] = newCells.c;
                }
            }
            n--;
        }
        if (IsBoardSolvable())
        {
            throw new Exception("Board is solvable");
        }
        else
        {
            throw new Exception("Board is not solvable");
        }
    }
    private (Cell a, Cell b, Cell c) AddElementOfH(Cell a, Cell b, Cell c)
    {
        a.InvertValue();
        b.InvertValue();
        c.InvertValue();
        return (a, b, c);
    }

    public bool IsBoardSolvable()
    {
        int n = Size;
        return rows[n - 2].Cells[n - 2].Value == 'X' && rows[n - 2].Cells[n - 1].Value == 'X' &&
               rows[n - 1].Cells[n - 2].Value == 'X' && rows[n - 1].Cells[n - 1].Value == 'X';

    }
    public void ModifyCell(Cell cell)
    {
        cell.InvertValue();
    }
}
