

namespace DiscreteProject.Logic
{
    public class Cell
    {
        private char v;
        public char Value { get => v; }

        public Cell(char v)
        {
            this.v = v;
        }

        internal void InvertValue()
        {
            if (v == 'X')
            {
               v = '0';
            }
            else if (v == '0')
            {
                v = 'X';
            }
        }

        internal void ChangeValue(char v)
        {
            this.v = v;
        }
    }
}