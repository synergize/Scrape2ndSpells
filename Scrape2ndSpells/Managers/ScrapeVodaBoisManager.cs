using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using OpenQA.Selenium.Support.UI;
using Scrape2ndSpells.DataModels;
using Scrape2ndSpells.Maps;
using SeleniumLibrary;
using VTFileSystemManagement;

namespace Scrape2ndSpells.Managers
{
    public class ScrapeVodaBoisManager : SeleniumBase
    {
        private static int Wizard = 511;
        private static int Priest = 373;

        public List<Spell> CollectSpells()
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            WebDriver.Navigate().GoToUrl(new Uri("https://vodabois.fi/2eSpells/"));
            WebDriver.Manage().Window.Maximize();
            var listOfSpells = new List<Spell>();
            try
            {
                for (var i = 0; i < Priest; i++)
                {
                    var targetSpell = WebDriver.FindElement(SpellObjects.BtnSpell(i));
                    JavaExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", targetSpell);
                    targetSpell.Click();
                    Thread.Sleep(300);

                    listOfSpells.Add(new Spell
                    {
                        Name = WebDriver.FindElement(SpellObjects.SpellName(i)).Text,
                        Class = nameof(Priest),
                        Spheres = WebDriver.FindElement(SpellObjects.SpellSpheres(i)).Text,
                        Level = Convert.ToInt32(WebDriver.FindElement(SpellObjects.SpellLevel(i)).Text.Substring(6).Trim()),
                        Range = WebDriver.FindElement(SpellObjects.SpellRange(i)).Text.Substring(6).Trim(),
                        Save = WebDriver.FindElement(SpellObjects.SpellSave(i)).Text.Substring(5).Trim(),
                        Components = WebDriver.FindElement(SpellObjects.SpellComponents(i)).Text.Substring(11).Trim(),
                        AoE = WebDriver.FindElement(SpellObjects.AoE(i)).Text.Substring(4).Trim(),
                        CastingTime = WebDriver.FindElement(SpellObjects.SpellCastingTime(i)).Text.Substring(14).Trim(),
                        Duration = WebDriver.FindElement(SpellObjects.SpellDuration(i)).Text.Substring(9).Trim(),
                        Description = WebDriver.FindElement(SpellObjects.SpellDescription(i)).Text,
                    });

                    targetSpell.Click();
                    Console.WriteLine($"{nameof(Priest)}: {i + 1}. {listOfSpells[^1].Name} Scraped.");
                }

                var classDdl = WebDriver.FindElement(SpellObjects.ClassDdl);
                JavaExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", classDdl);
                SelectElement ddlClasses = new SelectElement(classDdl);
                ddlClasses.SelectByText("Wizard");
                Thread.Sleep(3000);

                for (var n = 0; n < Wizard; n++)
                {
                    var targetWizardSpell = WebDriver.FindElement(SpellObjects.SpellSpheres(n));
                    JavaExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", targetWizardSpell);
                    targetWizardSpell.Click();
                    Thread.Sleep(300);

                    listOfSpells.Add(new Spell
                    {
                        Name = WebDriver.FindElement(SpellObjects.SpellName(n)).Text,
                        Class = nameof(Wizard),
                        Spheres = WebDriver.FindElement(SpellObjects.SpellSpheres(n)).Text,
                        Level = Convert.ToInt32(WebDriver.FindElement(SpellObjects.SpellLevel(n)).Text.Substring(6).Trim()),
                        Range = WebDriver.FindElement(SpellObjects.SpellRange(n)).Text.Substring(6).Trim(),
                        Save = WebDriver.FindElement(SpellObjects.SpellSave(n)).Text.Substring(5).Trim(),
                        Components = WebDriver.FindElement(SpellObjects.SpellComponents(n)).Text.Substring(11).Trim(),
                        AoE = WebDriver.FindElement(SpellObjects.AoE(n)).Text.Substring(4).Trim(),
                        CastingTime = WebDriver.FindElement(SpellObjects.SpellCastingTime(n)).Text.Substring(14).Trim(),
                        Duration = WebDriver.FindElement(SpellObjects.SpellDuration(n)).Text.Substring(9).Trim(),
                        Description = WebDriver.FindElement(SpellObjects.SpellDescription(n)).Text,
                    });

                    targetWizardSpell.Click();
                    Console.WriteLine($"{nameof(Wizard)}: {n + 1}. {listOfSpells[^1].Name} Scraped.");
                }

                FileSystemManager fileManagement = new FileSystemManager();
                fileManagement.SaveJsonFile(listOfSpells, $"AllSpells.json");

                return listOfSpells;
            }
            catch (Exception e)
            {
                TearDown();
                Console.WriteLine(e);
                Console.WriteLine(JsonConvert.SerializeObject(listOfSpells));
                throw;
            }
        }
    }
}
