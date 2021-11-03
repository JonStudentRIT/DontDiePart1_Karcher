using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//A,B,D,F,G,H = 2,3,4,1,2 = 12
namespace DontDiePart1
{
    /* Class: _
     * Author: Jonathan Karcher
     * Purpose: Used for readability assistance
     */
    public static class _
    {
        public static int A = 0;
        public static int B = 1;
        public static int C = 2;
        public static int D = 3;
        public static int E = 4;
        public static int F = 5;
        public static int G = 6;
        public static int H = 7;
    }
    /* Class: Direction
     * Author: Jonathan Karcher
     * Purpose: Contain the specific data related to traveling in one direction
     */
    class Direction
    {
        // the room that can be traveled to
        private int destination;
        // the cost of traveling to the destination
        private int weight;
        /* Constructor: Direction
         * Purpose: Set the initial directional data
         * Restrictions: None
         */
        public Direction(int destination, int weight)
        {
            this.destination = destination;
            this.weight = weight;
        }
        /* Property: Destination
         * purpose: Return the value of destination
         * Restrictions: Read only
         */
        public int Destination { get { return destination; } }
        /* Property: Weight
         * purpose: Return the value of weight
         * Restrictions: Read only
         */
        public int Weight { get { return weight; } }
    }
    /* Class: Room
     * Author: Jonathan Karcher
     * Purpose: Manages the 4 potential directions that the player can travel
     */
    class Room
    {
        // the four cardinal directions
        private Direction north;
        private Direction south;
        private Direction east;
        private Direction west;
        /* Constructor: Room
         * Purpose: Set the initial Room data
         * Restrictions: None
         */
        public Room(Direction north, Direction south, Direction east, Direction west)
        {
            this.north = north;
            this.south = south;
            this.east = east;
            this.west = west;
        }
        /* Property: North
         * purpose: Return the value of north
         * Restrictions: Read only
         */
        public Direction North { get { return north; } }
        /* Property: South
         * purpose: Return the value of south
         * Restrictions: Read only
         */
        public Direction South { get { return south; } }
        /* Property: East
         * purpose: Return the value of east
         * Restrictions: Read only
         */
        public Direction East { get { return east; } }
        /* Property: West
         * purpose: Return the value of west
         * Restrictions: Read only
         */
        public Direction West { get { return west; } }
    }
    /* Class: Program
     * Author: Jonathan Karcher
     * Purpose: Main entery point for the program
     */
    class Program
    {
        /* Method: Main
         * Purpose: Main entery point for the program
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // Dont Die data in matrix form
            //          [destination]
            // [origin] "direction", weight
            (string, int)[,] adjacencyMatrix =
            /*  *//*  A*//*       B*//*     C*//*       D*//*       E*//*       F*//*       G*//*        H*/
            /*A*/{ {("NE", 0),  ("S", 2),  (null,-1),  (null,-1),  (null,-1),  (null,-1),  (null,-1),  (null,-1) },
            /*B  */{(null,-1),  (null,-1),  ("S", 2),  ("E", 3),  (null,-1),  (null,-1),  (null,-1),  (null,-1) },
            /*C  */{(null,-1),  ("N", 2),  (null,-1),  (null,-1),  (null,-1),  (null,-1),  (null,-1),  ("S",20) },
            /*D  */{(null,-1),  ("W", 3),  ("S", 5),  (null,-1),  ("N", 2),  ("E", 4),  (null,-1),  (null,-1) },
            /*E  */{(null,-1),  (null,-1),  (null,-1),  (null,-1),  (null,-1),  ("S", 3),  (null,-1),  (null,-1) },
            /*F  */{(null,-1),  (null,-1),  (null,-1),  (null,-1),  (null,-1),  (null,-1),  ("", 1),  (null,-1) },
            /*G  */{(null,-1),  (null,-1),  (null,-1),  (null,-1),  ("N", 0),  (null,-1),  (null,-1),  ("S", 2) },
            /*H  */{(null,-1),  (null,-1),  (null,-1),  (null,-1), (null,-1),  (null,-1),  (null,-1),  (null,-1) } };

            // Dont Die data in list form
            // [origin] destination, "direction", weight
            (int, string, int)[][] adjacencyList = new (int, string, int)[8][];
            adjacencyList[_.A] = new (int, string, int)[] { (_.A, "N", 0), (_.A, "E", 0), (_.B, "S", 2) };
            adjacencyList[_.B] = new (int, string, int)[] { (_.C, "S", 2), (_.D, "E", 3) };
            adjacencyList[_.C] = new (int, string, int)[] { (_.B, "N", 2), (_.H, "S", 20) };
            adjacencyList[_.D] = new (int, string, int)[] { (_.B, "W", 3), (_.C, "S", 5), (_.E, "N", 2), (_.F, "E", 4) };
            adjacencyList[_.E] = new (int, string, int)[] { (_.F, "S", 3) };
            adjacencyList[_.F] = new (int, string, int)[] { (_.G, "E", 1) };
            adjacencyList[_.G] = new (int, string, int)[] { (_.E, "N", 0), (_.H, "S", 2) };
            adjacencyList[_.H] = new (int, string, int)[] { };

            // Dont Die data using a dedicated class 
            // [origin] (direction(destination,weight))(...)(...)(...)
            Room[] rooms = new Room[8];
            rooms[_.A] = new Room(new Direction(_.A, 0), new Direction(_.B, 2), new Direction(_.A, 0), null);
            rooms[_.B] = new Room(null, new Direction(_.C, 2), new Direction(_.D, 3), null);
            rooms[_.C] = new Room(new Direction(_.B, 2), new Direction(_.H, 20), null, null);
            rooms[_.D] = new Room(new Direction(_.E, 2), new Direction(_.C, 5), new Direction(_.F, 4), new Direction(_.B, 3));
            rooms[_.E] = new Room(null, new Direction(_.F, 3), null, null);
            rooms[_.F] = new Room(null, null, new Direction(_.G, 1), null);
            rooms[_.G] = new Room(new Direction(_.E, 0), new Direction(_.H, 2), null, null);
            rooms[_.H] = new Room(null, null, null, null);
        }
    }
}
