/*
prb11.cs
Find largest product in a grid
*/

namespace projectEuler
{
    using System;
    using System.IO;

    public class Prb11
    {
        public static long Run()
        {
            int[,] inpArr = GetInpArrFromFile();
            int dimSize = 4;
            int numRows = inpArr.GetLength(0);
            int numCols = inpArr.GetLength(1);

            long result = -1;
            for (int r = 0; r < numRows; r++)
            {
                for(int c = 0; c < numCols; c++)
                {
                    // TODO: Get all direction prod
                    // get right product
                    result = Math.Max(result, GetRightProduct(inpArr, r, c, dimSize));
                    // get downward product
                    result = Math.Max(result, GetDownwardProduct(inpArr, r, c, dimSize));
                    // get diagonal Top left to bottom right product
                    result = Math.Max(result, GetDiagonal_TLBR_Product(inpArr, r, c, dimSize));
                    // get diagonal bottom left to Top right product
                    result = Math.Max(result, GetDiagonal_BLTR_Product(inpArr, r, c, dimSize));
                }
            }

            return result;
        }

        public static int[,] GetInpArrFromFile()
        {
            int rowSize = 20;
            int colSize = 20;
            int [,] result = new int[rowSize, colSize];
            int lineIdx = 0;
            using (StreamReader sr = new StreamReader(@"resources\p11_grid_product.txt"))
            {
                while(sr.Peek() >= 0)
                {
                    int[] lineVals = ParseLine(sr.ReadLine(), colSize);
                    for(int c = 0; c < lineVals.Length; c++)
                    {
                        result[lineIdx, c] = lineVals[c];
                    }
                    lineIdx++;
                }
            }
            return result;
        }

        public static int[] ParseLine(string line, int colSize)
        {
            int[] result = new int[colSize];
            int begin = 0;
            int end;
            int idx = 0;
            while(begin < line.Length)
            {
                end = begin;
                while(end < line.Length && line[end] != ' ') end++;
                result[idx++] = Int32.Parse(line.Substring(begin, end - begin));
                begin = end + 1;
            }
            return result;
        }

        public static long GetRightProduct(int[,] twoDArr, int r, int c, int dimSize)
        {
            int numCols = twoDArr.GetLength(1);

            if (c + dimSize > numCols) return -1;
            long result = 1;
            for(int i = c; i < c + dimSize; i++)
                result *= twoDArr[r, i];
            return result;
        }

        public static long GetDownwardProduct(int[,] twoDArr, int r, int c, int dimSize)
        {
            int numRows = twoDArr.GetLength(0);;

            if (r + dimSize > numRows) return -1;
            long result = 1;
            for (int i = r; i < r + dimSize; i++)
                result *= twoDArr[i, c];
            return result;
        }

        public static long GetDiagonal_BLTR_Product(int[,] twoDArr, int r, int c, int dimSize)
        {
            int numCols = twoDArr.GetLength(1);
            int numRows = twoDArr.GetLength(0);

            if (r < dimSize - 1) return -1;
            if (c + dimSize > numCols) return -1;
            long result = 1;
            for(int i = 0; i < dimSize; i++)
            {
                result *= twoDArr[r - i, c + i];
            }
            return result;
        }

        public static long GetDiagonal_TLBR_Product(int[,] twoDArr, int r, int c, int dimSize)
        {
            int numCols = twoDArr.GetLength(1);
            int numRows = twoDArr.GetLength(0);

            if (r + dimSize > numRows) return -1;
            if (c + dimSize > numCols) return -1;
            long result = 1;
            for(int i = 0; i < dimSize; i++)
            {
                result *= twoDArr[r + i, c + i];
            }
            return result;
        }
    }
}