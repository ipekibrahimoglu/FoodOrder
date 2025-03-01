using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System.Linq;

namespace ConsoleUI
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            MenuManager menuManager = new MenuManager(new InMemoryMenuDal());
            foreach (var menu in await menuManager.GetAllASync())
            {
                Console.WriteLine(menu.Name);
            }
        }
    }
}
