using OpenQA.Selenium;

namespace Scrape2ndSpells.Maps
{
    public class SpellObjects
    {
        public static By ClassDdl => By.XPath("/html/body/app-root/div/div[1]/div/div/div[1]/select");
        public static By SpellName(int spellNumber) => By.XPath($"//*[@id=\"spel{spellNumber}\"]/div/div[1]/div/h6");
        public static By SpellLevel(int spellNumber) => By.XPath($"//*[@id=\"spel{spellNumber}\"]/div/div[2]/div[1]");
        public static By SpellSave(int spellNumber) => By.XPath($"//*[@id=\"spel{spellNumber}\"]/div/div[4]/div[1]");
        public static By SpellDuration(int spellNumber) => By.XPath($"//*[@id=\"spel{spellNumber}\"]/div/div[5]/div");
        public static By SpellComponents(int spellNumber) => By.XPath($"//*[@id=\"spel{spellNumber}\"]/div/div[2]/div[2]");
        public static By AoE(int spellNumber) => By.XPath($"//*[@id=\"spel{spellNumber}\"]/div/div[3]/div[2]");
        public static By SpellDescription(int spellNumber) => By.XPath($"//*[@id=\"spel{spellNumber}\"]/div");
        public static By SpellSpheres(int spellNumber) => By.XPath($"//*[@data-target=\"#spel{spellNumber}\"]/div/div[2]");
        public static By SpellRange(int spellNumber) => By.XPath($"//*[@id=\"spel{spellNumber}\"]/div/div[3]/div[1]");
        public static By SpellCastingTime(int spellNumber) => By.XPath($"//*[@id=\"spel{spellNumber}\"]/div/div[4]/div[2]");
        public static By BtnSpell(int spellNumber) => By.XPath($"//*[@data-target=\"#spel{spellNumber}\"]");
    }
}
