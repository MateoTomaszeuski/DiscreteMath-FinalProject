
namespace DiscreteProject.Logic;

public class Row
{
    public List<Cell> Cells { get; private set; }
    public Row(int width)
    {
        Cells = new(width);
        for (int i = 0; i < Cells.Capacity; i++)
        {
            Cells.Add(new('X'));
        }
    }

    internal void SetText(string s)
    {
        for(int i = 0; i < s.Length; i++)
        {
            if (s[i] != '0' && s[i] != 'X')
            {
                throw new Exception("Invalid row configuration");
            }
            Cells[i].ChangeValue(s[i]);
        }
    }
}
