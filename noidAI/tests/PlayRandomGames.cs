﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApplication1.noidAI
{
    //classes

    //0 - neutral
    //1 - N/A
    //2 - druid 
    //3 - hunter
    //4 - mage
    //5 - paladin
    //6 - priest
    //7 - rogue
    //8 - shaman
    //9 - warlock
    //10 - warrior
    
    class PlayRandomGames//intended to be a  pre-"hello world" for MCTS
    {
        static int[] manaCostAmount= new int[21];
        
     
        static Handmanager.Handcard[] myDeck = new Handmanager.Handcard[30];
        static Handmanager.Handcard[] myOtherDeck = new Handmanager.Handcard[30];

        static int player1Class = 2;
        static int player2Class = 10;
        static Movegenerator movegen = Movegenerator.Instance;
        static List<CardDB.Card> legalCards = new List<CardDB.Card>();
        static void Main(string[] args)
        {
            legalCards = LegalDeckCards.generateLegalCards();
            Random generator = new Random();
            //Enum.GetNames(typeof(MyEnum)).Length

            populateDecks();
            

            noidPlayState defaultField = new noidPlayState(myDeck,myOtherDeck);
          
            
            List<Action> actions = movegen.getMoveList(defaultField, false, false, false);
           

            int howLong = 0;
            while (true)
            {
                Console.WriteLine("before healths... " + defaultField.ownHero.Hp + " " + defaultField.enemyHero.Hp);
                actions = movegen.getMoveList(defaultField, false, false, false);
                while (actions.Count > 0)// just do all the actions we can
                {
                    //Console.WriteLine("before i play a card ");
                    //defaultField.printHand(defaultField.owncards);
                    //Console.WriteLine();
                    defaultField.doAction(actions[0]);

                    
                    if(actions[0].card!=null)
                        for(int i = 0; i<defaultField.owncards.Count; i++){
                            Handmanager.Handcard hh = defaultField.owncards[i];
                            if (hh.entity == actions[0].card.entity)
                            {
                                defaultField.owncards.RemoveAt(i);
                                break;
                            }
                        }
                    List<Handmanager.Handcard> hand = defaultField.owncards;

                    for (int i = 0; i < hand.Count; i++)// HEY LOOK HERE!!
                    {

                        if (hand[i].card.name == CardDB.Instance.cardNamestringToEnum("unknown"))
                        {
                            if (actions[0].card != null)
                                Console.WriteLine("just played " + actions[0].card.card.name);
                            //defaultField.printHand(hand);
                            defaultField.owncards.RemoveAt(i);
                            defaultField.owncards.Add(myDeck[(defaultField.ownDeckPointer)]);
                            defaultField.ownDeckPointer++;
                            i--;
                          //  while (true) { }
                        }
                    }
                    if (actions[0].card != null)
                        Console.WriteLine("just played " + actions[0].card.card.name);
                    actions = movegen.getMoveList(defaultField, false, false, false);
                }
                Console.WriteLine("after healths... " + defaultField.ownHero.Hp + " " + defaultField.enemyHero.Hp);
                defaultField.endTurn();// end turn
            }

           
            Console.Read();
        }

        public static void populateDecks()
        {
            Random generator = new Random();
            for (int i = 0; i < myDeck.Length; i++)
            {

                Handmanager.Handcard randomCard = null;

                randomCard = getCardOfClass(player1Class,generator);
                myDeck[i] = randomCard;

                randomCard = getCardOfClass(player2Class, generator);
                myOtherDeck[i] = randomCard;

            }
        }
        public static Handmanager.Handcard getCardOfClass(int Class, Random generator)
        {
                
                CardDB.Card randomCard = null;
                while(true)
                {
                    randomCard = legalCards[generator.Next(legalCards.Count)];
                    Handmanager.Handcard randomHandCard = null;

                    randomHandCard = new Handmanager.Handcard(randomCard);
                    randomHandCard.entity = generator.Next(1000000);
                    randomHandCard.manacost = randomCard.cost;
                    if (randomCard.Class == Class)
                    {
                        return randomHandCard;
                    }
                    
                }

        }
        public static string ToString(List<string> data)
        {
            string builder = "" + data.Count + ": ";
            int count = data.Count;
            if (count == 0)
                return builder;
            for (int i = 0; i < count - 1; i++)
            {
                builder += data[i].ToString() + ", ";
                if (i % 5 == 4)
                {
                    builder += "\n";
                }
            }
            // if (count - 1 < data.Length) 
            builder += data[count - 1].ToString();
            return builder;
        }

    }
    class noidPlayState: Playfield
    {
        int turnsElapsed = 0;
        public Handmanager.Handcard[] myDeck; // this will be randomized per play, but not per action (if that makes any sense)
        public Handmanager.Handcard[] enemyDeck; // this will be randomized per play, but not per action (if that makes any sense)
        public List<Handmanager.Handcard> EnemyCards = new List<Handmanager.Handcard>();// dont want to modify botmaker's stuff without permission, he's already having memory problems
        // keep track of the enemycards myself
        bool myTurn = true;
        public int ownDeckPointer = 0;
        int enemyDeckPointer = 0;
        public noidPlayState(Handmanager.Handcard[] deck1, Handmanager.Handcard[] deck2)
        {
            //shapeshift
            ownHeroAblility.card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_017);
            enemyHeroAblility.card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_017);
            ownHero.Hp = 30;
            enemyHero.Hp = 30;
            //ownHeroAblility = new Handmanager.Handcard(Hrtprozis.Instance.heroAbility);
            //enemyHeroAblility = new Handmanager.Handcard(Hrtprozis.Instance.enemyAbility);
            enemyDeck = deck2;
            myDeck = deck1;
            for (int i = 0; i < 4; i++)
            {
              //  EnemyCards.Add(enemyDeck[++enemyDeckPointer]);
                
                //owncards.Add(myDeck[++ownDeckPointer]);
                //printHand(owncards);
            }
            mana = 1;
            ownMaxMana = 1;
            enemyMaxMana = 0;
        
        }
        public void printHand(List<Handmanager.Handcard> hand)
        {
            Console.WriteLine("cards:");
            for (int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine(hand[i].card.name);
            }
        }
        public void swapEverything()
        {
             //swap hero
            Swap(ref ownHero, ref enemyHero);
            Swap(ref ownHeroName, ref enemyHeroName);
            Swap(ref ownHeroAblility, ref enemyHeroAblility);
            //Swap(ref ownHeroEntity, ref enemyHeroEntity);
            //swap weapon
            swapReferences(ownWeaponName, enemyWeaponName);
            Swap(ref ownWeaponAttack,ref enemyWeaponAttack);
            Swap(ref ownWeaponDurability, ref enemyWeaponDurability);
            Swap(ref ownWeaponName, ref enemyWeaponName);

            //swap deck
            Swap(ref enemyDeck,ref myDeck);
            Swap(ref ownDeckSize, ref enemyDeckSize);

            //swap hand
            enemyAnzCards = owncards.Count;
            Swap(ref owncards,ref EnemyCards);
           
            // swap minions
            Swap(ref ownMinions, ref enemyMinions);

            //swap mana
            Swap(ref ownMaxMana, ref enemyMaxMana);
            // all the special minions
            Swap(ref anzOwnRaidleader, ref anzEnemyRaidleader);
            Swap(ref anzOwnStormwindChamps, ref anzEnemyStormwindChamps);
            Swap(ref anzOwnTundrarhino, ref anzEnemyTundrarhino);
            Swap(ref anzOwnTimberWolfs, ref anzEnemyTimberWolfs);
            //Swap(ref anzMurlocWarleader, ref anzMurlocWarleader);
            //Swap(ref anzGrimscaleOracle, ref anzGrimscaleOracle);
            Swap(ref anzOwnAuchenaiSoulpriest, ref anzEnemyAuchenaiSoulpriest);
            Swap(ref anzOwnsorcerersapprentice, ref anzEnemysorcerersapprentice);
            Swap(ref anzOwnsorcerersapprenticeStarted, ref anzEnemysorcerersapprenticeStarted);
            Swap(ref anzOwnSouthseacaptain, ref anzEnemySouthseacaptain);
        }
        public void endTurn()
        {
            if (ownHero.Hp <= 0)
            {
                if (myTurn)
                    Console.WriteLine("uh warrior wins?");
                else
                    Console.WriteLine("uh druid wins?");
                Console.WriteLine("turns elapsed: " + turnsElapsed);
                while (true) { }
            }
            if (enemyHero.Hp <= 0)
            {
                if (myTurn)
                    Console.WriteLine("uh druid wins?");
                else
                    Console.WriteLine("uh warrior wins?");
                Console.WriteLine("turns elapsed: " + turnsElapsed);
                while (true) { }
            }
            this.triggerEndTurn(true);
           
            // the other player is going to do its stuff:
            myTurn = !myTurn;
            swapEverything();
            
           
            Console.WriteLine("TURN PASSING");
           
            //owncards.Add(myDeck[++ownDeckPointer]);


               // printHand(EnemyCards);

           // printHand(owncards);
            triggerStartTurn(true);
            owncards.RemoveAt(owncards.Count - 1);
            prepareNextTurn(true);
            turnsElapsed++;
            //owncards.RemoveAt(owncards.Count);
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public void swapReferences(Object obj1, Object obj2)
        {
            Object temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }
    }

}
