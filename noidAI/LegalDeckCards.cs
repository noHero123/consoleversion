using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    class LegalDeckCards
    {
       
        static CardDB.cardIDEnum[] illegalIDs = { CardDB.cardIDEnum.EX1_165t1, CardDB.cardIDEnum.EX1_165t2,//druid of claw
                                            CardDB.cardIDEnum.Mekka4t, CardDB.cardIDEnum.EX1_155b,//chicken, mark of nature
                                            CardDB.cardIDEnum.EX1_155a,CardDB.cardIDEnum.EX1_164a,  //mark of nature,nourish
                                            CardDB.cardIDEnum.EX1_164b,CardDB.cardIDEnum.NEW1_007b, //nourish,starfall
                                            CardDB.cardIDEnum.NEW1_007a,CardDB.cardIDEnum.EX1_154a, //starfall,wrath
                                            CardDB.cardIDEnum.EX1_154b //wrath
                                            };
        // got from hearthstone wiki
        static string[] illegalCards = { "unknown", "ancientsecrets", "ancientteaching", "ashbringer",
                                    "bainebloodhoof", "bananas", "battleaxe", "bearform", "bloodfury", 
                                    "boar", "catform", "damagedgolem", "defender", "defiasbandit", 
                                    "demigodsfavor", "devilsaur", "dispel", "dream", "emboldener3000",
                                    "emeralddrake","excessmana","finkleeinhorn","flameofazzinoth",
                                    "frog","gnoll","healingtotem","heavyaxe","homingchicken","hound",
                                    "huffer","hyena", "iammurloc","imp","infernal","laughingsister",
                                    "leaderofthepack","leokk","mechanicaldragonling","mirrorimage",
                                    "misha","murloc","murloc","nerubian","nightmare","panther",
                                    "poultryizer","powerofthehorde","repairbot","roguesdoit...",
                                    "rooted","searingtotem","shadowofnothing","shandoslesson","sheep",
                                    "silverhandrecruit","snake","spectralspider","spiritwolf",
                                    "squire", "squirrel","stoneclawtotem","slime","summonapanther","thaddius",
                                    "thecoin","treant","uproot","violetapprentice","whelp","wickedknife",
                                    "worthlessimp","wrathofairtotem","yseraawakens","adrenalinerush",
                                    "deathcharger"};
        static List<CardDB.Card> legalCards = new List<CardDB.Card>();
        static List<CardDB.Card> legalDruidCards = new List<CardDB.Card>();
        static List<CardDB.Card> legalHunterCards = new List<CardDB.Card>();
        static List<CardDB.Card> legalMageCards = new List<CardDB.Card>();
        static List<CardDB.Card> legalPaladinCards = new List<CardDB.Card>();
        static List<CardDB.Card> legalPriestCards = new List<CardDB.Card>();
        static List<CardDB.Card> legalRogueCards = new List<CardDB.Card>();
        static List<CardDB.Card> legalShamanCards = new List<CardDB.Card>();
        static List<CardDB.Card> legalWarlockCards = new List<CardDB.Card>();
        static List<CardDB.Card> legalWarriorCards = new List<CardDB.Card>();

        public static bool isLegal(CardDB.Card card)
        {
            if (isIllegal(card))
            {
                return false;
            }
            // was thinking to add more logic here, if it's unknown could be neither legal nor illegal
            return true;

        }
        public static bool isIllegal(CardDB.Card card)
        {
            CardDB.cardIDEnum cardID = card.cardIDenum;
            List<string> illegalCardsList = new List<string>(illegalCards);
            List<CardDB.cardIDEnum> illegalIDsList = new List<CardDB.cardIDEnum>(illegalIDs);
            // Console.WriteLine(cardID.ToString()[cardID.ToString().Length - 1]);
            // Console.WriteLine(Char.IsLetter(cardID.ToString()[cardID.ToString().Length - 1]));
            bool isChoiceEffect = Char.IsLetter(cardID.ToString()[cardID.ToString().Length - 1]);
            bool isChoiceEffect2 = Char.IsLetter(cardID.ToString()[cardID.ToString().Length - 2]);
            bool isAwesomeInvention = false;
            if (cardID.ToString().Length > 4)
                isAwesomeInvention = cardID.ToString().Substring(0, 5).Contains("Mekka");
            bool isDebugCard = cardID.ToString().Substring(0, 3).Contains("XXX");
            bool isTutCard = cardID.ToString().Substring(0, 2).Contains("TU");
            bool isNaxBossCard = cardID.ToString().Substring(0, 3).Contains("NAX");
            bool isGameCard = cardID.ToString().Substring(0, 4).Contains("GAME");
            bool isHeroCard = cardID.ToString().Substring(0, 4).Contains("HERO");
            bool isCreditsCard = cardID.ToString().Substring(0, 4).Contains("CRED");
            bool isOnMyList1 = illegalCardsList.Contains(card.name.ToString());
            bool isOnMYList2 = illegalIDsList.Contains(cardID);
            bool isAHeroPower = isHeroPower(card);
            //Console.WriteLine((int)CardDB.cardIDEnum.CS2_008);
            if ((int)card.cardIDenum == 802)
            {
                Console.WriteLine("this should be shadow death");
                Console.WriteLine(card.name);
                Console.WriteLine(card.cost);
                Console.WriteLine(isChoiceEffect + " " + isChoiceEffect2 + " " + isHeroCard + " " + isAwesomeInvention + " " + isDebugCard + " " + isTutCard + " " + isNaxBossCard + " " + isGameCard + " " + isCreditsCard + " " + isOnMyList1 + " " + isOnMYList2);

            }
            return isAHeroPower || isChoiceEffect || isChoiceEffect2 || isHeroCard || isAwesomeInvention || isDebugCard || isTutCard || isNaxBossCard || isGameCard || isCreditsCard || isOnMyList1 || isOnMYList2;

        }
        public static bool isHeroPower(CardDB.Card card)
        {
            if (card.name.ToString().Equals("lesserheal"))
            {

                return true;

            }
            if (card.name.ToString().Equals("armorup"))
            {

                return true;

            }
            if (card.name.ToString().Equals("shapeshift"))
            {

                return true;

            }
            if (card.name.ToString().Equals("steadyshot"))
            {

                return true;

            }
            if (card.name.ToString().Equals("reinforce"))
            {

                return true;

            }
            if (card.name.ToString().Equals("fireblast"))
            {

                return true;

            }
            if (card.name.ToString().Equals("mindspike"))
            {

                return true;

            }
            if (card.name.ToString().Equals("mindshatter"))
            {

                return true;

            }
            if (card.name.ToString().Equals("daggermastery"))
            {

                return true;

            }
            if (card.name.ToString().Equals("totemiccall"))
            {

                return true;

            }
            if (card.name.ToString().Equals("lifetap"))
            {

                return true;

            }
            if (card.name.ToString().Equals("inferno"))
            {

                return true;

            }
            return false;

        }
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
        public static List<CardDB.Card> generateLegalCards()
        {


            String builder = "";
            for (int i = 0; i < Enum.GetNames(typeof(CardDB.cardIDEnum)).Length; i++)
            {
               
                CardDB.cardIDEnum randomCardEnum = (CardDB.cardIDEnum)i;
                CardDB.Card randomCard = CardDB.Instance.getCardDataFromID(randomCardEnum);

                
                
                if (!isIllegal(randomCard))
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
                    legalCards.Add(randomCard);
                    switch (randomCard.Class)
                    {
                        case 0:
                            legalDruidCards.Add(randomCard);
                            legalHunterCards.Add(randomCard);
                            legalMageCards.Add(randomCard);
                            legalPaladinCards.Add(randomCard);
                            legalPriestCards.Add(randomCard);
                            legalRogueCards.Add(randomCard);
                            legalShamanCards.Add(randomCard);
                            legalWarlockCards.Add(randomCard);
                            legalWarriorCards.Add(randomCard);
                             break;
                        case 1: break;
                        case 2: legalDruidCards.Add(randomCard); break;
                        case 3: legalHunterCards.Add(randomCard); break;
                        case 4: legalMageCards.Add(randomCard); break;
                        case 5: legalPaladinCards.Add(randomCard); break;
                        case 6: legalPriestCards.Add(randomCard); break;
                        case 7: legalRogueCards.Add(randomCard); break;
                        case 8: legalShamanCards.Add(randomCard); break;
                        case 9: legalWarlockCards.Add(randomCard); break;
                        case 10: legalWarriorCards.Add(randomCard); break;
                    }
                }


              
            }
            
            Console.WriteLine("THERE ARE " + legalCards.Count + " legal deck cards");
            //Console.WriteLine(builder);
                
            return legalCards;

        }

        
    }
    
}
