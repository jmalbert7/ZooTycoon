using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTycoon
{
    public interface IEvent
    {
        void DisplayEventNameAndDescription();
        void RunEvent();
    }
    public class Sickness : IEvent
    {
        public void DisplayEventNameAndDescription()
        {
            throw new System.NotImplementedException();
        }

        public void RunEvent()
        {
            throw new System.NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {            
            var game = new Game();
            game.StartGame();

            bool play;
            do
            {
                play = game.RunGame();
            } while (play == true);

            game.EndGame();
        }
    }
}
