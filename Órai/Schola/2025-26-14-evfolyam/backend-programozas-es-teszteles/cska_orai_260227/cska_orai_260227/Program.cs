using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace cska_orai_260227
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            int width = Math.Max(20, Console.WindowWidth - 1);
            int height = Math.Max(10, Console.WindowHeight - 2);

            int xScale = 2;
            int gridW = Math.Max(10, width / xScale);
            int gridH = Math.Max(6, height);

            char empty = ' ';
            char fill = '█';

            var grid = new char[gridH, gridW];
            for (int r = 0; r < gridH; r++)
                for (int c = 0; c < gridW; c++)
                    grid[r, c] = empty;

            int left = 0, top = 0;
            int right = gridW - 1, bottom = gridH - 1;

            int stepsPerFrame = 6;
            int delayMs = 12;

            while (left <= right && top <= bottom)
            {
                for (int x = left; x <= right; x++)
                {
                    grid[top, x] = fill;
                    Animate(grid, xScale, stepsPerFrame, delayMs);
                }
                top++;

                for (int y = top; y <= bottom; y++)
                {
                    grid[y, right] = fill;
                    Animate(grid, xScale, stepsPerFrame, delayMs);
                }
                right--;

                if (top > bottom || left > right) break;

                for (int x = right; x >= left; x--)
                {
                    grid[bottom, x] = fill;
                    Animate(grid, xScale, stepsPerFrame, delayMs);
                }
                bottom--;

                for (int y = bottom; y >= top; y--)
                {
                    grid[y, left] = fill;
                    Animate(grid, xScale, stepsPerFrame, delayMs);
                }
                left++;
            }

            Console.SetCursorPosition(0, 0);
            Render(grid, xScale);

            string endText = "END";
            int endY = Math.Max(0, gridH / 2);
            int endX = Math.Max(0, (gridW * xScale - endText.Length) / 2);

            Console.SetCursorPosition(Math.Min(Console.WindowWidth - 1, endX), Math.Min(Console.WindowHeight - 1, endY));
            Console.Write(endText);

            Console.SetCursorPosition(0, Math.Min(Console.WindowHeight - 1, gridH + 1));
            Console.CursorVisible = true;
        }

        static int _counter = 0;

        static void Animate(char[,] grid, int xScale, int stepsPerFrame, int delayMs)
        {
            _counter++;
            if (_counter % stepsPerFrame != 0) return;

            Console.SetCursorPosition(0, 0);
            Render(grid, xScale);
            Thread.Sleep(delayMs);
        }

        static void Render(char[,] grid, int xScale)
        {
            int h = grid.GetLength(0);
            int w = grid.GetLength(1);

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    for (int k = 0; k < xScale; k++)
                    {
                        Console.Write(grid[y, x]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
