using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1_H
{
    class ResourceBuilding : Building
    {
        ResourceType type;// resource type enum
        int resoGen = 0;//current total
        int resoPerRound = 5;
        int pool = 75;//resources avalible 

        public ResourceBuilding(int x, int y, string faction) : base(x, y, 100, faction, '@', 1, "Resources")
        {

        }

        public override int X { get { return x; } }
        public override int Y { get { return y; } }
        public override int Health { get { return health; } set { health = value; } }
        public override int MaxHealth { get { return maxHealth; } }
        public override string Faction { get { return faction; } }
        public override char Symbol { get { return symbol; } }
        public override int Speed { get { return speed; } }
        public override string Name { get { return name; } }
        public override bool IsDestroyed
        {
            get { return isDestroyed; }
        }

        public override void Destroy()
        {
            isDestroyed = true;
            symbol = '#';
        }

        public override string ToString()
        {
            return "Postion: " + x + "," + y + "\n" + "Health: " + health + " / " + maxHealth + "\n" + "Faction: " + faction + " (" + symbol + ")\n"+"\nResources: "+ resoGen + "\nResource Pool: "+ pool;
        }

        public void GenReso()
        {
            if (isDestroyed)
            {
                return;
            }

            if (pool > 0)//cant gen if pool is 0
            {
                resoGen += resoPerRound;
                pool -= resoPerRound;
            }
        }

        private string GetResourceName()
        {
            return new string[] { "Wood", "Food", "Rock", "Potion", "Stardust" }[(int)type];
        }

        public override Unit BuildingGen()
        {
            GenReso();
            return null;
        }

        public override string Save()
        {
            string buildingSave = x + "," + y + "," + health + "," + faction + "," + '@';
            return buildingSave;
        }

     
    }
}
