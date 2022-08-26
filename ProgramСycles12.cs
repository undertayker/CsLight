using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Program1
    {
        static void Main(string[] args)
        {

            float playerHealth = 1000;
            float bossHealth = 1000;
            float bossDamage = 200;
            float soulEater = 300;
            float deathScythe = 150;
            float shadowCircle = 150;
            float callOfTheUnbelievers = 300;
            float maximumPlayerTreatment = 1;
            bool playerTreatment = false;
            float maximumSoulSacrifice = 1;
            bool playerSacrifice = false;

            string userInput;
            string spell1 = "1";
            string spell2 = "2";
            string spell3 = "3";
            string spell4 = "4";

            Console.WriteLine("Вы - ЖНЕЦ, пожиратель смерти, для поиска еще большей силы вы спустились в подземелье. ");
            Console.WriteLine("И вот вы наткнулись на покои босса!!\nИ что же там вас ждет? заветная мечта или смерть, решать вам!");
            Console.WriteLine("В вашем арсенале 4 заклинания, что бы выжить используйте их с умом!");
            Console.WriteLine($"Ваше здоровье - {playerHealth}. Здоровье босса {bossHealth}\nВаши заклинания : ");            

            while (playerHealth > 0 && bossHealth > 0)
            {

                Console.WriteLine($"1. Пожиратель душ - Вы жертвуете часть своего здоровья темному богу\nБлагодаря этому вы можете призывать группу нежети которые помогут вам разобраться с боссом\nУрон игроку - {soulEater} ");
                Console.WriteLine($"2. Коса смерти - бьете босса рассекающим ударом косы нанося ему - {deathScythe} урона ");
                Console.WriteLine($"3. Круг теней - вы призываете призраков из загробного мира, которые восстанавливают вам - {shadowCircle} хп\nНо будьте осторожны призыв может получится только единажды");
                Console.WriteLine($"4. Призыв нежети - вы призываете из загробного мира группу нежети, которая помогает вам в сражении, урон от нежити - {callOfTheUnbelievers} ");
                userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "1":
                        if (maximumSoulSacrifice > 0)
                        {
                            playerSacrifice = true;
                            maximumSoulSacrifice--;
                            playerHealth -= soulEater;

                            Console.WriteLine($"Ты выбрал пожиратель душ и пожертвовал часть своего здороья в размере {soulEater} единиц загробному миру, но это жертва не напрасна, тебе откроется могущественное заклинание призыва ");
                            Console.WriteLine($"Ваше здоровье  {playerHealth}. Здоровье босса {bossHealth}\nНажмите Enter для возврата к заклинаниям");
                            Console.ReadLine();
                            break;

                        }
                        else
                        {
                            Console.WriteLine($"К сожалению ты уже истратил попытки призыва, призыв не возможет\nУ тебя осталось {maximumSoulSacrifice} попыток ");
                            Console.WriteLine($"Ваше здоровье  {playerHealth}. Здоровье босса {bossHealth}\nНажмите Enter для возврата к заклинаниям");
                            Console.ReadLine();
                            break;
                        }

                    case "2":

                        playerHealth -= bossDamage;
                        bossHealth -= deathScythe;

                        Console.WriteLine($"ты выбрал косу смерти, не плохой выбор, ты нанес боссу урон в кол-ве {deathScythe} единиц, но не обольщайся босс так же нанес тебе урон, который составляет {bossDamage} единиц ");
                        Console.WriteLine($"Ваше здоровье  {playerHealth}. Здоровье босса {bossHealth}\nНажмите Enter для возврата к заклинаниям");
                        Console.ReadLine();
                        break;

                    case "3":

                        if (maximumPlayerTreatment > 0)
                        {
                            playerTreatment = true;
                            maximumPlayerTreatment--;
                            playerHealth += shadowCircle;

                            Console.WriteLine($"Ты выбрал круг теней, из загробного мира поднимаются духи и отдают тебе чаcть своей жизни, ты восстонавил - {shadowCircle} хп, но будь аккуратен это заклинание можно использовать только единожды! ");
                            Console.WriteLine($"Ваше здоровье  {playerHealth}. Здоровье босса {bossHealth}\nНажмите Enter для возврата к заклинаниям");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("К сожалению ты уже истратил данное заклинание, лечение не возможно ");
                            Console.WriteLine($"Ваше здоровье  {playerHealth}. Здоровье босса {bossHealth}\nНажмите Enter для возврата к заклинаниям");
                            Console.ReadLine();
                            break;
                        }

                    case "4":

                        if (playerSacrifice == true)
                        {
                            playerSacrifice = true;
                            bossHealth -= callOfTheUnbelievers;
                            playerHealth -= bossDamage;
                            Console.WriteLine($"Ты выбрал призыв нежети, призвал воинов скилетов которые наносят боссу {callOfTheUnbelievers} единиц урона ");
                            Console.WriteLine($"Ваше здоровье  {playerHealth}. Здоровье босса {bossHealth}\nНажмите Enter для возврата к заклинаниям");
                            Console.ReadLine();
                        }   
                        else if (playerSacrifice == false)
                        {
                            Console.WriteLine("К сожалению вы не можете использовать данное заклинание так как еще не принисли жертву");
                            Console.WriteLine($"Ваше здоровье  {playerHealth}. Здоровье босса {bossHealth}\nНажмите Enter для возврата к заклинаниям");
                            Console.ReadLine();
                        }                       
                        break;
                    default:
                        Console.WriteLine("Вы еще не повысили свой уровень знания для такого заклинания, такое заклинание недоступно ");
                        break;
                }
            }
            if (playerSacrifice = true && maximumSoulSacrifice <= 0)
            {
                playerSacrifice = false;
            }

            if (playerTreatment = true && maximumPlayerTreatment <= 0)
            {
                playerTreatment = false;
            }
            if (bossHealth <= 0 && playerHealth <= 0)
            {
                Console.WriteLine("Была ожесточенная схватка из которой никто не вышел победителем ");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("Босс повержен, наконец-то вы смогли достич своей цели и получить заветное");
            }

            else if (playerHealth <= 0)
            {
                Console.WriteLine("К сожалению вы погибли, так и не достигнули своей цели (((");
            }
        }
    }
}






