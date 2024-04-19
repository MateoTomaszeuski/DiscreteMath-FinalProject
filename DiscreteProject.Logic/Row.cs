
namespace DiscreteProject.Logic;

public class Row
{
    public List<char> RowText { get; private set; }
    public Row(int width)
    {
        RowText = new(width);
        for (int i = 0; i < RowText.Capacity; i++)
        {
            RowText.Add('X');
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
            RowText[i] = s[i];
        }
    }
}
