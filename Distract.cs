using mis321_pa4.Interfaces;
namespace mis321_pa4
{
    public class Distract : IAttack
    {
        public void Attack(){
            System.Console.WriteLine("Jack Sparrow used Distract Opponent");
        }
    }
}