// See https://aka.ms/new-console-template for more information
using ConsoleSnakeGame;
using System.Runtime.InteropServices;


Start:
int FRAMEWIDTH = 14;
int FRAMEHEIGHT = 8;
int SPEED = 400;
int INITLENGTH = 1;
//Can only set Window Size in Windows
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    Console.SetWindowSize(FRAMEWIDTH, FRAMEHEIGHT + 4);
}

//Pull in the Game Board
Console.CursorVisible = false;
Console.Clear();
Display.SetFrame(FRAMEWIDTH, FRAMEHEIGHT);

//Write Display to Console
Console.SetCursorPosition(0, 0);

GlobalStatus.BoardHeight = Display.FrameHeight;
GlobalStatus.BoardWidth = Display.FrameWidth;

int initX = Display.FrameWidth / 2;
int initY = Display.FrameHeight / 2;
var snake = new Snake(initX, initY, SPEED, INITLENGTH);
GlobalStatus.Snake = snake;
//Set Game Speed
Thread.Sleep(snake.Speed);

GlobalStatus.CurrentFood = new Food();
//Start Thred to Read Keypress
Task.Factory.StartNew(() => Key.Press());

do 
{
    snake.Move(GlobalStatus.CurrentDirection);
    if (GlobalStatus.CurrentFood.IsEaten) 
    { 
        GlobalStatus.CurrentFood = new Food(); 
    }
    //Write Display to Console
    Console.SetCursorPosition(0, 0);
    Display.UpdateScreen(snake, GlobalStatus.CurrentFood);
    Console.Write(Display.DisplayFrame);

    Thread.Sleep(snake.Speed);
}
while(snake.IsAlive);
Console.Clear();
Display.GameOver(snake);
GlobalStatus.Reset();
goto Start;




