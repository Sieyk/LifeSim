using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LifeSim
{
    class Program
    {
        static void Main(string[] args)
        {
            int popAge = 0;
            Creature[,] GameBoard = new Creature[25, 80];
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 80; x++)
                {
                    GameBoard[y, x] = new Creature(1);
                }
            }
            for (; ; )
            {
                GameBoard[13, 39] = new Creature(true);
                GameBoard[13, 40] = new Creature(true);
                GameBoard[12, 40] = new Creature(true);
                GameBoard[12, 41] = new Creature(true);
                popAge = 0;

                for (; ; popAge++) //Main loop
                {
                    printBoard(GameBoard);
                    Boolean check = false;
                    if (popAge > 30)
                    System.Threading.Thread.Sleep(200);
                    Random rndum = new Random();
                    int rayndum = rndum.Next(1, 9);

                    int y = 0;
                    int x = 0;
                    for (; y < 25; y++)
                    {
                        for (; x < 80; x++)
                        {
                            GameBoard[y, x].setBaby(false);
                            if (GameBoard[y, x].toChar() == '@')
                                check = true;
                        }
                        x = 0;
                    }

                    if (!check)
                    {
                        //System.Threading.Thread.Sleep(1000);
                        break;
                    }

                    if (rayndum == 1)
                    {
                        y = 0;
                        x = 0;
                        for (; y < 25; y++)
                        {
                            for (; x < 80; x++)
                            {
                                int eks = x;
                                int why = y;
                                if (!GameBoard[y, x].isEmpty())
                                    babyMatch(GameBoard, why, eks);
                            }
                            x = 0;
                        }
                    }
                    else if (rayndum == 2)
                    {
                        y = 24;
                        x = 79;
                        for (; y >= 0; y--)
                        {
                            for (; x >= 0; x--)
                            {
                                int eks = x;
                                int why = y;
                                if (!GameBoard[y, x].isEmpty())
                                    babyMatch(GameBoard, why, eks);
                            }
                            x = 79;
                        }
                    }
                    else if (rayndum == 3)
                    {
                        y = 0;
                        x = 79;
                        for (; y < 25; y++)
                        {
                            for (; x >= 0; x--)
                            {
                                int eks = x;
                                int why = y;
                                if (!GameBoard[y, x].isEmpty())
                                    babyMatch(GameBoard, why, eks);
                            }
                            x = 79;
                        }
                    }
                    else if (rayndum == 4)
                    {
                        y = 24;
                        x = 0;
                        for (; y >= 0; y--)
                        {
                            for (; x < 80; x++)
                            {
                                int eks = x;
                                int why = y;
                                if (!GameBoard[y, x].isEmpty())
                                    babyMatch(GameBoard, why, eks);
                            }
                            x = 0;
                        }
                    }
                    else if (rayndum == 5)
                    {
                        y = 24;
                        x = 0;
                        for (; x < 80; x++)
                        {
                            for (; y >= 0; y--)
                            {
                                int eks = x;
                                int why = y;
                                if (!GameBoard[y, x].isEmpty())
                                    babyMatch(GameBoard, why, eks);
                            }
                            y = 24;
                        }
                    }
                    else if (rayndum == 6)
                    {
                        y = 0;
                        x = 79;
                        for (; x >= 0; x--)
                        {
                            for (; y < 25; y++)
                            {
                                int eks = x;
                                int why = y;
                                if (!GameBoard[y, x].isEmpty())
                                    babyMatch(GameBoard, why, eks);
                            }
                            y = 0;
                        }
                    }
                    else if (rayndum == 7)
                    {
                        y = 24;
                        x = 79;
                        for (; x >= 0; x--)
                        {
                            for (; y >= 0; y--)
                            {
                                int eks = x;
                                int why = y;
                                if (!GameBoard[y, x].isEmpty())
                                    babyMatch(GameBoard, why, eks);
                            }
                            y = 24;
                        }
                    }
                    if (rayndum == 8)
                    {
                        y = 0;
                        x = 0;
                        for (; x < 80; x++)
                        {
                            for (; y < 25; y++)
                            {
                                int eks = x;
                                int why = y;
                                if (!GameBoard[y, x].isEmpty())
                                    babyMatch(GameBoard, why, eks);
                            }
                            y = 0;
                        }
                    }
                    babyMake(GameBoard);
                    checkDeaths(GameBoard);
                }
            }
        }

        public static void printBoard(Creature[,] board)
        {
            String output = "";
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 80; x++)
                {
                    output += board[y, x].toChar();
                }
            }
            Console.Clear();
            Console.Out.Write(output);
        }

        public static void babyMatch(Creature[,] board, int y, int x)
        {
            Random rnd = new Random();
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] box = new byte[1];
            provider.GetBytes(box);
            int random = rnd.Next(1, 9);
            const int BABYCHANCE = 9;
            bool babyCheck = false;
            int[] order = new int[8];
            for (int i = 0; i < 8; i++)
                order[i] = i + 1;
            int shuffle = order.Length;
            while (shuffle > 1)
            {
                shuffle--;
                int k = rnd.Next(shuffle + 1);
                int temp = order[k];
                order[k] = order[shuffle];
                order[shuffle] = temp;
            }
            for (int i = 0; i < 8; i++, provider.GetBytes(box))
            {
                if (order[i] == 1)
                {
                    if (y > 0)
                    {
                        if (!board[y - 1, x].isEmpty())
                        {
                            if (!board[y - 1, x].isBaby())
                            {
                                if (box[0] % 11 >= BABYCHANCE)
                                    board[y, x].setBaby(true);
                                babyCheck = true;
                            }
                        }
                    }
                }
                else if (order[i] == 2)
                {
                    if (x > 0)
                    {
                        if (!board[y, x - 1].isEmpty())
                        {
                            if (!board[y, x - 1].isBaby())
                            {
                                if (box[0] % 11 >= BABYCHANCE)
                                    board[y, x].setBaby(true);
                                babyCheck = true;
                            }
                        }
                    }
                }
                else if (order[i] == 3)
                {
                    if (x < 79)
                    {
                        if (!board[y, x + 1].isEmpty())
                        {
                            if (!board[y, x + 1].isBaby())
                            {
                                if (box[0] % 11 >= BABYCHANCE)
                                    board[y, x].setBaby(true);
                                babyCheck = true;
                            }
                        }
                    }
                }
                else if (order[i] == 4)
                {
                    if (y < 24)
                    {
                        if (!board[y + 1, x].isEmpty())
                        {
                            if (!board[y + 1, x].isBaby())
                            {
                                if (box[0] % 11 >= BABYCHANCE)
                                    board[y, x].setBaby(true);
                                babyCheck = true;
                            }
                        }
                    }
                }
                else if (order[i] == 5)
                {
                    if (x > 0 && y > 0)
                    {
                        if (!board[y - 1, x - 1].isEmpty())
                        {
                            if (!board[y - 1, x - 1].isBaby())
                            {
                                if (box[0] % 11 >= BABYCHANCE)
                                    board[y, x].setBaby(true);
                                babyCheck = true;
                            }
                        }
                    }
                }
                else if (order[i] == 6)
                {
                    if (x > 0 && y < 24)
                    {
                        if (!board[y + 1, x - 1].isEmpty())
                        {
                            if (!board[y + 1, x - 1].isBaby())
                            {
                                if (box[0] % 11 >= BABYCHANCE)
                                    board[y, x].setBaby(true);
                                babyCheck = true;
                            }
                        }
                    }
                }
                else if (order[i] == 7)
                {
                    if (x < 79 && y > 0)
                    {
                        if (!board[y - 1, x + 1].isEmpty())
                        {
                            if (!board[y - 1, x + 1].isBaby())
                            {
                                if (box[0] % 11 >= BABYCHANCE)
                                    board[y, x].setBaby(true);
                                babyCheck = true;
                            }
                        }
                    }
                }
                else if (order[i] == 8)
                {
                    if (x < 79 && y < 24)
                    {
                        if (!board[y + 1, x + 1].isEmpty())
                        {
                            if (!board[y + 1, x + 1].isBaby())
                            {
                                if (box[0] % 11 >= BABYCHANCE)
                                    board[y, x].setBaby(true);
                                babyCheck = true;
                            }
                        }
                    }
                }
            }
            


            board[y, x].incAge();
        }

        public static void babyMake(Creature[,] board)
        {
            Random rnd = new Random();
 
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 80; x++)
                {
                    if (board[y, x].isBaby())
                    {
                        int random; //Randomises the priority in which direction a baby is made
                        List<Creature> tempList = new List<Creature>();
                        if (x > 0)
                            if (board[y, x - 1].isEmpty())
                                tempList.Add(board[y, x - 1]);
                        if (y > 0)
                            if (board[y - 1, x].isEmpty())
                                tempList.Add(board[y - 1, x]);
                        if (x < 79)
                            if (board[y, x + 1].isEmpty())
                                tempList.Add(board[y, x + 1]);
                        if (y < 24)
                            if (board[y + 1, x].isEmpty())
                                tempList.Add(board[y + 1, x]);
                        if (x > 0 && y > 0)
                            if (board[y - 1, x - 1].isEmpty())
                                tempList.Add(board[y - 1, x - 1]);
                        if (x > 0 && y < 24)
                            if (board[y + 1, x - 1].isEmpty())
                                tempList.Add(board[y + 1, x - 1]);
                        if (x < 79 && y > 0)
                            if (board[y - 1, x + 1].isEmpty())
                                tempList.Add(board[y - 1, x + 1]);
                        if (x < 79 && y < 24)
                            if (board[y + 1, x + 1].isEmpty())
                                tempList.Add(board[y + 1, x + 1]);

                        random = rnd.Next(0, tempList.Count);
                        if (tempList.Count > 0)
                            tempList.ElementAt(random).Revive();
                        
                    }
                }
            }
        }

        public static void checkDeaths(Creature[,] board)
        {
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 80; x++)
                {
                    if (board[y, x].age >= board[y, x].ageLimit)
                    {
                        board[y, x].setEmpty(true);
                        board[y, x].setBaby(false);
                        board[y, x].setAge(0);
                    }
                }
            }
        }
    }
}
