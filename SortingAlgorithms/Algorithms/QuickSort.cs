using System.Text;

namespace SortingAlgorithms.Algorithms
{
    internal class QuickSort
    {
        private static bool _isPaused = false;
        private static bool _exitRequested = false;

        public static void LaunchQuickSort()
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
            Console.WriteLine("        [ SYSTEM ]: QUICK SORT VISUALIZER         ");
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

            QuickSortWithVisualization(array, 0, array.Length - 1, delayMs: 150, pausePromptPosition);

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

        static void QuickSortWithVisualization(int[] arr, int low, int high, int delayMs, int pausePos)
        {
            if (low < high && !_exitRequested)
            {
                int pi = Partition(arr, low, high, delayMs, pausePos);
                if (_exitRequested) return;

                QuickSortWithVisualization(arr, low, pi - 1, delayMs, pausePos);
                if (_exitRequested) return;

                QuickSortWithVisualization(arr, pi + 1, high, delayMs, pausePos);
            }
        }

        static int Partition(int[] arr, int low, int high, int delayMs, int pausePos)
        {
            int pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                CheckInput(pausePos);
                if (_exitRequested) return i;

                DrawArray(arr, pivotIndex: high, currentIndex: j, comparingIndex: i + 1);
                CustomSleep(delayMs, pausePos);
                if (_exitRequested) return i;

                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    DrawArray(arr, pivotIndex: high, currentIndex: j, comparingIndex: i);
                    CustomSleep(delayMs, pausePos);
                    if (_exitRequested) return i;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            DrawArray(arr, pivotIndex: i + 1);
            CustomSleep(delayMs, pausePos);

            return i + 1;
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

        static void DrawArray(int[] arr, int pivotIndex = -1, int currentIndex = -1, int comparingIndex = -1)
        {
            Console.SetCursorPosition(0, 5);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{i,2} | ");

                if (i == pivotIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (i == currentIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (i == comparingIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
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
            Console.WriteLine("  - Worst Case: O(n²)");
            Console.WriteLine("  - Space Complexity: O(log n)");
            Console.WriteLine("  - Stable: No");
            Console.ResetColor();
        }
    }
}