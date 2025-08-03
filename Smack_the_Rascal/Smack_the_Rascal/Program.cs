using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Game
{
    public class Interface
    {
        public void DisplayInterfaceMain(Equipment eq, string rascalA, string rascalB, string rascalC, string critMark)
        {
            Console.WriteLine("                              = Główna Arena =");
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Console.WriteLine($" Wyposażona broń: {eq.EquippedWeapon().name}                              Monety: {(Player.ownedCoins)} ");
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine($"|                                 _=====_       {critMark}                        |");
            Console.WriteLine($"|                               {rascalA}                                  |");
            Console.WriteLine($"|                               {rascalB}                                 |");
            Console.WriteLine($"|                               {rascalC}                                 |");
            Console.WriteLine("|                                \\_______/                                  |");
            Console.WriteLine("|                                /  / \\  \\                                  |");
            Console.WriteLine("|                                |  | |  |                                  |");
            Console.WriteLine("|                               \"\"\"\"   \"\"\"\"                                 |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("#===========================================================================#");
            Console.WriteLine("|      [ 1 ]      |       [ 2 ]       |       [ 3 ]       |      [ 4 ]      |");
            Console.WriteLine("|      Atakuj     |     Ekwipunek     |       Sklep       |    Statystyki   |");
            Console.WriteLine("|                 |                   |                   |                 |");
            Console.WriteLine("#===========================================================================#");
        }
        public void DisplayInterfaceInventory(Equipment eq) {
           
            Console.WriteLine("                                = Ekwipunek =");
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Console.WriteLine($" Wyposażona broń: {eq.EquippedWeapon().name} (obrażenia {eq.EquippedWeapon().damage}  Crit Rate {eq.EquippedWeapon().critRate}%  Crit DMG {eq.EquippedWeapon().critDamage}%)");
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Console.WriteLine("| Posiadane bronie (wybierz numer by wyposażyć):                            ");
            foreach (Weapon weapon in eq.inventory)
            {
                eq.DisplayInventorySlot(eq.inventory.IndexOf(weapon) + 1);
            }
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("#===========================================================================#");
            Console.WriteLine("|                                   [ Q ]                                   |");
            Console.WriteLine("|                               Wróć do gnoja                               |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("#===========================================================================#");
        }

        public void DisplayInterfaceShop(string notification) {

            Console.WriteLine("                                  = Sklep =");
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Console.WriteLine($" {notification}                        Monety: {(Player.ownedCoins)} ");
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Console.WriteLine("|     Przedmiot     |  Cena  | Obrażenia | Crit Rate | Crit DMG | Posiadany |");
            Console.WriteLine("|===========================================================================|");
            Console.WriteLine("|                                                                           |");//foreach by popsuło kolumny bo nazwy nie są równej długości
            Console.WriteLine($"|1. {Weapon.baseball.name} ,  ${Weapon.baseball.price}  ,     {Weapon.baseball.damage}    ,    {Weapon.baseball.critRate}%    ,    {Weapon.baseball.critDamage}%   ,    {Weapon.baseball.inInventory}    |");
            Console.WriteLine($"|2. {Weapon.handgunLight.name}        ,  ${Weapon.handgunLight.price}  ,     {Weapon.handgunLight.damage}    ,    {Weapon.handgunLight.critRate}%    ,    {Weapon.handgunLight.critDamage}%   ,    {Weapon.handgunLight.inInventory}    |");
            Console.WriteLine($"|3. {Weapon.swordBasic.name}       , ${Weapon.swordBasic.price}  ,     {Weapon.swordBasic.damage}    ,    {Weapon.swordBasic.critRate}%    ,   {Weapon.swordBasic.critDamage}%   ,    {Weapon.swordBasic.inInventory}    |");
            Console.WriteLine($"|4. {Weapon.handgunHeavy.name}       , ${Weapon.handgunHeavy.price}  ,     {Weapon.handgunHeavy.damage}    ,    {Weapon.handgunHeavy.critRate}%    ,   {Weapon.handgunHeavy.critDamage}%   ,    {Weapon.handgunHeavy.inInventory}    |");
            Console.WriteLine($"|5. {Weapon.swordArthur.name}       , ${Weapon.swordArthur.price}  ,     {Weapon.swordArthur.damage}    ,    {Weapon.swordArthur.critRate}%    ,   {Weapon.swordArthur.critDamage}%   ,    {Weapon.swordArthur.inInventory}    |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("#===========================================================================#");
            Console.WriteLine("|                                   [ Q ]                                   |");
            Console.WriteLine("|                               Wróć do gnoja                               |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("#===========================================================================#");
        }

        public void DisplayInterfaceStats(Equipment eq) {

            Console.WriteLine("                               = Statystyki =");
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Console.WriteLine($"| Zadane obrażenia: {Math.Round(Player.totalDamage, 2)}");
            Console.WriteLine("|");
            Console.WriteLine($"| Wykonane ataki: {Player.totalAttacks}");
            Console.WriteLine("|");
            Console.WriteLine($"| Ataki krytyczne: {Player.totalCrits}");
            Console.WriteLine("|");
            Console.WriteLine($"| Ataki bez kryta: {Player.totalNonCrits}");
            Console.WriteLine("|");
            Console.WriteLine($"| Współczynnik atatków krytycznych: {(Math.Round(Convert.ToDouble(Player.totalCrits) / Convert.ToDouble(Player.totalAttacks), 2))* 100}%"); //wiem, że na początku daje NaN, ale ma to sens bo nie wykonano jeszcze żadnego ataku
            Console.WriteLine("|");
            Console.WriteLine($"| Monet zdobytych w sumie: {Player.totalCoinsGathered}");
            Console.WriteLine("|");
            Console.WriteLine($"| Posiadane bronie: {eq.inventory.Count}/6");
            Console.WriteLine("|");
            Console.WriteLine("#===========================================================================#");
            Console.WriteLine("|                                   [ Q ]                                   |");
            Console.WriteLine("|                               Wróć do gnoja                               |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("#===========================================================================#");
        }

        public static void WelcomeScreen(string title, string proceedPrompt)
        {
            for(int i = 0; i < 6; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("                        #==========================#");
            Console.WriteLine("                        |     xX-Melatonina-Xx     |");
            Console.WriteLine("                        |        prezentuje        |");
            Console.WriteLine("                        |                          |");
            Console.WriteLine($"                        |     {title}     |");
            Console.WriteLine("                        |                          |");
            Console.WriteLine($"                        | {proceedPrompt} |");
            Console.WriteLine("                        #==========================#");

        }

        public static void DecideShopTransaction(Weapon desiredWeapon)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("                  $=======================================$");
            Console.WriteLine();
            Console.WriteLine($"                      Potwierdź zakup: {desiredWeapon.name}");
            Console.WriteLine("                                    (Y/N)");
            Console.WriteLine();
            Console.WriteLine("                  $=======================================$");

        }

    }

    class Player
    {

        public static string rascalA = Rascal.spriteIdle1;
        public static string rascalB = Rascal.spriteIdle2;
        public static string rascalC = Rascal.spriteIdle3;
        
        public static double totalDamage;
        public static int totalAttacks;
        public static int totalNonCrits;
        public static int totalCrits;
        public static int totalCoinsGathered;
        public static int coinsEarned;
        public static int ownedCoins;
        public static string critMark;
        static public void PerformAttack(Equipment eq, Interface inf)
        {
            double critDmgDealt = Math.Round(eq.EquippedWeapon().damage + eq.EquippedWeapon().damage * (Convert.ToDouble(eq.EquippedWeapon().critDamage) / 100));
            Random rng = new();
            int critChance = rng.Next(0, 101);            
            if (critChance >= 0 && critChance < eq.EquippedWeapon().critRate)
            {                 
                coinsEarned = Convert.ToInt32(Math.Round(critDmgDealt * 0.8));
                ownedCoins += coinsEarned;
                totalCoinsGathered += coinsEarned;
                totalCrits += 1;
                totalDamage += critDmgDealt;
                critMark = "CRIT";
                rascalA = Rascal.spriteCritHitTaken1;
                rascalB = Rascal.spriteCritHitTaken2;
                rascalC = Rascal.spriteCritHitTaken3;
                inf.DisplayInterfaceMain(eq, rascalA, rascalB, rascalC, critMark);
                critMark = "    ";
                rascalA = Rascal.spriteIdle1;
                rascalB = Rascal.spriteIdle2;
                rascalC = Rascal.spriteIdle3;
            }
            else
            {
                coinsEarned = Convert.ToInt32(Math.Round(eq.EquippedWeapon().damage) * 0.35);
                ownedCoins += coinsEarned;
                totalCoinsGathered += coinsEarned;
                totalNonCrits += 1;
                totalDamage += eq.EquippedWeapon().damage;
                critMark = "    ";
                rascalA = Rascal.spriteLightHitTaken1;
                rascalB = Rascal.spriteLightHitTaken2;
                rascalC = Rascal.spriteLightHitTaken3;
                inf.DisplayInterfaceMain(eq, rascalA, rascalB, rascalC, critMark);
                rascalA = Rascal.spriteIdle1;
                rascalB = Rascal.spriteIdle2;
                rascalC = Rascal.spriteIdle3;
            }

            totalAttacks += 1;;
        }        
    }

    public class Weapon
    {
        public string name;
        public double damage;
        public int critRate;
        public int critDamage;
        public int price;
        public string inInventory;

            public Weapon(string name, double damage, int critRate, int critDamage, int price, string inInventory)
            {
                this.name = name;
                this.damage = damage;
                this.critRate = critRate;
                this.critDamage = critDamage;
                this.price = price;
                this.inInventory = inInventory;
            }

        public static Weapon fists = new("Suche pięści", 8, 0, 0, 0, "tak");
        public static Weapon baseball = new("Kij baseballowy", 17, 28, 45, 200, "nie");        
        public static Weapon handgunLight = new("Glock 18", 22, 40, 70, 650, "nie");
        public static Weapon swordBasic = new("Arondight", 35, 50, 100, 1100, "nie");
        public static Weapon handgunHeavy = new("Magnum 44", 41, 30, 350, 2500, "nie");
        public static Weapon swordArthur = new("Excalibur", 66, 70, 140, 7400, "nie");           
    }

    public class Equipment
    {
        public List<Weapon> inventory = new List<Weapon>();
        public List<Weapon> shopStock = new List<Weapon>();

          
        public Weapon EquippedWeapon()
        {            
            return inventory[0];
        }

        public void EquipWeapon(Weapon weapon, Equipment eq, Interface inf)
        {
            int oldIndex = inventory.IndexOf(weapon);
            
            Weapon selectedWeapon = inventory[oldIndex];
            inventory.RemoveAt(oldIndex);
            inventory.Insert(0, selectedWeapon);

            Console.Clear();
            inf.DisplayInterfaceInventory(eq);

        }

        public void BuyWeapon(Weapon desiredWeapon, Interface inf)
        {
            Equipment eq = new();
            if (desiredWeapon.inInventory != "tak")
            {
                Console.Clear();
                Interface.DecideShopTransaction(desiredWeapon);
                ConsoleKeyInfo decideTransaction = Console.ReadKey(true);
                if (decideTransaction.Key == ConsoleKey.Y)
                {
                    if (Player.ownedCoins >= desiredWeapon.price)
                    {
                        inventory.Add(desiredWeapon);
                        Player.ownedCoins -= desiredWeapon.price;
                        desiredWeapon.inInventory = "tak";
                        Console.Clear();
                        inf.DisplayInterfaceShop($"Pomyślnie zakupiono: {desiredWeapon.name}");
                        
                    }
                    else
                    {
                        Console.Clear();
                        inf.DisplayInterfaceShop("Nie posiadasz wystarczająco dużo monet");
                    }
                }
                else
                {
                    Console.Clear();
                    inf.DisplayInterfaceShop("Anulowano zakup                       ");
                }
            }
            else
            {
                Console.Clear();
                inf.DisplayInterfaceShop("Już posiadasz tę broń                 ");
            }

        }

        public void DisplayInventorySlot(int slot)
        {
            try
            {
                Console.WriteLine($"| {slot}. {inventory[slot].name}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("|");
            }
        }          
    }

    public class Rascal
    {
        public static string spriteIdle1 = " / _   _ \\";
        public static string spriteIdle2 = "/  0   0  \\";
        public static string spriteIdle3 = "|    u    |";      
        public static string spriteLightHitTaken1 = " /       \\";
        public static string spriteLightHitTaken2 = "/  T   T  \\";
        public static string spriteLightHitTaken3 = "|    ~    |";
        public static string spriteCritHitTaken1 = " /       \\";
        public static string spriteCritHitTaken2 = "/  X   X  \\";
        public static string spriteCritHitTaken3 = "|    A    |";

    }


    class Program
    {
        static void Main()
        {
            Equipment eq = new();
            Rascal rasc = new();
            Interface inf = new();
            eq.inventory.Add(Weapon.fists);
            eq.shopStock.Add(Weapon.baseball);
            eq.shopStock.Add(Weapon.handgunLight);
            eq.shopStock.Add(Weapon.swordBasic);
            eq.shopStock.Add(Weapon.handgunHeavy);           
            eq.shopStock.Add(Weapon.swordArthur);

            Interface.WelcomeScreen("                ", "                        ");
            Thread.Sleep(2000);
            Console.Clear();
            Interface.WelcomeScreen("~ Walnij Gnoja ~", "                        ");
            Thread.Sleep(3000);
            Console.Clear();
            Interface.WelcomeScreen("~ Walnij Gnoja ~", "wciśnij dowolny przycisk");
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Thread.Sleep(100);
            Console.WriteLine();
            Thread.Sleep(100);
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Thread.Sleep(100);
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("|                                                                           |");
                Thread.Sleep(100);
            }
            Console.WriteLine("#===========================================================================#");
            Thread.Sleep(100);
            Console.WriteLine("|                                                                           |");
            Thread.Sleep(100);
            Console.WriteLine("|                                                                           |");
            Thread.Sleep(100);
            Console.WriteLine("|                                                                           |");
            Thread.Sleep(100);
            Console.WriteLine("#---------------------------------------------------------------------------#");
            Thread.Sleep(100);

            Console.Clear();
            inf.DisplayInterfaceMain(eq, Rascal.spriteIdle1, Rascal.spriteIdle2, Rascal.spriteIdle3, "    ");

            while (true)
            {               
                ConsoleKeyInfo selectScreen = Console.ReadKey(true);
                switch (selectScreen.Key)
                {
                    //główny interfejs
                    case ConsoleKey.D1: 
                        Console.Clear();                        
                        Player.PerformAttack(eq, inf);
                        break;
                    
                    //ekwipunek
                    case ConsoleKey.D2:
                        Console.Clear();
                        inf.DisplayInterfaceInventory(eq);

                        ConsoleKeyInfo selectWeaponInventory;

                        do
                        {
                            selectWeaponInventory = Console.ReadKey(true);
                            switch (selectWeaponInventory.Key)
                            {
                                case ConsoleKey.D1:
                                    try
                                    {
                                        eq.EquipWeapon(eq.inventory[1], eq, inf);
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        Console.Clear();
                                        inf.DisplayInterfaceInventory(eq);
                                    }
                                    break;

                                case ConsoleKey.D2:
                                    try
                                    {
                                        eq.EquipWeapon(eq.inventory[2], eq, inf);

                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        Console.Clear();
                                        inf.DisplayInterfaceInventory(eq);
                                    }
                                    break;

                                case ConsoleKey.D3:
                                    try
                                    {
                                        eq.EquipWeapon(eq.inventory[3], eq, inf);
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        Console.Clear();
                                        inf.DisplayInterfaceInventory(eq);
                                    }
                                    break;

                                case ConsoleKey.D4:
                                    try
                                    {
                                        eq.EquipWeapon(eq.inventory[4], eq, inf);
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        Console.Clear();
                                        inf.DisplayInterfaceInventory(eq);
                                    }
                                    break;

                                case ConsoleKey.D5:
                                    try
                                    {
                                        eq.EquipWeapon(eq.inventory[5], eq, inf);
                                    }
                                    catch(ArgumentOutOfRangeException)
                                    {
                                        Console.Clear();
                                        inf.DisplayInterfaceInventory(eq);
                                    }                                    
                                    break;

                                case ConsoleKey.Q:
                                    Console.Clear();
                                    inf.DisplayInterfaceMain(eq, Rascal.spriteIdle1, Rascal.spriteIdle2, Rascal.spriteIdle3, "    ");
                                    break;
                                   

                                default:
                                    Console.Clear();
                                    inf.DisplayInterfaceInventory(eq);
                                    break;
                            }
                        } while(selectWeaponInventory.Key != ConsoleKey.Q);
                       
                        break;

                    //sklep
                    case ConsoleKey.D3:
                        Console.Clear();
                        inf.DisplayInterfaceShop("                                      ");

                        do
                        {                              
                            selectScreen = Console.ReadKey(true);
                            switch (selectScreen.Key)
                            {
                                case ConsoleKey.D1:
                                    eq.BuyWeapon(Weapon.baseball, inf);
                                    break;

                                case ConsoleKey.D2:
                                    eq.BuyWeapon(Weapon.handgunLight, inf);
                                    break;

                                case ConsoleKey.D3:
                                    eq.BuyWeapon(Weapon.swordBasic, inf);
                                    break;

                                case ConsoleKey.D4:
                                    eq.BuyWeapon(Weapon.handgunHeavy, inf);
                                    break;

                                case ConsoleKey.D5:
                                    eq.BuyWeapon(Weapon.swordArthur, inf);
                                    break;

                                case ConsoleKey.Q:
                                    Console.Clear();
                                    inf.DisplayInterfaceMain(eq, Rascal.spriteIdle1, Rascal.spriteIdle2, Rascal.spriteIdle3, "    ");
                                    break;

                                default:
                                    Console.Clear();
                                    inf.DisplayInterfaceShop("                                      ");
                                    break;
                            }

                        } while (selectScreen.Key != ConsoleKey.Q);
                        break;

                    //ekran statystyk
                    case ConsoleKey.D4:
                        Console.Clear();
                        inf.DisplayInterfaceStats(eq);
                        ConsoleKeyInfo quitStatistics;

                        do
                        {
                            quitStatistics = Console.ReadKey(true);
                            switch (quitStatistics.Key)
                            {
                                case ConsoleKey.Q:
                                    Console.Clear();
                                    inf.DisplayInterfaceMain(eq, Rascal.spriteIdle1, Rascal.spriteIdle2, Rascal.spriteIdle3, "    ");
                                    break;


                                default:
                                    Console.Clear();
                                    inf.DisplayInterfaceStats(eq);
                                    break;
                            }
                        } while (quitStatistics.Key != ConsoleKey.Q);
                        break;

                    default:
                        continue;
                }                
            }
        }
    }
}