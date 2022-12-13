// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace KnightProblem
{
    class Program {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter start position and end position seperated with a space");
            String? input = Console.ReadLine();

            if (input != null){
                String[] coords = input.Split(' ');
                
                //check if valid coordinates
                if (validCoord(coords[0]) && validCoord(coords[1])){
                    int[] startPos = convertToXY(coords[0]);
                    int[] endPos = convertToXY(coords[1]);

                    List<int[]> path = findShortestDistance(startPos, endPos);

                    //check if valid path and then print
                    if (path.Count != 0){
                        //remove starting position
                        path.RemoveAt(0);

                        Console.WriteLine("Possible path from {0} to {1}:", coords[0].ToUpper(), coords[1].ToUpper());
                        foreach (int[] pos in path) {
                            Console.Write(convertToChess(pos) + " ");
                        }
                    }
                    else
                        Console.WriteLine("No valid solutions");
                }
                else
                    Console.WriteLine("Wrong input");
            }
            else
                Console.WriteLine("Null input");

        }

        static int[] convertToXY(String position){
            int[] XY = new int[2];

            //subtract 1 from y to fit within 0-7
            //covert letter to number
            XY[0] = position.ToUpper()[0] - 'A';
            XY[1] = position[1] - '0' - 1;

            return XY;
        }

        static String convertToChess(int[] position){
            //add 1 to y coord to match chessboard notation
            //convert number to letter
            String coord = (char)(position[0]+'A') + (position[1]+1).ToString();

            return coord;
        }

        static bool validCoord(String position){
            //check for not null and length of 2 characters
            if(position == "" || position == null || position.Length != 2)
                return false;

            //convert to xy and check within chess board
            int[] XY = convertToXY(position);
            return withinBounds(XY[0], XY[1]);
        }
        static bool withinBounds(int x, int y){
            if(x >= 0 && x< 8 && y >= 0 && y < 8 ) {
                return true;
            }
            return false;
        }

        //breadth first search
        static List<int[]> findShortestDistance(int[] start, int[] end){
            //possible moves
            int[] moveX = {  2, 1, -1, -2, -2, -1,  1,  2 };
            int[] moveY = {  1, 2,  2,  1, -1, -2, -2, -1 };

            //possible paths
            Queue<List<int[]>> q = new Queue<List<int[]>>();
            
            //add start position to queue 
            q.Enqueue(new List<int[]>{start});

            //mark starting position as visited
            bool[,] visited = new bool[8,8];
            visited[start[0], start[1]] = true;

            while(q.Count != 0){
                List<int[]> currentPath = q.Dequeue();
                int[] currentPos = currentPath.Last();

                //if current position is equal to end position | solution found
                if(currentPos[0] == end[0] && currentPos[1] == end[1]){
                    return currentPath;
                }

                //possible moves
                for(int i =0; i < 8 ; i++){
                    int x,y;
                    x = currentPos[0] + moveX[i];
                    y = currentPos[1] + moveY[i];

                    //check within board and not already visited
                    if(withinBounds(x,y) && !visited[x,y]){
                        //add current path and position to queue and mark current position as visited
                        List<int[]> other = new List<int[]>();
                        other.AddRange(currentPath);
                        other.Add(new int[]{x,y});

                        visited[x,y] = true;
                        q.Enqueue(other);
                    }
                }
            }

            //no solutions, return empty list
            return new List<int[]>();
        }
    }
}