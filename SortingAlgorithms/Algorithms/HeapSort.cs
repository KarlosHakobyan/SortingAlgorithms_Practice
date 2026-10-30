using System.Text;

namespace SortingAlgorithms.Algorithms
{
    internal class HeapSort
    {
        private static bool _isPaused = false;
        private static bool _exitRequested = false;

        public static void LaunchHeapSort()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            _isPaused = false;
            _exitRequested = false;

            int[] array = GenerateRandomArray(15, 1, 20);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==================================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("         [ SYSTEM ]: HEAP SORT VISUALIZER         ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==================================================");
            Console.ResetColor();

            DrawArray(array);

            int complexityPosition = array.Length + 6;
            PrintComplexityInfo(complexityPosition);

            int pausePromptPosition = complexityPosition + 7;
            Console.SetCursorPosition(0, pausePromptPosition);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Press [1] for pause...");
            Console.ResetColor();

            Console.SetCursorPosition(0, pausePromptPosition + 2);
            Console.Write("Press any key to start sorting...");
            Console.ReadKey(true);

            Console.SetCursorPosition(0, pausePromptPosition + 2);
            Console.Write(new string(' ', 40));

            HeapSortWithVisualization(array, delayMs: 150, pausePromptPosition);

            if (!_exitRequested)
            {
                DrawArray(array);
            }

            Console.ResetColor();

            if (_exitRequested) return;

            Console.SetCursorPosition(0, pausePromptPosition + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" [SYSTEM]: Sorting finished successfully.");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to return to the system menu...");
            Console.ReadKey(true);
            Console.CursorVisible = true;
        }

        static void HeapSortWithVisualization(int[] arr, int delayMs, int pausePos)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0 && !_exitRequested; i--)
            {
                Heapify(arr, n, i, delayMs, pausePos);
            }

            for (int i = n - 1; i > 0 && !_exitRequested; i--)
            {
                CheckInput(pausePos);
                if (_exitRequested) return;

                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                DrawArray(arr, activeIndex1: 0, activeIndex2: i);
                CustomSleep(delayMs, pausePos);
                if (_exitRequested) return;

                Heapify(arr, i, 0, delayMs, pausePos);
            }
        }

        static void Heapify(int[] arr, int n, int i, int delayMs, int pausePos)
        {
            if (_exitRequested) return;

            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && arr[l] > arr[largest])
                largest = l;

            if (r < n && arr[r] > arr[largest])
                largest = r;

            if (largest != i)
            {
                CheckInput(pausePos);
                if (_exitRequested) return;

                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                DrawArray(arr, activeIndex1: i, activeIndex2: largest);
                CustomSleep(delayMs, pausePos);
                if (_exitRequested) return;

                Heapify(arr, n, largest, delayMs, pausePos);
            }
        }

        static void CheckInput(int pausePos)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    _isPaused = true;
                    ShowPauseMenu(pausePos);
                }
            }
        }

        static void ShowPauseMenu(int pausePos)
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;

            Console.SetCursorPosition(0, pausePos);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" [PAUSED] Press 2 for continue | Press 0 for exit     ");
            Console.ResetColor();

            while (_isPaused)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    {
                        _isPaused = false;
                        Console.SetCursorPosition(0, pausePos);
                        Console.WriteLine(" Press [1] for pause (Resumed)...                  ");
                        Thread.Sleep(600);
                        Console.SetCursorPosition(0, pausePos);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(" Press [1] for pause...                            ");
                        Console.ResetColor();
                    }
                    else if (key == ConsoleKey.D0 || key == ConsoleKey.NumPad0)
                    {
                        _isPaused = false;
                        _exitRequested = true;
                        Console.CursorVisible = true;
                        return;
                    }
                }
                Thread.Sleep(50);
            }

            Console.SetCursorPosition(currentLeft, currentTop);
        }

        static void CustomSleep(int ms, int pausePos)
        {
            int elapsed = 0;
            while (elapsed < ms)
            {
                if (_exitRequested) return;
                CheckInput(pausePos);
                if (_isPaused) return;
                Thread.Sleep(20);
                elapsed += 20;
            }
        }

        static void DrawArray(int[] arr, int activeIndex1 = -1, int activeIndex2 = -1)
        {
            Console.SetCursorPosition(0, 5);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{i,2} | ");

                if (i == activeIndex1 || i == activeIndex2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }

                int value = Math.Max(0, arr[i]);
                string bar = new string('█', value);
                Console.WriteLine($"{bar,-20} ({arr[i]})");

                Console.ResetColor();
            }
        }

        static int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random rand = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(minValue, maxValue + 1);
            }
            return arr;
        }

        static void PrintComplexityInfo(int position)
        {
            Console.SetCursorPosition(0, position);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Complexity Metrics:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  - Best Case: O(n log n)");
            Console.WriteLine("  - Average Case: O(n log n)");
            Console.WriteLine("  - Worst Case: O(n log n)");
            Console.WriteLine("  - Space Complexity: O(1)");
            Console.WriteLine("  - Stable: No");
            Console.ResetColor();
        }
    }
}