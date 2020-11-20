namespace projectEuler
{
    class Prb15
    {
        private int gridSize;

        public Prb15(int GridSize)
        {
            this.gridSize = GridSize;
        }
        public long RunPathsRecur()
        {
            long[,] utilGrid = new long[this.gridSize, this.gridSize];
            for (int r = 0; r < this.gridSize; r++)
            {
                utilGrid[r,0] = 1;
                utilGrid[0, r] = 1;
            }

            for (int r = 1; r < this.gridSize; r++)
            {
                for (int c = 1; c < this.gridSize; c++)
                {
                    utilGrid[r, c] = utilGrid[r-1, c] + utilGrid[r, c-1];
                }
            }

            return utilGrid[this.gridSize-1, this.gridSize-1];
        }

        public static string Run()
        {
            long result = (new Prb15(21)).RunPathsRecur();
            return $"{result}";
        }
    }
}