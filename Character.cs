using mis321_pa4.Interfaces;
namespace mis321_pa4
{
    public class Character
    {
        public string CharacterName {get; set;}
        public string Name {get; set;}
        public int MaxPower {get; set;}
        public double Health {get; set;}
        public int AttackStrength {get; set;}
        public int DefensePower {get; set;}
        public IAttack attackBehavior {get; set;}

        public Character(){

        }

        public void SetAttackBehavior(IAttack attackBehavior){
            this.attackBehavior = attackBehavior;
        }

        public static int GetMaxPower(){
            Random randomNum = new Random();
            int randomPower = randomNum.Next (1,101);
            return randomPower;
        }

        public static int GetAttackStrength(int MaxPower){
            Random randomNum = new Random();
            int randomAttack = randomNum.Next (1,MaxPower);
            return randomAttack;
        }

        public static int GetDefendStrength(int MaxPower){
            Random randomNum = new Random();
            int randomDefend = randomNum.Next (1,MaxPower);
            return randomDefend;
        }
            
    }
}