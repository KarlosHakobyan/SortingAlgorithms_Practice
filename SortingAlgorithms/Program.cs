using SortingAlgorithms.Algorithms;
using System.Text;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "Sorting Algorithms Visualizer";

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==================================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("       [ SYSTEM ]: SORTING ALGORITHMS VISUALIZER  ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==================================================");
            Console.ResetColor();

            Console.WriteLine(" Select an algorithm to execute:\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   [1] -> Bubble Sort");
            Console.WriteLine("   [2] -> Selection Sort");
            Console.WriteLine("   [3] -> Insertion Sort");
            Console.WriteLine("   [4] -> Quick Sort");
            Console.WriteLine("   [5] -> Merge Sort");
            Console.WriteLine("   [6] -> Heap Sort");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("   [0] -> Exit System");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n==================================================");
            Console.ResetColor();

            Console.Write(" Enter your choice [0-6]: ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n [ERROR]: Invalid input format! Please enter a number.");
                Console.ResetColor();
                Thread.Sleep(1500);
                continue;
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                    BubbleSort.LaunchBubbleSort();
                    break;
                case 2:
                    SelectionSort.LaunchSelectionSort();
                    break;
                case 3:
                    InsertionSort.LaunchInsertionSort();
                    break;
                case 4:
                    QuickSort.LaunchQuickSort();
                    break;
                case 5:
                    MergeSort.LaunchMergeSort();
                    break;
                case 6:
                    HeapSort.LaunchHeapSort();
                    break;
                case 0:
                    exit = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" [SYSTEM]: Shutting down. Goodbye!");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [ERROR]: Choice out of range! Select between 0 and 6.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    break;
            }

            if (!exit && choice >= 1 && choice <= 6)
            {
                Console.WriteLine("\nPress any key to return to the system menu...");
                Console.ReadKey(true);
            }
        }
    }
}