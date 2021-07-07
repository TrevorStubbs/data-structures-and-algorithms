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
            List<Interval> input1 = new List<Interval>();
            input1.Add(new Interval(7, 9));
            input1.Add(new Interval(1, 4));
            input1.Add(new Interval(2, 5));

            var merged1 = MergeIntervals.MergeIntervalsWithoutEnumerator(input1);

            foreach (var interval in merged1)
                Console.Write($"[{interval.Start}, {interval.End}] ");

            Console.WriteLine();

            List<Interval> input2 = new List<Interval>();
            input2.Add(new Interval(6, 7));
            input2.Add(new Interval(2, 4));
            input2.Add(new Interval(5, 9));

            var merged2 = MergeIntervals.MergeIntervalsWithoutEnumerator(input2);

            foreach (var interval in merged2)
                Console.Write($"[{interval.Start}, {interval.End}] ");

            Console.WriteLine();

            List<Interval> input3 = new List<Interval>();
            input3.Add(new Interval(1, 4));
            input3.Add(new Interval(2, 6));
            input3.Add(new Interval(3, 5));

            var merged3 = MergeIntervals.MergeIntervalsWithoutEnumerator(input3);

            foreach (var interval in merged3)
                Console.Write($"[{interval.Start}, {interval.End}] ");

            Console.WriteLine();
            Console.WriteLine();

            List<Interval> insertTest1 = new List<Interval>();
            insertTest1.Add(new Interval(1, 3));
            insertTest1.Add(new Interval(5, 7));
            insertTest1.Add(new Interval(8, 12));

            var insertMerge1 = MergeIntervals.InsertInterval(insertTest1, new Interval(4, 6));

            foreach (var interval in insertMerge1)
                Console.Write($"[{interval.Start}, {interval.End}] ");

            Console.WriteLine();

            var insertMerge2 = MergeIntervals.InsertInterval(insertTest1, new Interval(4, 10));

            foreach (var interval in insertMerge2)
                Console.Write($"[{interval.Start}, {interval.End}] ");

            Console.WriteLine();

            List<Interval> insertTest3 = new List<Interval>();
            insertTest3.Add(new Interval(2, 3));
            insertTest3.Add(new Interval(5, 7));

            var insertMerge3 = MergeIntervals.InsertInterval(insertTest3, new Interval(1, 4));

            foreach (var interval in insertMerge3)
                Console.Write($"[{interval.Start}, {interval.End}] ");

            Console.WriteLine();

        }

        public static class MergeIntervals
        {
            // Time: O(n * logN)
            // Space: O(n)
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

            public static List<Interval> MergeIntervalsWithoutEnumerator(List<Interval> intervals)
            {
                if (intervals.Count < 2)
                    return intervals;

                intervals = intervals.OrderBy(x => x.Start).ToList();

                List<Interval> mergedIntervals = new List<Interval>();
                int start = intervals[0].Start, end = intervals[0].End;

                foreach (var interval in intervals)
                {
                    if (interval.Start <= end)
                        end = Math.Max(interval.End, end);
                    else
                    {
                        mergedIntervals.Add(new Interval(start, end));
                        start = interval.Start;
                        end = interval.End;
                    }
                }

                mergedIntervals.Add(new Interval(start, end));

                return mergedIntervals;
            }

            public static List<Interval> InsertInterval(List<Interval> intervals, Interval newInterval)
            {
                intervals.Add(newInterval);

                intervals = intervals.OrderBy(x => x.Start).ToList();

                List<Interval> mergedInterval = new List<Interval>();
                int start = intervals[0].Start, end = intervals[0].End;

                foreach (var interval in intervals)
                {
                    if (interval.Start <= end)
                        end = Math.Max(interval.End, end);
                    else
                    {
                        mergedInterval.Add(new Interval(start, end));
                        start = interval.Start;
                        end = interval.End;
                    }
                }

                mergedInterval.Add(new Interval(start, end));

                return mergedInterval;
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
