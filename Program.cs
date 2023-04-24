using mis321_pa4.Interfaces;
namespace mis321_pa4{

class Program
{
   
    static void Main(string[] args){
         
//Main



System.Console.WriteLine("Welcome to the Battle of Calypso's maelstorm");
Console.BackgroundColor = ConsoleColor.Black;
Character player1 = new Character();
Character player2 = new Character();

player1 = createPlayer();
player2 = createPlayer();

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
System.Console.WriteLine("Player 1 stats:");
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
System.Console.WriteLine($"Player: {player1.Name}");
System.Console.WriteLine($"Character: {player1.CharacterName}");
System.Console.WriteLine($"Max Power: {player1.MaxPower}");
System.Console.WriteLine($"Health: {player1.Health}");
Console.ForegroundColor = ConsoleColor.Red;
System.Console.WriteLine($"Attack Strength: {player1.AttackStrength}");
Console.ForegroundColor = ConsoleColor.Green;
System.Console.WriteLine($"Defensive Strength: {player1.DefensePower}");
Console.ForegroundColor = ConsoleColor.White;
System.Console.WriteLine("");

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
System.Console.WriteLine("Player 2 stats:");
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
System.Console.WriteLine($"Player: {player2.Name}");
System.Console.WriteLine($"Character: {player2.CharacterName}");
System.Console.WriteLine($"Max Power: {player2.MaxPower}");
System.Console.WriteLine($"Health: {player2.Health}");
Console.ForegroundColor = ConsoleColor.Red;
System.Console.WriteLine($"Attack Strength: {player2.AttackStrength}");
Console.ForegroundColor = ConsoleColor.Green;
System.Console.WriteLine($"Defensive Strength: {player2.DefensePower}");
Console.ForegroundColor = ConsoleColor.White;
System.Console.WriteLine("");

bool randStart = GetFirstTurn();
GamePlay(randStart, player1, player2);
DisplayWinner(player1, player2);
System.Console.WriteLine("");

}



static Character createPlayer(){
    Character temp = new Character();
    
    System.Console.WriteLine("Player's name:");
    string playerName = Console.ReadLine();
    CharacterMenu menuChoice = new CharacterMenu();
    string characterChoice = menuChoice.GetCharacter();

    Random randomNum = new Random();
    int randomPower = Character.GetMaxPower();
    
    switch(characterChoice){
        case "1": 
            temp = new WillTurner(){Name = playerName, CharacterName = "Will Turner", MaxPower = randomPower, Health = 100, AttackStrength = Character.GetAttackStrength(randomPower), DefensePower = Character.GetDefendStrength(randomPower)};
            break;
        case "2": 
            temp = new JackSparrow(){Name = playerName, CharacterName = "Jack Sparrow", MaxPower = randomPower, Health = 100, AttackStrength = Character.GetAttackStrength(randomPower), DefensePower = Character.GetDefendStrength(randomPower)};
            break;
        case "3": 
            temp = new DavyJones(){Name = playerName, CharacterName = "Davy Jones", MaxPower = randomPower, Health = 100, AttackStrength = Character.GetAttackStrength(randomPower), DefensePower = Character.GetDefendStrength(randomPower)};
            break;

    }
    Console.Clear();
    System.Console.WriteLine("");
    return temp;
}



static bool GetFirstTurn(){
    Random randomNum = new Random();
    int firstTurn = randomNum.Next(1,7);
    bool randStart = false;
    if((firstTurn == 1) || (firstTurn == 3) || (firstTurn == 5)){
        randStart = true;
        System.Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("Player 1 starts");
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("");
    }
    else{
        System.Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("Player 2 starts");
        Console.ForegroundColor = ConsoleColor.White; 
        System.Console.WriteLine("");   
        }
    return randStart;
    }

static void GamePlay(bool randStart, Character player1, Character player2){
    while((player1.Health > 0) && (player2.Health > 0)){
        if(randStart == true){
            player1.attackBehavior.Attack();
            CharacterDamage(randStart, player1, player2);
            randStart = false;
        }
        else{
            player2.attackBehavior.Attack();
            CharacterDamage(randStart, player1, player2);
            randStart=true;
        }

        player1.AttackStrength = Character.GetAttackStrength(player1.MaxPower);
        player1.DefensePower = Character.GetDefendStrength(player1.MaxPower);
        player2.AttackStrength = Character.GetAttackStrength(player2.MaxPower);
        player2.DefensePower = Character.GetDefendStrength(player2.MaxPower);
    }
}

static void CharacterDamage(bool randStart, Character player1, Character player2){
    double typeBoost = 1;
    if(randStart == true)
    {
        if(((player1.CharacterName == "Jack Sparrow") && (player2.CharacterName == "Will Turner")) || ((player1.CharacterName == "Will Turner") && (player2.CharacterName == "Davy Jones")) || ((player1.CharacterName == "Davy Jones") && (player2.CharacterName == "Jack Sparrow"))){
            System.Console.WriteLine($"{player1.CharacterName} attack + 20%");
            typeBoost = 1.2;
        }
        double damInflicted = ((player1.AttackStrength - player2.DefensePower) * (typeBoost));
        if(damInflicted>0){
            player2.Health -=damInflicted;
            System.Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"Player 2's damage taken: -{damInflicted}");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("");
        }
        else if(damInflicted < 0){
            System.Console.WriteLine("");
            System.Console.WriteLine("No damage taken");
            System.Console.WriteLine("");
        }
    }
    else{
        if(((player2.CharacterName == "Jack Sparrow") && (player1.CharacterName == "Will Turner")) || ((player1.CharacterName == "Will Turner") && (player1.CharacterName == "Davy Jones")) || ((player2.CharacterName == "Davy Jones") && (player2.CharacterName == "Jack Sparrow"))){
            System.Console.WriteLine($"{player2.CharacterName} attack + 20%");
            typeBoost = 1.2;
    }
    double damInflicted = ((player1.AttackStrength - player2.DefensePower) * (typeBoost));
        if(damInflicted>0){
            player1.Health -=damInflicted;
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("");
            System.Console.WriteLine($"Player 1's damage taken: -{damInflicted}");
            Console.ForegroundColor=ConsoleColor.White;
            System.Console.WriteLine("");
        }
        else if(damInflicted < 0){
            System.Console.WriteLine("");
            System.Console.WriteLine("No damage taken");
            System.Console.WriteLine("");
        }
    }
    CharacterStats(player1,player2);
}

static void CharacterStats(Character player1, Character player2){
    System.Console.WriteLine("");
    System.Console.WriteLine("Player 1:");
    System.Console.WriteLine($"Health: {player1.Health}");
    System.Console.WriteLine("Player 2:");
    System.Console.WriteLine($"Health: {player2.Health}");
    System.Console.WriteLine("");
}

static void DisplayWinner(Character player1, Character player2){
    
    if(player1.Health>0){
       
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("");
            System.Console.WriteLine($"{player1.Name} wins");
            System.Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
            
        Console.ResetColor();
        System.Console.WriteLine("");
        System.Console.WriteLine($"{player1.Name} wins with {player1.CharacterName}");
        System.Console.WriteLine($"{player1.CharacterName}'s health was {player1.Health}");

    }
    else if(player2.Health>0){
        
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("");
            System.Console.WriteLine($"{player2.Name} wins");
            System.Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
           
        
        Console.ResetColor();
        System.Console.WriteLine("");
        System.Console.WriteLine($"{player2.Name} wins with {player2.CharacterName}");
        System.Console.WriteLine($"{player2.CharacterName}'s health was {player2.Health}");
    }
}
}
}

