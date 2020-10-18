using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    class Recyclebot
    {
        public List<Item> RecycleItems { get; private set; }
        public List<Item> NonRecycleItems { get; private set; }

        public Recyclebot()
        {
            RecycleItems = new List<Item>();
            NonRecycleItems = new List<Item>();
        }

        public void Add(Item item)
        {
            if (item.Type != EType.Paper
                && item.Type != EType.Furniture
                && item.Type != EType.Electronics)
            {
                RecycleItems.Add(item);
                return;
            }

            if (item.Weight < 5 && item.Weight >= 2)
            {
                RecycleItems.Add(item);
                return;
            }

            NonRecycleItems.Add(item);
        }

        public List<Item> Dump()
        {
            bool[] implicationStates = new bool[NonRecycleItems.Count];

            foreach (var item in NonRecycleItems.Select((value, index) => new { value, index }))
            {
                if (item.value.Volume == 10 || item.value.Volume == 11 || item.value.Volume == 15)
                {
                    implicationStates[item.index] = true;
                    continue;
                }

                if (!item.value.IsToxicWaste)
                {
                    implicationStates[item.index] = false;
                    continue;
                }

                implicationStates[item.index] = true;
            }

            List<Item> dumpItems = new List<Item>();

            foreach (var item in NonRecycleItems.Select((value, index) => new { value, index }))
            {
                if (!implicationStates[item.index])
                {
                    dumpItems.Add(item.value);
                    continue;
                }

                if (item.value.Type != EType.Furniture && item.value.Type != EType.Electronics)
                {
                    continue;
                }

                dumpItems.Add(item.value);
            }

            return dumpItems;
        }

    }
}
