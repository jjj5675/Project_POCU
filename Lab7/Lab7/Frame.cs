using System;
using System.Collections.Generic;

namespace Lab7
{
    public class Frame
    {
        public EFeatureFlags Features { get; private set; }
        public uint ID { get; private set; }
        public string Name { get; private set; }


        public Frame(uint id, string name)
        {
            ID = id;
            Name = name;
            Features = EFeatureFlags.Default;
        }

        public void ToggleFeatures(EFeatureFlags features)
        {
            Features ^= features;
        }

        public void TurnOnFeatures(EFeatureFlags features)
        {
            Features |= features;
        }

        public void TurnOffFeatures(EFeatureFlags features)
        {
            Features &= ~features;
        }
    }

    class FrameComparer : IEqualityComparer<Frame>
    {
        public bool Equals(Frame x, Frame y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            return x.ID == y.ID && x.Name == y.Name;
        }

        public int GetHashCode(Frame obj)
        {
            if (obj is null)
            {
                return 0;
            }

            int hashFrameName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashFrameID = obj.ID.GetHashCode();

            return hashFrameName ^ hashFrameID;
        }
    }
}
