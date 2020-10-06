using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaInterviewCase
{
    public class Program
    {
        #region İnitialize
        //initialize matrix
        public static int matrixXAxis = 0;
        public static int matrixYAxis = 0;

        //This dictionary determines which direction we turn when turning left or right for each direction.
        static Dictionary<Sides, Sides[]> sidesMovemets = new Dictionary<Sides, Sides[]>()
            {
                {Sides.E, new Sides[]{Sides.N,Sides.S } },
                {Sides.N, new Sides[]{Sides.W,Sides.E } },
                {Sides.W, new Sides[]{Sides.S,Sides.N } },
                {Sides.S, new Sides[]{Sides.E,Sides.W } }
            };
        #endregion


        public static void Main(string[] args)
        {
            List<RoverPosition> roverPositions = new List<RoverPosition>();
            List<char[]> roverMovemets = new List<char[]>();

            #region User Input and Cotrols

            bool process = true;

            while (process) 
            {
                try 
                {
                    Console.WriteLine("Please enter the matrix  size : ");
                    string matrixSizeString = Console.ReadLine();
                    matrixXAxis = Convert.ToInt32(matrixSizeString.Split(' ')[0]);
                    matrixYAxis = Convert.ToInt32(matrixSizeString.Split(' ')[1]);
                    process = false;
                }
                catch 
                {
                    Console.WriteLine("You entered wrong value!");
                }
            }

            process = true;

            while (process)
            {
                try
                {
                    Console.WriteLine("Please enter the first rover position : ");
                    string firstRoverPosition = Console.ReadLine();

                    RoverPosition roverPositionFirst = new RoverPosition();
                    roverPositionFirst.xAxis = Convert.ToInt32(firstRoverPosition.Split(' ')[0]);
                    roverPositionFirst.yAxis = Convert.ToInt32(firstRoverPosition.Split(' ')[1]);
                    roverPositionFirst.facingSide = (Sides)Enum.Parse(typeof(Sides), firstRoverPosition.Split(' ')[2], true);

                    roverPositions.Add(roverPositionFirst);
                    process = false;
                }
                catch
                {
                    Console.WriteLine("You entered wrong value!");
                }
            }

            process = true;

            while (process)
            {
                try
                {
                    Console.WriteLine("Please enter the first rover movements : ");
                    string firstRoverMovements = Console.ReadLine();
                    char[] firstRoverMovementsArray = firstRoverMovements.ToCharArray();

                    foreach(char item in firstRoverMovementsArray) 
                    {
                        if(item != 'M' && item != 'R' && item != 'L') 
                        {
                            throw new Exception();
                        }
                    }

                    roverMovemets.Add(firstRoverMovementsArray);
                    process = false;
                }
                catch
                {
                    Console.WriteLine("You entered wrong value!");
                }
            }

            process = true;

            while (process)
            {
                try
                {
                    Console.WriteLine("Please enter the second rover position : ");
                    string secondRoverPosition = Console.ReadLine();

                    RoverPosition roverPositionSecond = new RoverPosition();
                    roverPositionSecond.xAxis = Convert.ToInt32(secondRoverPosition.Split(' ')[0]);
                    roverPositionSecond.yAxis = Convert.ToInt32(secondRoverPosition.Split(' ')[1]);
                    roverPositionSecond.facingSide = (Sides)Enum.Parse(typeof(Sides), secondRoverPosition.Split(' ')[2], true);

                    roverPositions.Add(roverPositionSecond);
                    process = false;
                }
                catch
                {
                    Console.WriteLine("You entered wrong value!");
                }
            }

            process = true;

            while (process)
            {
                try
                {
                    Console.WriteLine("Please enter the second rover movements : ");
                    string secondRoverMovements = Console.ReadLine();
                    char[] secondRoverMovementsArray = secondRoverMovements.ToCharArray();

                    foreach (char item in secondRoverMovementsArray)
                    {
                        if (item != 'M' && item != 'R' && item != 'L')
                        {
                            throw new Exception();
                        }
                    }

                    roverMovemets.Add(secondRoverMovementsArray);
                    process = false;
                }
                catch
                {
                    Console.WriteLine("You entered wrong value!");
                }
            }


            #endregion



            for (int i = 0; i < 2; i++) 
            {
                string result = RoverMovementResult(roverPositions[i], roverMovemets[i]);

                Console.WriteLine(result);
            }

        }

        public static string RoverMovementResult(RoverPosition roverPositions, char[] roverMovemets) 
        {
            foreach(char item in roverMovemets) 
            {
                switch ((char)item) 
                {
                    case 'L':
                        roverPositions.facingSide = sidesMovemets[(Sides)roverPositions.facingSide][0];
                        break;
                    case 'R':
                        roverPositions.facingSide = sidesMovemets[(Sides)roverPositions.facingSide][1];
                        break;
                    case 'M':
                        switch (roverPositions.facingSide) 
                        {
                            case Sides.E:
                                if(roverPositions.xAxis+1 > matrixXAxis) 
                                {
                                    throw new Exception("Out of the area!");
                                }
                                else 
                                {
                                    roverPositions.xAxis++;
                                }
                                break;
                            case Sides.N:
                                if (roverPositions.yAxis + 1 > matrixYAxis)
                                {
                                    throw new Exception("Out of the area!");
                                }
                                else
                                {
                                    roverPositions.yAxis++;
                                }
                                break;
                            case Sides.S:
                                if (roverPositions.yAxis - 1 < 0)
                                {
                                    throw new Exception("Out of the area!");
                                }
                                else
                                {
                                    roverPositions.yAxis--;
                                }
                                break;
                            case Sides.W:
                                if (roverPositions.xAxis - 1 < 0)
                                {
                                    throw new Exception("Out of the area!");
                                }
                                else
                                {
                                    roverPositions.xAxis--;
                                }
                                break;
                        }
                        break;
                }
            }

            return roverPositions.xAxis.ToString() + " " + roverPositions.yAxis.ToString() + " " + roverPositions.facingSide.ToString();
        }
    }

    public class RoverPosition
    {
        public int xAxis { get; set; }
        public int yAxis { get; set; }
        public Sides facingSide { get; set; }
    }

    public enum Sides
    {
        N,
        E,
        S,
        W
    }

}
