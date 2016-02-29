using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
 
    
        public class DrawCards
        {
            public static void DrawCardOutline(int xcoor, int ycoor)
            {
                Console.ForegroundColor = ConsoleColor.White;


                int x = xcoor * 12;
                int y = ycoor;

                Console.SetCursorPosition(x, y);
                Console.Write(" __________\n");//top edge of card

                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(x, y + 1 + i);

                    if (i != 9)
                        Console.WriteLine("|          |");//left and right edges
                    else
                        Console.WriteLine("|__________|");//bottom of card
                }
            }
            //display suit and value inside its outline
            public static void DrawCardSuitAndValue(Card card, int xcoor, int ycoor)
            {
                
                int x = xcoor * 12;
                int y = ycoor;     
                Console.SetCursorPosition(x + 3, y + 5);
                Console.Write(card.MySuit);
                Console.SetCursorPosition(x + 4, y + 7);
                Console.Write(card.MyRank);
            }

        }

    }

