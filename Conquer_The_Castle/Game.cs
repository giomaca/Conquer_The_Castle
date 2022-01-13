using System;

namespace Conquer_The_Castle
{
    class Game
    {
        private int enemy;
        private int wayLength;
        private Character[] way;
        private Player player;
        private bool game = true;

        public Game(int wayLength, int enemy)
        {
            this.wayLength = wayLength;
            if (enemy < wayLength)
            {
                this.enemy = enemy;
            }

            way = new Character[wayLength];
            for (int i = 0; i < wayLength; i++)
                way[i] = null;
        }

        public void SetPosition()
        {
            Random rand = new Random();
            int indx;
            for (int i = 0; i < enemy; i++)
            {
                while (true)
                {
                    indx = rand.Next(1, wayLength);
                    if (way[indx] == null)
                    {
                        Random random = new Random();
                        int r = random.Next(2);
                        if (r == 0)
                        {
                            way[indx] = new Archer();
                        }
                        else
                        {
                            way[indx] = new Melee();
                        }
                        break;
                    }
                }
            }

            for (int i = 0; i < enemy / 2; i++)
            {
                while (true)
                {
                    indx = rand.Next(1, wayLength);
                    if (way[indx] == null)
                    {
                        way[indx] = new Heal();
                        break;
                    }
                }
            }
        }

        public void Play()
        {
            player = new Player();
            for (int i = 0; i < way.Length; i++)
            {
                Console.WriteLine($"{i + 1} step");
                Console.ReadKey();
                if (way[i] != null && way[i].GetType() == typeof(Heal))
                {
                    Heal heal = (Heal)way[i];
                    if (player.Healthy < 100)
                    {
                        int healing = heal.Healing();
                        player.GetHeal(healing);
                        Console.WriteLine($"You healed. Your healthy increased by {heal.Healing()} now is {player.Healthy}");
                    }

                }
                way[i] = player;

                if ((i < way.Length - 1) && way[i + 1] != null && (i + 1) - i <= way[i + 1].AttackRange && way[i + 1].GetType() != typeof(Heal))
                {
                    Battle(player, way[i + 1]);
                }
                else if ((i < way.Length - 2) && way[i + 2] != null && (i + 2) - i <= way[i + 2].AttackRange && way[i + 2].GetType() != typeof(Heal))
                {
                    BattleWithArcher(player, way[i + 2]);
                }
                else if ((i < way.Length - 3) && way[i + 3] != null && (i + 3) - i <= way[i + 3].AttackRange && way[i + 3].GetType() != typeof(Heal))
                {
                    BattleWithArcher(player, way[i + 3]);
                }
                if (!game)
                    return;
            }
            Console.WriteLine("You Won. You Reach the castle");
        }

        public void BattleWithArcher(Player player, Character character)
        {
            int pAt = 0;
            int cAt;

            Console.WriteLine($"The archer {character.GetType().Name} start shooting");
            //Console.WriteLine("Attack the enemy. Press Enter");
            //Console.ReadKey();

            cAt = character.Attack();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Player's heal: {player.Healthy}. Attack: {pAt}");
            Console.WriteLine($"{character.GetType().Name}'s heal: {character.Healthy}. Attack: {cAt}");

            if (player.IsAlive())
                player.GetDamage(cAt);

            Console.WriteLine($"Player's remaining heal: {player.Healthy}");
            Console.WriteLine($"{character.GetType().Name}'s remaining heal: {character.Healthy}");
            Console.WriteLine("---------------------------------------------");
        }

        public void Battle(Player player, Character character)
        {
            int pAt;
            int cAt;
            Console.WriteLine($"You meet the {character.GetType().Name}");
            while (player.IsAlive() && character.IsAlive())
            {
                Console.WriteLine("Attack the enemy. Press Enter");
                Console.ReadKey();

                pAt = player.Attack();
                cAt = character.Attack();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Player's heal: {player.Healthy}. Attack: {pAt}");
                Console.WriteLine($"{character.GetType().Name}'s heal: {character.Healthy}. Attack: {cAt}");

                character.GetDamage(pAt);
                if (character.IsAlive())
                    player.GetDamage(cAt);

                Console.WriteLine($"Player's remaining heal: {player.Healthy}");
                Console.WriteLine($"{character.GetType().Name}'s remaining heal: {character.Healthy}");
                Console.WriteLine("---------------------------------------------");
            }
            if (player.IsAlive())
                Console.WriteLine("You defeated the enemy");
            else
                GameOver();
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Your healty: {player.Healthy}");
        }

        public void GameOver()
        {
            game = false;
            Console.WriteLine("Game Over. You lost");
        }
    }
}
