/*
prb8.cs
Find largest 13digit multiple 
*/

namespace projectEuler
{
    using System;
    using System.IO;

    public class Prb8
    {
        public static long Run()
        {
            long maxProd = -1, currProd = 1;
            int num_size = 13;
            // int[] inpArr = ReadArr(@"resources\test_fname.txt", 13);
            int[] inpArr = ReadArr(@"resources\p08_1000digit_number.txt", 1000);
            int back = 0, forward = 0;

            while (back <= inpArr.Length - num_size)
            {
                forward = back;
                currProd = 1;
                while(forward - back < num_size)
                {
                    currProd *= inpArr[forward];
                    forward++;
                }
                maxProd = Math.Max(currProd, maxProd);
                back++;
            }
            return maxProd;
        }

        public static int[] ReadArr(string inpFname, int numChar)
        {
            int[] result = new int[numChar];
            char currChar;
            int currPtr = 0;
            using (StreamReader sr = new StreamReader(inpFname))
            {
                while (sr.Peek() >= 0)
                {
                    currChar = (char)sr.Read();
                    if(Char.IsWhiteSpace(currChar))
                    {
                        continue;
                    }
                    result[currPtr++] = currChar - '0';
                }
            }

            return result;
        }

    }
}