using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    // A driver is driving on the freeway. The check engine light
    // of his vehicle is on, and the driver wants to get service immediately.
    // Luckily, a service lane runs parallel to the highway.
    // It varies in width along its length.

    // You will be given an array of widths at points along the road (indices),
    // then a list of the indices of entry and exit points. Considering each
    // entry and exit point pair, calculate the maximum size vehicle that can
    // travel that segment of the service lane safely.

    // Example
    // width = [2, 3, 1, 2, 3, 2, 3, 3]
    // cases = [[0, 3], [4, 6], [6, 7], [3, 5], [0, 7]]
    // result = [1, 2, 3, 2, 1]

    // Complete the serviceLane function below.
    static int[] serviceLane(int[] width, int[][] cases)
    {
        List<int> result = new List<int>();

        // Iterate the cases
        for (int c = 0; c < cases.Length; c++)
        {
            // Iterate the service lane widths
            int min = -1;
            for (int i = cases[c][0]; i <= cases[c][1]; i++)
            {
                // Track the min lane width
                if (min < 0 || width[i] < min)
                    min = width[i];

                // If min width is 1, there is
                // no smaller width so exit the case
                if (min == 1)
                    break;
            }

            // Add the min lane width to the results
            result.Add(min);
        }

        return result.ToArray();
    }

    static void Main(string[] args)
    {
        List<int[][]> testcases = new List<int[][]>
        {
            new int[][]
            {
                // First array is service lane widths
                // The rest are lower and upper indices into first array
                new int[] { 2, 3, 1, 2, 3, 2, 3, 3 },
                new int[] {0, 3},
                new int[] {4, 6},
                new int[] {6, 7},
                new int[] {3, 5},
                new int[] {0, 7},
            },
            new int[][]
            {
                // First array is service lane widths
                // The rest are lower and upper indices into first array
                new int[] { 2, 3, 2, 1 },
                new int[] {1, 2},
                new int[] {2, 4},
            }
        };

        foreach(int[][] testcase in testcases)
        {
            // Breakout the testcase
            int[] width = testcase[0];
            int[][] cases = testcase[1..];

            int[] result = serviceLane(width, cases);

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
