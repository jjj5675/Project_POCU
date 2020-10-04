using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public sealed class MultiSet : IEquatable<MultiSet>
    {
        private List<string> mSet = new List<string>();

        public void Add(string element)
        {
            mSet.Add(element);
            mSet.Sort();
        }

        public bool Remove(string element)
        {
            if (!mSet.Contains(element))
            {
                return false;
            }

            if (mSet.Remove(element))
            {
                return true;
            }

            return false;
        }

        public int GetMultiplicity(string element)
        {
            if (mSet.Contains(element))
            {
                return mSet.FindAll(s => s.Equals(element)).Count;
            }

            return 0;
        }

        public List<string> ToList()
        {
            return mSet.ConvertAll(s => s);
        }

        public MultiSet Union(MultiSet other)
        {
            MultiSet cSet = new MultiSet();

            IEnumerable<string> union = this.mSet.Union(other.mSet);

            foreach (var element in union)
            {
                int a = this.GetMultiplicity(element);
                int b = other.GetMultiplicity(element);

                int count = Math.Max(a, b);

                while (count > 0)
                {
                    cSet.Add(element);
                    count--;
                }
            }

            return cSet;
        }

        public MultiSet Intersect(MultiSet other)
        {
            MultiSet cSet = new MultiSet();

            IEnumerable<string> union = this.mSet.Union(other.mSet);

            foreach (var element in union)
            {
                int a = this.GetMultiplicity(element);
                int b = other.GetMultiplicity(element);

                int count = Math.Min(a, b);

                while (count > 0)
                {
                    cSet.Add(element);
                    count--;
                }
            }

            return cSet;
        }

        public MultiSet Subtract(MultiSet other)
        {
            MultiSet cSet = new MultiSet();

            IEnumerable<string> union = this.mSet.Union(other.mSet);

            foreach (var element in union)
            {
                int a = this.GetMultiplicity(element);
                int b = other.GetMultiplicity(element);

                int count = Math.Max(a - b, 0);

                while (count > 0)
                {
                    cSet.Add(element);
                    count--;
                }
            }

            return cSet;
        }

        public List<MultiSet> FindPowerSet()
        {
            List<MultiSet> powersetList = new List<MultiSet>();

            findPowerSet(ref powersetList, mSet, new bool[mSet.Count], 0, mSet.Count);

            powersetList.Sort(delegate (MultiSet x, MultiSet y)
            {
                if (x.mSet.Count == 0 && y.mSet.Count == 0)
                {
                    return 0;
                }
                else if (x.mSet.Count == 0)
                {
                    return -1;
                }
                else if (y.mSet.Count == 0)
                {
                    return 1;
                }
                else
                {
                    int order = x.mSet[0].CompareTo(y.mSet[0]);

                    if (order == 0)
                    {
                        return x.mSet.Count <= y.mSet.Count ? -1 : 1;
                    }
                    else
                    {
                        return order;
                    }
                }
            });


            return powersetList;
        }

        private void findPowerSet(ref List<MultiSet> powersetList, List<String> list, bool[] include, int index, int end)
        {
            if (index >= end)
            {
                MultiSet set = new MultiSet();

                foreach (var element in mSet.Select((value, index) => new { value, index }))
                {
                    if (include[element.index])
                    {
                        set.Add(element.value);
                    }
                }

                if (!powersetList.Contains(set))
                {
                    powersetList.Add(set);
                }

                return;
            }

            include[index] = false;
            findPowerSet(ref powersetList, list, include, index + 1, end);

            include[index] = true;
            findPowerSet(ref powersetList, list, include, index + 1, end);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            MultiSet objAsMultiSet = obj as MultiSet;

            if (objAsMultiSet == null)
            {
                return false;
            }
            else
            {
                return Equals(objAsMultiSet);
            }
        }

        public bool Equals(MultiSet other)
        {
            if (other == null)
            {
                return false;
            }

            return this.mSet.SequenceEqual(other.mSet);
        }

        public bool IsSubsetOf(MultiSet other)
        {
            MultiSet multiSet = Intersect(other);

            if (this.mSet.SequenceEqual(multiSet.mSet))
            {
                return true;
            }

            return false;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            MultiSet multiSet = Union(other);

            if (this.mSet.SequenceEqual(multiSet.mSet))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return mSet.GetHashCode();
        }
    }
}