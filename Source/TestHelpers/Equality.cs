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

        public static bool AreEqual<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            IEnumerator<T> it1 = first.GetEnumerator();
            IEnumerator<T> it2 = second.GetEnumerator();

            bool canFirstContiune, canSecondContinue;

            while (true)
            {
                canFirstContiune = it1.MoveNext();
                canSecondContinue = it2.MoveNext();

                if (canFirstContiune && canSecondContinue)
                {
                    if (!it1.Current.Equals(it2.Current))
                        // the have at least differ on one item (current one)
                        // which makes them not equal
                        return false;
                }
                else if (!canFirstContiune && canSecondContinue ||
                         canFirstContiune && !canSecondContinue)
                {
                    // they are not of the same length
                    return false;
                }
                else
                {
                    // done going through the whole items and they are
                    // all equal
                    return true;
                }
            }
        }
    }
}