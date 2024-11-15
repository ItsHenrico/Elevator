﻿using System;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading;

public class Elevator{
    public static void Main(string[] arg){
        int maxFloor = 5;
        int minFloor = 0;
        Random rnd = new Random();
        int currentFloor = 1;
        string direction = "down";
        // string desiredDirection = "";
        int floor = rnd.Next(minFloor, maxFloor);
        int currentMaxFloor = maxFloor;
        int currentMinFloor = minFloor;

        bool[] upQueue = {
            false, false, false, false, false, false
        };
        bool[] downQueue = {
            false, false, false, false, false, false
        };

        int floorsDistance = 0;

        while (true){
            // Console.WriteLine("YOU is at: " + floor);
            // Console.WriteLine("HISS is at: " + currentFloor);
            // Console.WriteLine("Up or Down?");
            // string desiredDirection = Console.ReadLine();

            // if(direction == "") {
            //     if (floor > currentFloor){
            //         upQueue[floor] = true;
            //         direction = "up";
            //     }
            //     else if (floor < currentFloor){
            //         downQueue[floor] = true;
            //         direction = "down";
            //     }
            // }
            // else {
            //     if(desiredDirection=="up"){
            //         upQueue[floor] = true;
            //     }
            //     else {
            //         downQueue[floor] = true;
            //     }
            // }

            // if(desiredDirection=="up") {
            //     upQueue[floor] = true;
            // }

            // floorsDistance = floor-currentFloor;
            // if(direction == "down") {
            //     floorsDistance*=-1;
            // }

            //Move();

            // Console.WriteLine("You entered the HISS");
            // Console.WriteLine("Which floor do you want to up?");

            //floor = Convert.ToInt32(Console.ReadLine());

            // if (floor > currentFloor) {
            //     upQueue[floor] = true;
            //     direction = "up";
            // }
            // else if (floor < currentFloor) {
            //     downQueue[floor] = true;
            //     direction = "down";
            // }

            if (upQueue[minFloor] == true){
                downQueue[minFloor] = true;
                upQueue[minFloor] = false;
            }

            if (downQueue[maxFloor] == true){
                upQueue[maxFloor] = true;
                downQueue[maxFloor] = false;
            }

            floorsDistance = Math.Abs(floor - currentFloor);

            Move();

            // Console.WriteLine("You exited the HISS");
            // Console.WriteLine("Starting over");
        }

        void Move(){
            while (upQueue.Contains(true) || downQueue.Contains(true)){
                for (int i = 0; i < floorsDistance; i++){
                    Thread.Sleep(1000);
                    
                    if (direction == "up"){
                        if(currentFloor >= currentMaxFloor){
                            direction = "down";
                            break;
                        }
                        currentFloor++;
                        for(int g = maxFloor; g > minFloor; g--){
                            if (upQueue[currentFloor] == true){ 
                                currentMaxFloor = g;
                                break;
                            }
                        }
                        if (upQueue[currentFloor] == true){
                            Console.WriteLine("The elevator stops at floor: " + currentFloor);
                            upQueue[currentFloor] = false;
                        }
                    
                        Console.WriteLine("Is at floor " + currentFloor);
                    }
                    if (direction == "down"){
                        if(currentFloor <= currentMinFloor){
                            direction = "up";
                            break;
                        }
                        currentFloor--;
                        for(int g = minFloor; g < maxFloor; g++){
                            if (downQueue[currentFloor] == true){ 
                                currentMinFloor = g;
                                break;
                            }
                        }
                        if (downQueue[currentFloor] == true){
                            Console.WriteLine("The elevator stops at floor" + currentFloor);
                            downQueue[currentFloor] = false;
                        }  
                        
                        Console.WriteLine("Is at floor " + currentFloor);
                    }
                }
                /*
                for(int i = 0; i < upQueue.Length; i++)
                {
                    Console.WriteLine("upQueue index of "+ i + " " + "is " + upQueue[i]);
                }
                for(int i = 0; i < downQueue.Length; i++)
                {
                    Console.WriteLine("downQueue index of "+ i + " " + "is " + downQueue[i]);
                }
                */
            }
        }
    }
}