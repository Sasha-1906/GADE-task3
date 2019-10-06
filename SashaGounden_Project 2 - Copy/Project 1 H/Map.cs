using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_1_H
{
    class Map
    {
        //int mapSize = 20;// check Size method
        int mapHeight, mapWidth;
        Random rnd = new Random();
        int numUnits, numBuildings;
        public Unit[] units;
        public Building[] buildings;
        string[,] maparoo;
        string[] factions = { "Blue-T", "Orange-T" };

        public Map(int numUnits, int numBuildings, int mapHeight, int mapWidth)
        {
            this.numUnits = numUnits;
            this.numBuildings = numBuildings;
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;
            Reset(numUnits, numBuildings, mapHeight, mapWidth);
        }

        public Unit[] Units
        {
            get { return units; }
        }

        public Building[] Buildings
        {
            get { return buildings; }
        }

        public int Size
        {
            get { return this.mapHeight;
                  return this.mapWidth;
                }

        }

        public string GetMapDisplay()
        {
            string mapString = "";
            for (int y = 0; y < this.mapHeight; y++)
            {
                for (int x = 0; x < this.mapWidth; x++)
                {
                    mapString += maparoo[x, y];
                }
                mapString += "\n";
            }
            return mapString;
        }

        public void Reset(int numUnits, int numBuildings, int mapHeight, int mapWidth)
        {
            this.numUnits = numUnits;
            this.numBuildings = numBuildings;
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;

            maparoo = new string[this.mapWidth, this.mapHeight];
            units = new Unit[this.numUnits];
            buildings = new Building[this.numBuildings];
            InitializeUnits();
            UpdateMap(this.numUnits, this.numBuildings, this.mapHeight, this.mapWidth);
        }

        public void UpdateMap(int numUnits, int numBuildings, int mapHeight, int mapWidth)
        {
            for (int y = 0; y < this.mapHeight; y++)
            {
                for (int x = 0; x < this.mapWidth; x++)
                {
                    maparoo[x, y] = "~~~";//populates map with ~
                }
            }

            for (int i = 0; i < units.Length; i++)//runs through unit array and changes ~ to a unit
            {
                maparoo[units[i].X, units[i].Y] = units[i].Faction[0] + "/" + units[i].Symbol;
            }

            for (int i = 0; i < buildings.Length; i++)
            {
                maparoo[buildings[i].X, buildings[i].Y] = buildings[i].Faction[0] + "/" + buildings[i].Symbol;
            }
        }

        private void InitializeUnits()//makes random units
        {
            for (int i = 0; i < units.Length; i++)
            {
                int x = rnd.Next(0, this.mapWidth);
                int y = rnd.Next(0, this.mapHeight);
                int factionIndex = rnd.Next(0, 2);
                int unitType = rnd.Next(0, 2);

                while (maparoo[x, y] != null)
                {
                    x = rnd.Next(0, this.mapWidth);
                    y = rnd.Next(0, this.mapHeight);
                }

                if (unitType == 0)
                {
                    units[i] = new MeleeUnit(x, y, factions[factionIndex]);
                }
                else
                {
                    units[i] = new RangedUnit(x, y, factions[factionIndex]);
                }
                maparoo[x, y] = units[i].Faction[0] + "/" + units[i].Symbol;
            }

            for (int i = 0; i < buildings.Length; i++)
            {
                int x = rnd.Next(0, this.mapHeight);
                int y = rnd.Next(0, this.mapWidth);
                int factionIndex = rnd.Next(0, 2);
                int unitType = rnd.Next(0, 2);
                

                while (maparoo[x, y] != null)
                {
                    x = rnd.Next(0, this.mapWidth);
                    y = rnd.Next(0, this.mapHeight);
                }

                if (unitType == 0)//construct factory building 
                {
                    string mOrR;
                    int rndMR = rnd.Next(0, 2);

                    if (rndMR == 0)
                    {
                        mOrR = "RangedUnit";
                    }
                    else
                    {
                        mOrR = "MeleeUnit";
                    }

                    buildings[i] = new FactoryBuilding(x, y, factions[factionIndex], mOrR);
                }
                else//construct resource buildings
                {
                    buildings[i] = new ResourceBuilding(x, y, factions[factionIndex]);
                }
                maparoo[x, y] = buildings[i].Faction[0] + "/" + buildings[i].Symbol;
            }
        }

       public void LoadUnits()
       {
            FileStream file = new FileStream("units.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            string unitInfo;//reads first line
            string[] infoField;
            unitInfo = reader.ReadLine();
            units = new Unit[0];

            while(unitInfo !=null)
            {
                Array.Resize(ref units, units.Length + 1);
                infoField = unitInfo.Split(',');

                if (infoField [4] == Convert.ToString('R'))
                {
                    units[units.Length - 1] = new RangedUnit(0,0, "");
                }
                else
                {
                    units[units.Length - 1] = new MeleeUnit(0, 0, "");
                }
                units[units.Length - 1].X = Convert.ToInt32(infoField[0]);
                units[units.Length - 1].Y = Convert.ToInt32(infoField[1]);
                units[units.Length - 1].Health = Convert.ToInt32(infoField[2]);
                units[units.Length - 1].Faction = (infoField[3]);
                units[units.Length - 1].Symbol = Convert.ToChar(infoField[4]);
                unitInfo = reader.ReadLine();

            }
            reader.Close();
            file.Close();
            UpdateMap(numUnits, numBuildings, mapHeight, mapWidth);
       }


        public void LoadBuilding()
        {
            FileStream file = new FileStream("buildings.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            string buildingInfo;//reads first line
            string[] infoField;
            buildingInfo = reader.ReadLine();
            buildings = new Building[0];

            while (buildingInfo != null)
            {
                Array.Resize(ref buildings, buildings.Length + 1);
                infoField = buildingInfo.Split(',');

                if (infoField[4] == "$")
                {
                    buildings[buildings.Length - 1] = new FactoryBuilding(Convert.ToInt32(infoField[0]), Convert.ToInt32(infoField[1]), infoField[3], "");
                }
                else
                {
                    buildings[buildings.Length - 1] = new ResourceBuilding(Convert.ToInt32(infoField[0]), Convert.ToInt32(infoField[1]), infoField[3]);
                }
                buildings[buildings.Length - 1].Health = Convert.ToInt32(infoField[2]);
                buildingInfo = reader.ReadLine();

            }
            reader.Close();
            file.Close();
            UpdateMap(numUnits, numBuildings, mapHeight, mapWidth);
        }
    }
}
