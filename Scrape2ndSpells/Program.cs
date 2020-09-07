using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenQA.Selenium.Support.UI;
using Scrape2ndSpells.DataModels;
using Scrape2ndSpells.Managers;
using Scrape2ndSpells.Maps;
using SeleniumLibrary;
using VTFileSystemManagement;

namespace Scrape2ndSpells
{
    public class Program : SeleniumBase
    {
        static void Main(string[] args) => StartMain().GetAwaiter().GetResult();

        public static async Task StartMain()
        {
            var kickOff = new ScrapeVodaBoisManager().CollectSpells();
            await Task.Delay(-1);
        }
    }
}
