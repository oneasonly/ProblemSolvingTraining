using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week1Task2
{
    public class ViewModel : PropertyChangedBase
    {
        private int x;
        private int y;
        public BindableCollection<Move> Moves { get; } = new BindableCollection<Move>();
        public BindableCollection<House> Houses { get; } = new BindableCollection<House>();

        public void Calculate()
        {
            Houses.Clear();
            y = x = 0;
            var tempHouses = new List<House>();

            foreach (var move in Moves)
            {
                if (move == Move.up) y++;
                else if (move == Move.down) y--;
                else if (move == Move.left) x--;
                else if (move == Move.right) x++;

                var house = new House(x, y);
                if (!tempHouses.Contains(house)) tempHouses.Add(house);
            }
            Houses.AddRange(tempHouses);
        }

        public void Up() => Moves.Add(Move.up);
        public void Down() => Moves.Add(Move.down);
        public void Left() => Moves.Add(Move.left);
        public void Right() => Moves.Add(Move.right);
        public void Reset()
        {
            Moves.Clear();
            Houses.Clear();
        }

        public struct House
        {
            public House(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X;
            public int Y;
            public override string ToString() => $"{X}, {Y}";
        }
        public enum Move
        {
            left,
            right,
            up,
            down,
        }
    }
}
