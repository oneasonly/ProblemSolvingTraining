using System.Collections.Generic;
using Caliburn.Micro;

namespace Week1Task1
{
    public class ViewModel : PropertyChangedBase
    {
        public uint BanditAmount { get => _banditAmount; set => Set(ref _banditAmount, value); }
        private uint _banditAmount;
        public uint EveryN { get => _everyN; set => Set(ref _everyN, value); }
        private uint _everyN;
        public uint LastKilledNumber { get => _lastKilledNumber; set => Set(ref _lastKilledNumber, value); }
        private uint _lastKilledNumber;

        public void Calculate()
        {
            var bandits = InitBandits();
            int index = 0;
            int killCount = 1;
            while(bandits.Count > 1)
            {
                if (index >= bandits.Count) index = 0;
                if (killCount == EveryN)
                {
                    bandits.RemoveAt(index);
                    killCount = 1;
                }
                if (index >= bandits.Count) index = 0;
                index++;
                killCount++;
            }
            LastKilledNumber = bandits[0].InitialNumber;
        }

        private List<Bandit> InitBandits()
        {
            var list = new List<Bandit>((int)BanditAmount);
            for (uint i = 0; i < BanditAmount; i++)
            {
                list.Add(new Bandit(i + 1));
            }
            return list;
        }
        public struct Bandit
        {
            public Bandit(uint number) => InitialNumber = number;
            public uint InitialNumber { get; private set; }
        }
    }
}
