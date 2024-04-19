using System.Globalization;

namespace DiscreteProject.Logic;

public class Board
{
    public int Size { get; set; }
    public Row[] Rows { get; set; }
    public Board(int size)
    {
        Size = size;
        Rows = new Row[size];
        for (int i = 0; i < size; i++)
        {
            Rows[i] = new Row(size);
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
            Rows[rowNumber].SetText(input);
        }
    }
    public void ReduceBoardTo2x2()
    {
        var board = this;
        int n = Size;
        for (int layer = 0; layer < n - 2; layer++)
        {
            for (int i = layer; i < n - 1; i++)
            {
                if (board.Rows[layer].Cells[i].Value == '0')
                {
                    AddElementOfH(layer, i);
                }
                if (board.Rows[i].Cells[layer].Value == '0')
                {
                    AddElementOfH(i, layer);
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (board.Rows[n - 1].Cells[i].Value == '0')
            {
                AddElementOfH(n - 1, i);
            }
            if (board.Rows[i].Cells[n - 1].Value == '0')
            {
                AddElementOfH(i, n - 1);
            }
        }

        if (IsBoardSolvable())
        {
            throw new Exception("The current board can be solved.");
        }
        else
        {
            throw new Exception("The current board can't be solved.");
        }
    }
    private void AddElementOfH(int i, int j)
    {
        Rows[i].Cells[j] = Rows[i].Cells[j].Value == '0' ? new Cell('X') : new Cell('0');
    }

    public bool IsBoardSolvable()
    {
        int n = Size;
        return Rows[n - 2].Cells[n - 2].Value == 'X' && Rows[n - 2].Cells[n - 1].Value == 'X' &&
               Rows[n - 1].Cells[n - 2].Value == 'X' && Rows[n - 1].Cells[n - 1].Value == 'X';

    }
    public void ModifyCell(Cell cell)
    {
        cell.InvertValue();
    }
}
