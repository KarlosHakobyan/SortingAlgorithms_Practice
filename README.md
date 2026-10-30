# Sorting Algorithms – C# Console Visualizer

A C# console application that demonstrates and visualizes six popular sorting algorithms. Each algorithm sorts a randomly generated array and displays the sorting process step by step directly in the console.

## Technologies

- C#
- .NET
- Console Application
- Algorithms and Data Structures

## Project Structure

```text
SortingAlgorithms/
│
├── Algorithms/
│   ├── BubbleSort.cs
│   ├── SelectionSort.cs
│   ├── InsertionSort.cs
│   ├── MergeSort.cs
│   ├── QuickSort.cs
│   └── HeapSort.cs
│
├── Program.cs
└── SortingAlgorithms.csproj
```

## Implemented Algorithms

### 1. Bubble Sort

Repeatedly compares adjacent elements and swaps them if they are in the wrong order.

- Time Complexity:
  - Best: O(n)
  - Average: O(n²)
  - Worst: O(n²)
- Space Complexity: O(1)
- Stable: Yes

### 2. Selection Sort

Finds the minimum element in the unsorted portion and places it at the beginning.

- Time Complexity:
  - Best: O(n²)
  - Average: O(n²)
  - Worst: O(n²)
- Space Complexity: O(1)
- Stable: No

### 3. Insertion Sort

Builds the sorted portion of the array by inserting each element into its correct position.

- Time Complexity:
  - Best: O(n)
  - Average: O(n²)
  - Worst: O(n²)
- Space Complexity: O(1)
- Stable: Yes

### 4. Merge Sort

Uses the Divide and Conquer approach. Splits the array into smaller parts, sorts them recursively, and merges the results.

- Time Complexity:
  - Best: O(n log n)
  - Average: O(n log n)
  - Worst: O(n log n)
- Space Complexity: O(n)
- Stable: Yes

### 5. Quick Sort

Selects a pivot element, partitions the array around it, and recursively sorts the resulting partitions.

- Time Complexity:
  - Best: O(n log n)
  - Average: O(n log n)
  - Worst: O(n²)
- Space Complexity: O(log n) average recursion stack
- Stable: No

### 6. Heap Sort

Uses a Binary Heap data structure to repeatedly extract the largest element and place it at the end of the array.

- Time Complexity:
  - Best: O(n log n)
  - Average: O(n log n)
  - Worst: O(n log n)
- Space Complexity: O(1)
- Stable: No

## Visualization Features

Each sorting algorithm includes console-based visualization.

- Random array generation.
- Visual representation of array elements using block characters (`█`).
- Different console colors to highlight active elements.
- Step-by-step sorting animation.
- Configurable animation delay.
- Final sorted array display.

### Visualization Colors

Colors are used to identify the current state of elements during sorting.

The meaning of colors depends on the selected algorithm:

- Yellow – current or active element.
- Red – pivot or swapping elements.
- Green – comparison or selected element.
- Cyan / Blue / White – other elements.
- Dark Gray – already sorted elements.

## How to Run

### Requirements

- .NET SDK
- Visual Studio, JetBrains Rider, or Visual Studio Code (optional)

### Clone Repository

```bash
git clone https://github.com/YOUR_USERNAME/SortingAlgorithms.git
```

### Navigate to Project

```bash
cd SortingAlgorithms
```

### Run Application

```bash
dotnet run
```

## Learning Objectives

This project was created for practicing algorithms and data structures in C#.

- Understand different sorting algorithms.
- Learn algorithm time and space complexity.
- Practice recursion.
- Understand Divide and Conquer.
- Work with arrays and loops.
- Practice element swapping and comparisons.
- Visualize algorithm execution.
- Understand the differences between sorting approaches.

## Author

**Karlos Hakobyan**

C# | Software Engineering
