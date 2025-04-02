using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System.Linq;
using DataAccess.Concrete.EntityFramework;

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
