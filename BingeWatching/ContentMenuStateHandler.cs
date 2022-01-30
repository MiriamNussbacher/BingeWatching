using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BingeWatching
{
    public class ContentMenuStateHandler : IMenuStateHandler
    {
        
        private static readonly HttpClient client = new HttpClient();

        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.Content;
        }

        public async void Handle()
        {
            ContentMenu contentMenu = GetMenuState();

            string content_kind=string.Empty;

            switch (contentMenu)
            {
                case ContentMenu.Any:
                    {
                        content_kind = "both";
                        break;
                    }
                case ContentMenu.Movie:
                    {
                        content_kind = "movie";
                        break;
                    }
                case ContentMenu.TVShow:
                    {
                        content_kind = "show";
                        break;
                    }
                default: break;

            }
            bool toContinue = true;
            NetflixItem netflixItem = null;
            while (toContinue)
            {
                string url = $"https://api.reelgood.com/v3.0/content/random?availability=onAnySource&content_kind={content_kind}&nocache=true&region=us&sources=netflix";
          
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                string responseString = responseContent.ReadAsStringAsync().Result;
                 netflixItem = JsonSerializer.Deserialize<NetflixItem>(responseString);
            }


           
                 toContinue = !Menu.currentUser.foundInHistory(netflixItem.id);
            }
            Console.WriteLine($"You are now watching {netflixItem.Title}");
            HandleInput.HandleEndOfWatching();
                   
            netflixItem.UserRanking = HandleInput.handleRankRange();
            Menu.currentUser.saveToHistory(netflixItem);
    

            

        }

        private ContentMenu GetMenuState()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Binge Watching menu");
                Console.WriteLine("---------------------------------------------------------------------");

                Console.Write("|  ");
                var allMenuStates = GetAllPossibleContentMenu();
                foreach (ContentMenu menuState in allMenuStates)
                {
                    Console.Write($"{Char.ToLower((char)menuState)} - {menuState}  |  ");
                }

                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Hit the relevant menu key.");

                var choice = char.ToUpperInvariant(Console.ReadKey().KeyChar);
                Console.WriteLine();
                var menuStateChoice = (ContentMenu)Enum.ToObject(typeof(ContentMenu), choice);
                if (allMenuStates.Contains(menuStateChoice))
                {
                    return menuStateChoice;
                }

                Console.WriteLine("Invalid Choice! - Please choose again");
            }
        }

        private ContentMenu[] GetAllPossibleContentMenu() =>
           (ContentMenu[])Enum.GetValues(typeof(ContentMenu));
    }
}