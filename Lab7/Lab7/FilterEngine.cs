using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7
{
    public static class FilterEngine
    {
        public static List<Frame> FilterFrames(List<Frame> frames, EFeatureFlags features)
        {
            byte flags;
            List<Frame> filteredFrames = new List<Frame>();

            foreach (var frame in frames)
            {
                flags = (byte)(frame.Features & features);
                if (flags != 0)
                {
                    filteredFrames.Add(frame);
                }
            }

            return filteredFrames;
        }

        public static List<Frame> FilterOutFrames(List<Frame> frames, EFeatureFlags features)
        {
            byte flags;
            List<Frame> filteredFrames = new List<Frame>();

            foreach (var frame in frames)
            {
                flags = (byte)(frame.Features & features);
                if (flags == 0)
                {
                    filteredFrames.Add(frame);
                }
            }

            return filteredFrames;
        }

        public static List<Frame> Intersect(List<Frame> frames1, List<Frame> frames2)
        {
            IEnumerable<Frame> duplicates = frames1.Intersect(frames2, new FrameComparer());
            return new List<Frame>(duplicates);
        }

        public static List<int> GetSortKeys(List<Frame> frames, List<EFeatureFlags> features)
        {
            int[] sortKeys = new int[frames.Count];

            foreach (var frame in frames.Select((value, index) => new { value, index }))
            {
                foreach (var feature in features.Select((value, index) => new { value, index }))
                {
                    if ((byte)(frame.value.Features & feature.value) != 0)
                    {
                        sortKeys[frame.index] += features.Count - feature.index;
                    }
                }
            }

            return sortKeys.ToList();
        }
    }
}
