using System;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.TestHelpers
{
    public static class Equality
    {
        public static bool AreEqual<T>(ICollection<T> first, ICollection<T> second)
        {
            if (first.Count != second.Count)
                return false;

            IEnumerator<T> it1 = first.GetEnumerator();
            IEnumerator<T> it2 = second.GetEnumerator();

            for (int i = 0; i < first.Count; i++)
            {
                it1.MoveNext();
                it2.MoveNext();
                if (!it1.Current.Equals(it2.Current))
                    return false;
            }

            return true;
        }
    }
}
