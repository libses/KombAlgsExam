namespace KombAlgsExam
{
    public class NonIntersectingSet<T>
    {
        private Dictionary<T, HashSet<T>> sets = new Dictionary<T, HashSet<T>>();
        public bool Add(T first, T second)
        {
            if (sets.ContainsKey(first) && sets.ContainsKey(second))
            {
                if (sets[first] == sets[second])
                {
                    return false;
                }

                sets[first].UnionWith(sets[second]);
                foreach (var s in sets[second])
                {
                    sets[s] = sets[first];
                }

                return true;
            }

            if (sets.ContainsKey(first))
            {
                sets[first].Add(second);
                sets.Add(second, sets[first]);
                return true;
            }

            if (sets.ContainsKey(second))
            {
                sets[second].Add(first);
                sets.Add(first, sets[second]);
                return true;
            }

            var hs = new HashSet<T>() { first, second };
            sets.Add(first, hs);
            sets.Add(second, hs);
            return true;
        }
    }
}