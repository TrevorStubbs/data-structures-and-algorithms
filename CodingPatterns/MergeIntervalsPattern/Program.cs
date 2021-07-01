using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MergeIntervalsPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Interval> input = new List<Interval>();
            input.Add(new Interval(7, 9));
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 5));

            var merged = MergeIntervals.MergeOverlapingIntervals(input);

            foreach (var interval in merged)            
                Console.Write($"[{interval.Start}, {interval.End}] ");            

            Console.WriteLine();

        }

        public static class MergeIntervals
        {
            public static List<Interval> MergeOverlapingIntervals(List<Interval> intervals)
            {
                // If there is only 1 interval then just return the input.
                if (intervals.Count < 2)
                    return intervals;

                // Order the objects by their start properties
                intervals = intervals.OrderBy(x => x.Start).ToList();

                // This is the output
                List<Interval> mergedIntervals = new List<Interval>();

                // Define an enumerator for the interval objects so we can while loop through them. 
                IntervalEnumerator intervalEnumerator = new IntervalEnumerator(intervals);
                // Iterate to the first Interval
                intervalEnumerator.MoveNext();
                Interval interval = intervalEnumerator.Current;
                int start = interval.Start;
                int end = interval.End;

                do
                {

                    interval = intervalEnumerator.Current;
                    if (interval.Start <= end)
                        end = Math.Max(interval.End, end);
                    else
                    {
                        mergedIntervals.Add(new Interval(start, end));
                        start = interval.Start;
                        end = interval.End;
                    }
                } while (intervalEnumerator.MoveNext());

                mergedIntervals.Add(new Interval(start, end));

                return mergedIntervals;
            }
        }

        public class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }

            public Interval(int start, int end)
            {
                Start = start;
                End = end;
            }
        }

        public class IntervalEnumerator : IEnumerator<Interval>
        {
            public Interval Current { get { return curInterval; } }
            object IEnumerator.Current { get { return Current; } }

            private List<Interval> _collection;
            private int curIndex;
            private Interval curInterval;

            public IntervalEnumerator(List<Interval> intervals)
            {
                _collection = intervals;
                curIndex = -1;
                curInterval = default(Interval);
            }

            public bool MoveNext()
            {
                if (++curIndex >= _collection.Count)
                    return false;
                else
                    curInterval = _collection[curIndex];

                return true;
            }

            public void Reset() { curIndex = -1; }

            void IDisposable.Dispose() { }

        }
            
    }
}
