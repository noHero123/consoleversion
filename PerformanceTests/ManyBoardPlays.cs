using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication1.PerformanceTests
{
    class ManyBoardPlays
    {
        //we have lots of minions on both sides and at least one power of the wild in my hand in the txt file here
        // for the sake of readability and use by other people, string is declared at the bottom of the class
        static TextWriter console = Console.Out;
        
        static void Main(string[] args)
        {
            Console.WriteLine("START");
            
            //format the strings real fast... probably could have just gotten ridof <EoF> myself...
            board500 = board500.Replace("<EoF>", ""); // doing the board with maxwide = 500
            board1000 = board1000.Replace("<EoF>", ""); // doing the board with maxwide = 1000

            board3000 = board3000.Replace("<EoF>", ""); // doing the board with maxwide = 3000
            board7000 = board7000.Replace("<EoF>", ""); // doing the board with maxwide = 7000
            board9000 = board9000.Replace("<EoF>", ""); // doing the board with maxwide = 9000
            board14000 = board14000.Replace("<EoF>", ""); // doing the board with maxwide = 14000


            doTest(board500, 10);

            doTest(board1000, 2);

            doTest(board3000, 6);

            doTest(board7000, 4); //well it takes forever... small sample

            Console.Read();
        }


        public static void doTest(String data, int numTimes)
        {
            Console.WriteLine("MAKE SURE EXECUTABLE CAN FIND CARDDB");
            setPrint(false);// dont want all those prints
            Program a = new Program();
            Bot b = new Bot();

            Console.WriteLine("okay i got here");
            b.doData(data);//get rid of the first trial just for kicks.
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < numTimes; i++)
            {
                b.doData(data);
                setPrint(true);
                Console.Write(".");
                setPrint(false);
            }

            timer.Stop();

            setPrint(true);
            Console.WriteLine("test results: average " + (timer.ElapsedMilliseconds / numTimes) + ", sample size: " + numTimes);
        }
        public static void setPrint(bool print)
        {
            if (!print)
            {
                Console.SetOut(TextWriter.Null);
                Console.SetError(TextWriter.Null);
            }
            else
            {
                Console.SetOut(console);
                Console.SetError(console);
            }
        }
        static string board500 = "\r\n#######################################################################\r\n#######################################################################\r\nstart calculations, current time: 04:04:19:3829 V112.3 rush 500 twoturnsim 256 ntss 6 30 50 ets 50 simEnemy2Turn ents 50\r\n#######################################################################\r\nmana 8/8\r\nemana 8\r\nown secretsCount: 0\r\nenemy secretsCount: 0\r\nplayer:\r\n0 0 0 1\r\nownhero:\r\ndruid 16 30 0 False False 4 True 0 False 0 0\r\nweapon: 0 0 unknown\r\nability: True CS2_017\r\nosecrets: \r\nenemyhero:\r\ndruid 29 30 1 False False 40\r\nweapon: 0 0 unknown\r\nability: true CS2_017\r\nfatigue: 16 0 19 0\r\nOwnMinions:\r\nimp EX1_598 zp:1 e:80 A:1 H:1 mH:1 rdy:True natt:0\r\nfrostwolfwarlord CS2_226 zp:2 e:35 A:8 H:8 mH:8 rdy:True natt:0\r\nrazorfenhunter CS2_196 zp:3 e:31 A:2 H:3 mH:3 rdy:True natt:0\r\nboar CS2_boar zp:4 e:85 A:1 H:1 mH:1 rdy:True natt:0\r\nEnemyMinions:\r\nrivercrocolisk CS2_120 zp:1 e:48 A:2 H:3 mH:3 rdy:False ex ptt\r\nsilverbackpatriarch CS2_127 zp:2 e:57 A:1 H:1 mH:4 rdy:True ex tnt\r\noasissnapjaw CS2_119 zp:3 e:67 A:2 H:1 mH:7 rdy:True ex\r\nnightblade EX1_593 zp:4 e:53 A:4 H:2 mH:4 rdy:True ex\r\nnightblade EX1_593 zp:5 e:52 A:4 H:4 mH:4 rdy:False ex ptt\r\nOwn Handcards: \r\npos 1 dragonlingmechanic 4 entity 13 EX1_025\r\npos 2 savageroar 3 entity 22 CS2_011\r\npos 3 frostwolfwarlord 5 entity 19 CS2_226\r\npos 4 harvestgolem 3 entity 33 EX1_556\r\npos 5 harvestgolem 3 entity 17 EX1_556\r\npos 6 knifejuggler 2 entity 18 NEW1_019\r\nEnemy cards: 3\r\nownDiedMinions: \r\nenemyDiedMinions: \r\nog: \r\neg: <EoF>";
        static string board1000 = "\r\n#######################################################################\r\n#######################################################################\r\nstart calculations, current time: 04:04:19:3829 V112.3 rush 1000 twoturnsim 256 ntss 6 30 50 ets 50 simEnemy2Turn ents 50\r\n#######################################################################\r\nmana 8/8\r\nemana 8\r\nown secretsCount: 0\r\nenemy secretsCount: 0\r\nplayer:\r\n0 0 0 1\r\nownhero:\r\ndruid 16 30 0 False False 4 True 0 False 0 0\r\nweapon: 0 0 unknown\r\nability: True CS2_017\r\nosecrets: \r\nenemyhero:\r\ndruid 29 30 1 False False 40\r\nweapon: 0 0 unknown\r\nability: true CS2_017\r\nfatigue: 16 0 19 0\r\nOwnMinions:\r\nimp EX1_598 zp:1 e:80 A:1 H:1 mH:1 rdy:True natt:0\r\nfrostwolfwarlord CS2_226 zp:2 e:35 A:8 H:8 mH:8 rdy:True natt:0\r\nrazorfenhunter CS2_196 zp:3 e:31 A:2 H:3 mH:3 rdy:True natt:0\r\nboar CS2_boar zp:4 e:85 A:1 H:1 mH:1 rdy:True natt:0\r\nEnemyMinions:\r\nrivercrocolisk CS2_120 zp:1 e:48 A:2 H:3 mH:3 rdy:False ex ptt\r\nsilverbackpatriarch CS2_127 zp:2 e:57 A:1 H:1 mH:4 rdy:True ex tnt\r\noasissnapjaw CS2_119 zp:3 e:67 A:2 H:1 mH:7 rdy:True ex\r\nnightblade EX1_593 zp:4 e:53 A:4 H:2 mH:4 rdy:True ex\r\nnightblade EX1_593 zp:5 e:52 A:4 H:4 mH:4 rdy:False ex ptt\r\nOwn Handcards: \r\npos 1 dragonlingmechanic 4 entity 13 EX1_025\r\npos 2 savageroar 3 entity 22 CS2_011\r\npos 3 frostwolfwarlord 5 entity 19 CS2_226\r\npos 4 harvestgolem 3 entity 33 EX1_556\r\npos 5 harvestgolem 3 entity 17 EX1_556\r\npos 6 knifejuggler 2 entity 18 NEW1_019\r\nEnemy cards: 3\r\nownDiedMinions: \r\nenemyDiedMinions: \r\nog: \r\neg: <EoF>";
        static string board3000 = "\r\n#######################################################################\r\n#######################################################################\r\nstart calculations, current time: 04:04:19:3829 V112.3 rush 3000 twoturnsim 256 ntss 6 30 50 ets 50 simEnemy2Turn ents 50\r\n#######################################################################\r\nmana 8/8\r\nemana 8\r\nown secretsCount: 0\r\nenemy secretsCount: 0\r\nplayer:\r\n0 0 0 1\r\nownhero:\r\ndruid 16 30 0 False False 4 True 0 False 0 0\r\nweapon: 0 0 unknown\r\nability: True CS2_017\r\nosecrets: \r\nenemyhero:\r\ndruid 29 30 1 False False 40\r\nweapon: 0 0 unknown\r\nability: true CS2_017\r\nfatigue: 16 0 19 0\r\nOwnMinions:\r\nimp EX1_598 zp:1 e:80 A:1 H:1 mH:1 rdy:True natt:0\r\nfrostwolfwarlord CS2_226 zp:2 e:35 A:8 H:8 mH:8 rdy:True natt:0\r\nrazorfenhunter CS2_196 zp:3 e:31 A:2 H:3 mH:3 rdy:True natt:0\r\nboar CS2_boar zp:4 e:85 A:1 H:1 mH:1 rdy:True natt:0\r\nEnemyMinions:\r\nrivercrocolisk CS2_120 zp:1 e:48 A:2 H:3 mH:3 rdy:False ex ptt\r\nsilverbackpatriarch CS2_127 zp:2 e:57 A:1 H:1 mH:4 rdy:True ex tnt\r\noasissnapjaw CS2_119 zp:3 e:67 A:2 H:1 mH:7 rdy:True ex\r\nnightblade EX1_593 zp:4 e:53 A:4 H:2 mH:4 rdy:True ex\r\nnightblade EX1_593 zp:5 e:52 A:4 H:4 mH:4 rdy:False ex ptt\r\nOwn Handcards: \r\npos 1 dragonlingmechanic 4 entity 13 EX1_025\r\npos 2 savageroar 3 entity 22 CS2_011\r\npos 3 frostwolfwarlord 5 entity 19 CS2_226\r\npos 4 harvestgolem 3 entity 33 EX1_556\r\npos 5 harvestgolem 3 entity 17 EX1_556\r\npos 6 knifejuggler 2 entity 18 NEW1_019\r\nEnemy cards: 3\r\nownDiedMinions: \r\nenemyDiedMinions: \r\nog: \r\neg: <EoF>";
        static string board7000 = "\r\n#######################################################################\r\n#######################################################################\r\nstart calculations, current time: 04:04:19:3829 V112.3 rush 7000 twoturnsim 256 ntss 6 30 50 ets 50 simEnemy2Turn ents 50\r\n#######################################################################\r\nmana 8/8\r\nemana 8\r\nown secretsCount: 0\r\nenemy secretsCount: 0\r\nplayer:\r\n0 0 0 1\r\nownhero:\r\ndruid 16 30 0 False False 4 True 0 False 0 0\r\nweapon: 0 0 unknown\r\nability: True CS2_017\r\nosecrets: \r\nenemyhero:\r\ndruid 29 30 1 False False 40\r\nweapon: 0 0 unknown\r\nability: true CS2_017\r\nfatigue: 16 0 19 0\r\nOwnMinions:\r\nimp EX1_598 zp:1 e:80 A:1 H:1 mH:1 rdy:True natt:0\r\nfrostwolfwarlord CS2_226 zp:2 e:35 A:8 H:8 mH:8 rdy:True natt:0\r\nrazorfenhunter CS2_196 zp:3 e:31 A:2 H:3 mH:3 rdy:True natt:0\r\nboar CS2_boar zp:4 e:85 A:1 H:1 mH:1 rdy:True natt:0\r\nEnemyMinions:\r\nrivercrocolisk CS2_120 zp:1 e:48 A:2 H:3 mH:3 rdy:False ex ptt\r\nsilverbackpatriarch CS2_127 zp:2 e:57 A:1 H:1 mH:4 rdy:True ex tnt\r\noasissnapjaw CS2_119 zp:3 e:67 A:2 H:1 mH:7 rdy:True ex\r\nnightblade EX1_593 zp:4 e:53 A:4 H:2 mH:4 rdy:True ex\r\nnightblade EX1_593 zp:5 e:52 A:4 H:4 mH:4 rdy:False ex ptt\r\nOwn Handcards: \r\npos 1 dragonlingmechanic 4 entity 13 EX1_025\r\npos 2 savageroar 3 entity 22 CS2_011\r\npos 3 frostwolfwarlord 5 entity 19 CS2_226\r\npos 4 harvestgolem 3 entity 33 EX1_556\r\npos 5 harvestgolem 3 entity 17 EX1_556\r\npos 6 knifejuggler 2 entity 18 NEW1_019\r\nEnemy cards: 3\r\nownDiedMinions: \r\nenemyDiedMinions: \r\nog: \r\neg: <EoF>";
        static string board9000 = "\r\n#######################################################################\r\n#######################################################################\r\nstart calculations, current time: 04:04:19:3829 V112.3 rush 9000 twoturnsim 256 ntss 6 30 50 ets 50 simEnemy2Turn ents 50\r\n#######################################################################\r\nmana 8/8\r\nemana 8\r\nown secretsCount: 0\r\nenemy secretsCount: 0\r\nplayer:\r\n0 0 0 1\r\nownhero:\r\ndruid 16 30 0 False False 4 True 0 False 0 0\r\nweapon: 0 0 unknown\r\nability: True CS2_017\r\nosecrets: \r\nenemyhero:\r\ndruid 29 30 1 False False 40\r\nweapon: 0 0 unknown\r\nability: true CS2_017\r\nfatigue: 16 0 19 0\r\nOwnMinions:\r\nimp EX1_598 zp:1 e:80 A:1 H:1 mH:1 rdy:True natt:0\r\nfrostwolfwarlord CS2_226 zp:2 e:35 A:8 H:8 mH:8 rdy:True natt:0\r\nrazorfenhunter CS2_196 zp:3 e:31 A:2 H:3 mH:3 rdy:True natt:0\r\nboar CS2_boar zp:4 e:85 A:1 H:1 mH:1 rdy:True natt:0\r\nEnemyMinions:\r\nrivercrocolisk CS2_120 zp:1 e:48 A:2 H:3 mH:3 rdy:False ex ptt\r\nsilverbackpatriarch CS2_127 zp:2 e:57 A:1 H:1 mH:4 rdy:True ex tnt\r\noasissnapjaw CS2_119 zp:3 e:67 A:2 H:1 mH:7 rdy:True ex\r\nnightblade EX1_593 zp:4 e:53 A:4 H:2 mH:4 rdy:True ex\r\nnightblade EX1_593 zp:5 e:52 A:4 H:4 mH:4 rdy:False ex ptt\r\nOwn Handcards: \r\npos 1 dragonlingmechanic 4 entity 13 EX1_025\r\npos 2 savageroar 3 entity 22 CS2_011\r\npos 3 frostwolfwarlord 5 entity 19 CS2_226\r\npos 4 harvestgolem 3 entity 33 EX1_556\r\npos 5 harvestgolem 3 entity 17 EX1_556\r\npos 6 knifejuggler 2 entity 18 NEW1_019\r\nEnemy cards: 3\r\nownDiedMinions: \r\nenemyDiedMinions: \r\nog: \r\neg: <EoF>";
        static string board14000 = "\r\n#######################################################################\r\n#######################################################################\r\nstart calculations, current time: 04:04:19:3829 V112.3 rush 14000 twoturnsim 256 ntss 6 30 50 ets 50 simEnemy2Turn ents 50\r\n#######################################################################\r\nmana 8/8\r\nemana 8\r\nown secretsCount: 0\r\nenemy secretsCount: 0\r\nplayer:\r\n0 0 0 1\r\nownhero:\r\ndruid 16 30 0 False False 4 True 0 False 0 0\r\nweapon: 0 0 unknown\r\nability: True CS2_017\r\nosecrets: \r\nenemyhero:\r\ndruid 29 30 1 False False 40\r\nweapon: 0 0 unknown\r\nability: true CS2_017\r\nfatigue: 16 0 19 0\r\nOwnMinions:\r\nimp EX1_598 zp:1 e:80 A:1 H:1 mH:1 rdy:True natt:0\r\nfrostwolfwarlord CS2_226 zp:2 e:35 A:8 H:8 mH:8 rdy:True natt:0\r\nrazorfenhunter CS2_196 zp:3 e:31 A:2 H:3 mH:3 rdy:True natt:0\r\nboar CS2_boar zp:4 e:85 A:1 H:1 mH:1 rdy:True natt:0\r\nEnemyMinions:\r\nrivercrocolisk CS2_120 zp:1 e:48 A:2 H:3 mH:3 rdy:False ex ptt\r\nsilverbackpatriarch CS2_127 zp:2 e:57 A:1 H:1 mH:4 rdy:True ex tnt\r\noasissnapjaw CS2_119 zp:3 e:67 A:2 H:1 mH:7 rdy:True ex\r\nnightblade EX1_593 zp:4 e:53 A:4 H:2 mH:4 rdy:True ex\r\nnightblade EX1_593 zp:5 e:52 A:4 H:4 mH:4 rdy:False ex ptt\r\nOwn Handcards: \r\npos 1 dragonlingmechanic 4 entity 13 EX1_025\r\npos 2 savageroar 3 entity 22 CS2_011\r\npos 3 frostwolfwarlord 5 entity 19 CS2_226\r\npos 4 harvestgolem 3 entity 33 EX1_556\r\npos 5 harvestgolem 3 entity 17 EX1_556\r\npos 6 knifejuggler 2 entity 18 NEW1_019\r\nEnemy cards: 3\r\nownDiedMinions: \r\nenemyDiedMinions: \r\nog: \r\neg: <EoF>";
        
     }
}
