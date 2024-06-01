namespace AlgoExpert.io.Medium
{
    /*
        LONGEST PEAK  

          Write a function that takes in an array of integers and returns the length of the longest peak in the array.
          A peak is defined as adjacent integers in the array that are strictly increasing until they reach a tip (the highest value in the peak), at which
          point they become strictlydecreasing. At least three integers are required to form a peak.

          For example, the integers 1, 4, 10, 2 form a peak, but the integers 4, 0, 10 don't and neither do the integers 1, 2, 2, 0. Similarly, the integers 1, 2, 3 don't
          form a peak because there aren't any strictly decreasing integers after the 3.

         INPUT

         array = [1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3]

         OUTPUT
         6 // 0, 10, 6, 5, -1, -3
    */

    internal class B6
    {
        public static int LongestPeak(int[] array)
        {
            int longestPeakLength = 0;
            int i = 1;

            while (i < array.Length - 1)
            {
                bool isPeak = ((array[i - 1] < array[i]) && (array[i] > array[i + 1]));

                if (isPeak)
                {
                    i += 1;
                    continue;
                }

                int leftIdx = i - 2;
                while (leftIdx >= 0 && array[leftIdx] < array[leftIdx + 1])
                {
                    leftIdx -= 1;
                }

                int rightIdx = i + 2;
                while (rightIdx < array.Length && array[rightIdx] < array[rightIdx - 1])
                {
                    rightIdx += 1;
                }

                int currentPeakLength = rightIdx - leftIdx - 1;
                if (currentPeakLength > longestPeakLength)
                {
                    longestPeakLength = currentPeakLength;
                }

                i = rightIdx;
            }

            return longestPeakLength;
        }
    }
}
