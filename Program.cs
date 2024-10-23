// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        int maxFloor = 5;
        int minFloor = 0;
        int currentFloor = minFloor;
        string direction = "up";

        bool[] upQueue = {
            false, false, false, false, false, false
        };

        while(true) {
            int floor;
			Console.WriteLine("Which floor?");
			floor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(floor);
            if (floor > currentFloor) {
                direction = "up";
            }
            else if (floor < currentFloor) {
                direction = "down";
            }

            while (direction == "up") {
	            currentFloor++;
	            if (upQueue[currentFloor] == true) {
                    Console.WriteLine("The elevator stops at floor" + currentFloor);
	                upQueue[Array.IndexOf(upQueue, currentFloor)] = false;
                }
                if (currentFloor == maxFloor) {
                    direction = "down";
                }
            }
        }
    }
}