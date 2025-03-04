using Fiddler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fortnite_Cosmetics_Unlocker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "profiles")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "profiles"));
            }

            WebClient webClient = new WebClient();

            Console.WriteLine("Downloading athena.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/athena.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "athena.json"));

            Console.WriteLine("Downloading campaign.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/campaign.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "campaign.json"));

            Console.WriteLine("Downloading collection_book_people0.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/collection_book_people0.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "collection_book_people0.json"));

            Console.WriteLine("Downloading collection_book_schematics0.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/collection_book_schematics0.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "collection_book_schematics0.json"));

            Console.WriteLine("Downloading collections.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/collections.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "collections.json"));

            Console.WriteLine("Downloading common_core.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/common_core.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "common_core.json"));

            Console.WriteLine("Downloading common_public.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/common_public.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "common_public.json"));

            Console.WriteLine("Downloading creative.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/creative.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "creative.json"));

            Console.WriteLine("Downloading metadata.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/metadata.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "metadata.json"));

            Console.WriteLine("Downloading outpost0.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/outpost0.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "outpost0.json"));

            Console.WriteLine("Downloading recycle_bin.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/recycle_bin.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "recycle_bin.json"));

            Console.WriteLine("Downloading theater0.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/theater0.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "theater0.json"));

            Console.WriteLine("Downloading theater1.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/theater1.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "theater1.json"));

            Console.WriteLine("Downloading theater2.json...");
            webClient.DownloadFile("https://sakurafn.pages.dev/hybrid/profile_template/theater2.json", Path.Combine(Directory.GetCurrentDirectory(), "profiles", "theater2.json"));

            Console.Clear();
            Console.WriteLine("Welcome to Marcalachu hybrid Made by Marcalachu");
            Console.WriteLine("copyright 2025 by Marcalachu©");
            if (!Fiddler.Setup())
            {
                return;
            }

            FiddlerCoreStartupSettings startupSettings = new FiddlerCoreStartupSettingsBuilder().ListenOnPort(9999).DecryptSSL().RegisterAsSystemProxy().Build();

            FiddlerApplication.BeforeRequest += OnBeforeRequest;
            FiddlerApplication.BeforeResponse += OnBeforeResponse;

            Console.WriteLine("Starting fiddler application");
            FiddlerApplication.Startup(startupSettings);

            Backend.Listen();
            Console.WriteLine("Listening to backend");

            Console.WriteLine("Launch Fortnite from Epic Games Launcher");

            Console.WriteLine("To exit, press any key in this window to exit");
            Console.ReadKey(true);

            Console.WriteLine("Shutting down fiddler application");
            FiddlerApplication.Shutdown();

            Environment.Exit(0);
        }

        private static void OnBeforeRequest(Session session)
        {
            if (session.RequestHeaders["User-Agent"].Split('/')[0] == "Fortnite")
            {
                if (session.PathAndQuery.StartsWith("/lightswitch/api/service/") || session.PathAndQuery.StartsWith("/fortnite/api/game/v2/profile/") || session.PathAndQuery.StartsWith("/api/locker/v4/"))
                {
                    session.fullUrl = "http://localhost:1911" + session.PathAndQuery;
                }
            }
        }

        private static void OnBeforeResponse(Session session)
        {

        }
    }
}
