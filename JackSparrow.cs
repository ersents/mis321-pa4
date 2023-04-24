using mis321_pa4.Interfaces;
namespace mis321_pa4
{
    public class JackSparrow : Character
    {
       public JackSparrow(){
            attackBehavior = new Distract();
       } 
    }
}