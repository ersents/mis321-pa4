using mis321_pa4.Interfaces;
namespace mis321_pa4
{
    public class DavyJones : Character
    {
        public DavyJones(){
            attackBehavior = new CannonFire();
        }
    }
}