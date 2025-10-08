using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clicker12.Classes
{
    public class CEnemyTemplate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        string name;
        string iconName;
        int baseLife;
        double lifeModifier;
        int baseGold;
        double goldModifier;
        double spawnChance;

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
        public CEnemyTemplate()
        {
            name = "Новый монстр";
            iconName = "";
            baseLife = 0;
            lifeModifier = 1;
            baseGold = 0;
            goldModifier = 1;
            spawnChance = 0.5;
        }

        [JsonInclude]
        public string Name
        {
            get => name;
            set
            {
                name = value ?? throw new ArgumentNullException(nameof(value));
                OnPropertyChanged("Name");
            }
        }
        [JsonInclude]
        public string IconName
        {
            get => iconName;
            set {
                iconName = value ?? throw new ArgumentNullException(nameof(value));
                OnPropertyChanged("IconName");
            }
        }

        [JsonInclude]
        public int BaseLife
        {
            get => baseLife;
            set => baseLife = value;
        }

        [JsonInclude]
        public double LifeModifier
        {
            get => lifeModifier;
            set => lifeModifier = value;
        }

        [JsonInclude]
        public int BaseGold
        {
            get => baseGold;
            set => baseGold = value;
        }

        [JsonInclude]
        public double GoldModifier
        {
            get => goldModifier;
            set => goldModifier = value;
        }

        [JsonInclude]
        public double SpawnChance
        {
            get => spawnChance;
            set => spawnChance = value;
        }
    }
}
