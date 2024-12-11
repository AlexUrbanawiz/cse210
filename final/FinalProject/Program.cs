using System;



/*
Tavern Keep Sim

Classes
Item-Base
Attributes
    Cost


Food : Item


Drink : Item


Till
Keeps track of money/purchase histroy


Tavern
Keeps track of inventory, uses till to display money, keeps track of customers served


Person-Base
Name
Points for serving
Role
Method Action(abstract)

Customer : Person
Favorite Food/Drink
Money given for service
How forgiving they are


Inspector : Person
No money for service
If you dont serve them in time you lose



The game loop is as follows:
A random customer is generated, with a small chance to spawn an inspector that grows as your score increases. When a customer approaches you have to serve them. If you take too long to serve them, or serve them the wrong food/drink then you get a deduction. 
A deduction with customers only reduces the money and score reccived for serving them, but if you take too long or serve an inspector the wrong item then you get a strike. Three strikes and youre out.
You get a break every certain amount of customers to order food/drink, and to mentally prepare for the next day.
As you progress the period between breaks grows larger, so you have to plan further in advance
*/
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");
    }
}