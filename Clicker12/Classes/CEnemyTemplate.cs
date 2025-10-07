using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clicker12.Classes
{
    public class CEnemyTemplate
    {
        [JsonInclude]
        private string name;
        [JsonInclude]
        private string iconName;
        [JsonInclude]
        private int baseLife;
        [JsonInclude]
        private double lifeModifier;
        [JsonInclude]
        private int baseGold;
        [JsonInclude]
        private double goldModifier;
        [JsonInclude]
        private double spawnChance;

        public CEnemyTemplate(string name, string iconName, int baseLife, double lifeModifier, int baseGold, double goldModifier, double spawnChance) 
        {
            this.name = name;
            this.iconName = iconName;
            this.baseLife = baseLife;
            this.lifeModifier = lifeModifier;
            this.baseGold = baseGold;
            this.goldModifier = goldModifier;
            this.spawnChance = spawnChance;
        }

        public string Name() { return name; }
        public string IconName() { return iconName; }
        public int BaseLife() { return baseLife; }
        public double LifeModidier() { return lifeModifier; }
        public int BaseGold() { return baseGold; }
        public double GoldModifier() { return goldModifier; }
        public double SpawnChance() { return spawnChance; }
    }
}
