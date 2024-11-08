﻿using System;
using System.Linq;
using System.Threading;


public class Elevator {
    public static void Main(string[] arg) {
        int maxFloor = 5;
        int minFloor = 0;
        Random rnd = new Random();
        int currentFloor = rnd.Next(minFloor, maxFloor);
        string direction = "";

        bool[] upQueue = {
            false, false, false, false, false, false
        };
        bool[] downQueue = {
            false, false, false, false, false, false
        };

        int floorsDistance = 0;

        while(true) {
            int floor = rnd.Next(minFloor, maxFloor);
            Console.WriteLine("YOU is at: " + floor);
            Console.WriteLine("HISS is at: " + currentFloor);
			Console.WriteLine("Up or Down?");
            string desiredDirection = Console.ReadLine();
            
            if(direction == "") {
                if (floor > currentFloor)
                {
                    upQueue[floor] = true;
                    direction = "up";
                }
                else if (floor < currentFloor)
                {
                    downQueue[floor] = true;
                    direction = "down";
                }
            }
            else {
                if(desiredDirection=="up"){
                    upQueue[floor] = true;
                }
                else {
                    downQueue[floor] = true;
                }
            }

            if(desiredDirection=="up") {
                upQueue[floor] = true;
            }

            floorsDistance = floor-currentFloor;
            if(direction == "down") {
                floorsDistance*=-1;
            }
           
            Move();

            Console.WriteLine("You entered the HISS");
            Console.WriteLine("Which floor do you want to up?");

            floor = Convert.ToInt32(Console.ReadLine());

            if (floor > currentFloor) {
                upQueue[floor] = true;
                direction = "up";
            }
            else if (floor < currentFloor) {
                downQueue[floor] = true;
                direction = "down";
            }

            floorsDistance = floor-currentFloor;

            if(direction == "down") {
                floorsDistance*=-1;
            }
            
            Move();

            Console.WriteLine("You exited the HISS");
            Console.WriteLine("Starting over");
        }

        void Move() {
            for (int i = 0; i < floorsDistance; i++)
            {
                Thread.Sleep(1000);
                if (direction == "up")
                {
	                currentFloor++;
                    Console.WriteLine("Is at floor " + currentFloor);
	                if (upQueue[currentFloor] == true) {
                        Console.WriteLine("The elevator stops at floor: " + currentFloor);
	                    upQueue[currentFloor] = false;
                    }   
                    if (currentFloor == maxFloor) {
                        direction = "down";
                    }
                }
                else
                {  
	                currentFloor--;
                    Console.WriteLine("Is at floor " + currentFloor);
	                if (downQueue[currentFloor] == true) {
                        Console.WriteLine("The elevator stops at floor" + currentFloor);
	                    downQueue[currentFloor] = false;
                    }   
                    if (currentFloor == minFloor) {
                        direction = "up";
                    }
                }
            }
        }
    }   
}