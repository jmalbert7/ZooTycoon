using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTycoon
{
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
