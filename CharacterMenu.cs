
namespace mis321_pa4
{
    public class CharacterMenu
    {
        public string GetCharacter(){
            System.Console.WriteLine("Select your character:");
            System.Console.WriteLine("1. Will Turner");
            System.Console.WriteLine("2. Jack Sparrow");
            System.Console.WriteLine("3. Davy Jones");
            

            string characterChoice = Console.ReadLine();

            
            while((characterChoice !="1") && (characterChoice !="2") && (characterChoice !="3"))
            {
                System.Console.WriteLine("Error, try again");
                characterChoice = Console.ReadLine();
            }
            return characterChoice;
        }
    }
}