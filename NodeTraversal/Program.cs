// Jason Thai
// 7/11/18
// Empowr Skype Interview - Node Traversal

// Time to finish: 4-5 hours

// Difficulties: 1) Remembering how recursive functions work.
//               2) Remembering how to traverse nodes efficiently.
//               3) Making it flexible, so one can create their own nodes and paths.
//               4) Debugging/testing, researching.
//               5) Nested Lists (List of Lists)

// Steps: 1) Try to remember most from Skype interview.
//        2) Start from main, how do I want this to work.
//        3) Research intensively on recursive functions and nodes.
//        4) Figure out what Lists I need for what.
//        5) Implement simple functions, such as constructor, initialize, and adding.
//        6) Carefully think backwards on how recursive functions work.
//        7) Slowly implement recursive function, along with multiple debugging/testing.
//        8) After much research and testing, recursive function was done.
//        9) Make code flexible and user-friendly, so one may create their own nodes and paths.
//       10) Debugging/testing again, making sure everything works right.

// Note: I understand this was meant to be done in less than an hour,
//       and that this may have absolutely no impact on my Skype interview.
//       However, each interview that I do, I'd like to learn on what I can improve
//       so that maybe next time, I could do better.
//       Again, I'm very research-oriented, but I'm also very motivated.
//       This problem was definitely more difficult than the FindWords() problem.
//       Most likely I haven't done much node traversal before, but I can't say for sure.

using System;
using System.Collections;
using System.Collections.Generic;

namespace NodeTraversal
{
    class Program
    {
        // Create a class to hold all the nodes.
        public class Nodes
        {
            // Number of vertices(nodes).
            private int v = 0;

            // List to hold adjacent paths.
            private List<List<int>> adjList = new List<List<int>>();

            // Constructor.
            public Nodes(int vertices)
            {
                this.v = vertices;

                initAdjList();
            }

            // Initialize adjList.
            private void initAdjList()
            {
                for (int i = 0; i < v; i++)
                {
                    adjList.Add(new List<int>());
                }
            }

            // Add path from node to node, store into list.
            public void addTraversal(int a, int b)
            {
                adjList[a].Add(b);
            }

            // Function called from main, will start traversal.
            public void printPaths(int start, int destination)
            {
                // Keep track of which node has been visited.
                bool[] visited = new bool[v];

                // pathList will store the numbers to output.
                List<int> pathList = new List<int>();

                // Start traversal from start node.
                pathList.Add(start);

                // Begin traversal.
                traverse(start, destination, visited, pathList);
            }

            // Recursive function that will try to reach the destination from the start.
            private void traverse(int current, int destination, bool[] visited, List<int> currentPathList)
            {
                // Declare current node visited.
                visited[current] = true;

                // If current node is the destination.
                if(current.Equals(destination))
                {
                    // Print out the path(numbers) to get to destination.
                    Console.WriteLine();
                    currentPathList.ForEach(path => Console.Write(path + " "));
                }

                // Look at the possible paths from current node.
                foreach(int i in adjList[current])
                {
                    // Check if the next node (from path) hasn't been visited yet.
                    if(!visited[i])
                    {
                        // Store next node (from path) into list to be printed,
                        // that is, will be printed if destination is found through this path.
                        currentPathList.Add(i);

                        // Go to next node (through path) and do everything again,
                        // until the destination is found or reached a dead end.
                        traverse(i, destination, visited, currentPathList);

                        // Remove current path from list after full traversal is done.
                        // This is so next output won't duplicate previous output.
                        currentPathList.Remove(i);
                    }
                }

                // Set current node back to unvisited,
                // so that it can start another path search.
                visited[current] = false;
            }
        }

        public static void Main(string[] args)
        {
            // Lots of writing and outputs to create user-friendly interface.

            Console.WriteLine("Example:");
            Console.WriteLine("0 -> 1");
            Console.WriteLine("0 -> 2");
            Console.WriteLine("0 -> 3");
            Console.WriteLine("2 -> 0");
            Console.WriteLine("2 -> 1");
            Console.WriteLine("1 -> 3");

            Console.WriteLine();
            Console.WriteLine("Would you like to use example(1) or make your own(2)?");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            // user input: s = start, d = destination
            int s = 0;
            int d = 0;

            switch(input)
            {
                case 1:
                    Nodes n1 = new Nodes(4);
                    n1.addTraversal(0, 1);
                    n1.addTraversal(0, 2);
                    n1.addTraversal(0, 3);
                    n1.addTraversal(2, 0);
                    n1.addTraversal(2, 1);
                    n1.addTraversal(1, 3);

                    Console.WriteLine("What number would you like to start at?");
                    s = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("What number would you like to end?");
                    d = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Following are all different paths from " + s + " to " + d);
                    n1.printPaths(s, d);
                    Console.WriteLine();

                    break;

                case 2:
                    // Many concepts were borrowed from Nodes class.
                    // Mainly checking each input to be a certain value,
                    // so that it can be passed safely into functions.

                    Console.Clear();
                    int nodes = 0;

                    do
                    {
                        Console.WriteLine("How many nodes?");
                        nodes = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    } while (nodes <= 0);
                    Nodes n2 = new Nodes(nodes);

                    int start = 0;
                    int destination = 0;
                    List<List<int>> newList = new List<List<int>>();
                    for (int i = 0; i < nodes; i++)
                    {
                        newList.Add(new List<int>());
                    }
                    int count = 0;

                    while(true)
                    {
                        Console.Clear();
                        if(newList.Count > 0)
                        {
                            for (int i = 0; i < newList.Count; i++)
                            {
                                foreach(int j in newList[i])
                                {
                                    Console.WriteLine(i + " -> " + j);
                                }
                            }
                        }
                        Console.WriteLine();

                        Console.WriteLine("Please enter a number between 0 - " + (nodes - 1));
                        Console.WriteLine();
                        do
                        {
                            Console.WriteLine("Enter start node ...");
                            start = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        } while (start < 0 || start >= nodes);

                        do
                        {
                            Console.WriteLine("... that goes to?");
                            destination = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        } while (destination < 0 || destination >= nodes);
                        Console.WriteLine();

                        newList[start].Add(destination);
                        n2.addTraversal(start, destination);
                        count++;

                        Console.WriteLine("Would you like to add more? (y or n)");
                        string y_n = Console.ReadLine();

                        if (y_n == "n")
                        {
                            Console.Clear();
                            if (newList.Count > 0)
                            {
                                for (int i = 0; i < newList.Count; i++)
                                {
                                    foreach (int j in newList[i])
                                    {
                                        Console.WriteLine(i + " -> " + j);
                                    }
                                }
                            }
                            Console.WriteLine();
                            break;
                        }
                    }

                    Console.WriteLine("What number would you like to start at?");
                    s = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("What number would you like to end?");
                    d = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Following are all different paths from " + s + " to " + d);
                    n2.printPaths(s, d);
                    Console.WriteLine();

                    break;
            }
        }
    }
}
