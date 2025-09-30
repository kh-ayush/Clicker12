using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;


namespace Clicker12.Classes
{
    public class CEnemyTemplateList
    {
        List<CEnemyTemplate> enemies;
        public CEnemyTemplateList()
        {
            enemies = new List<CEnemyTemplate>();
        }
        public void addEnemy(string name, string iconName, int baseLife, double lifeModification, int baseGold, double goldModification, double spawnChance) 
        {
            enemies.Add(new CEnemyTemplate(name, iconName, baseLife, lifeModification, baseGold, goldModification, spawnChance));
        }
        public void AddEnemy(CEnemyTemplate x)
        {
            enemies.Add(x);
        }
        public CEnemyTemplate GetByName(string name) 
        {
            foreach (CEnemyTemplate x in enemies)
                if (x.Name() == name) return x;
            return null;
            //return (CEnemyTemplate) enemies.Where(x => x.Name() == name);
        }
        public CEnemyTemplate GetById(int i) 
        {
            return enemies[i];
        }
        public void DelByName(string name)
        {
            enemies.Remove(enemies.FirstOrDefault(x => x.Name() == name));
        }
        public void DelById(int i)
        {
            enemies.RemoveAt(i);
        }
        public List<string> GetNames() 
        {
            List<string> names = new List<string>();
            foreach (CEnemyTemplate x in enemies) names.Add(x.Name());
            return names;
        }
        public void SaveJson() 
        {
            string jsonString = JsonSerializer.Serialize(enemies);
            File.WriteAllText("EnemysList.json", jsonString);
        }
        public void LoadJson()
        {
            string jsonFromFile = File.ReadAllText("EnemysList.json");
            JsonDocument doc = JsonDocument.Parse(jsonFromFile);
            foreach (JsonElement element in doc.RootElement.EnumerateArray())
            { 
                string name = element.GetProperty("name").GetString();
                string iconName = element.GetProperty("iconName").GetString();
                int baseLife = element.GetProperty("nabaseLifeme").GetInt32();
                double lifeModification = element.GetProperty("lifeModification").GetDouble();
                int baseGold = element.GetProperty("baseGold").GetInt32();
                double goldModification = element.GetProperty("goldModification").GetDouble();
                double spawnChance = element.GetProperty("spawnChance").GetDouble();
                enemies.Add(new CEnemyTemplate(name, iconName, baseLife, lifeModification, baseGold, goldModification, spawnChance));
            }
        }
    }
}
