/*
prb9.cs

pythongorean triplet summing to 1000
*/


namespace projectEuler
{
    public class Prb9
    {
        public static string Run()
        {
            int totalSum = 1000;
            string result = "";
            for(int a = 1; a < totalSum + 1; a++)
            {
                for(int b=a; b < totalSum + 1; b++)
                {
                    for(int c = b; c < totalSum + 1; c++)
                    {
                        if ((a+b+c != totalSum)) continue;

                        if (a*a + b*b != c*c) continue;

                        result += $"a={a}--b={b}--c={c}\ta*b*c={a*b*c}"; 
                    }
                }
            }

            return result;
        }
    }
}