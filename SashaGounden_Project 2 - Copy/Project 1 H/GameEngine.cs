﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_1_H
{
    class GameEngine
    {
        Map maparoo;
        int mapHeight, mapWidth;
        int numUnits, numBuildings;
        bool isGameOver = false;
        string winningFaction = "";
        int round = 0;

        public GameEngine(int numUnits, int numBuildings, int mapHeight, int mapWidth)
        {
            this.numUnits = numUnits;
            this.numBuildings = numBuildings;
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;
            maparoo = new Map(numUnits, numBuildings, mapHeight, mapWidth);
        }

        public bool IsGameOver
        {
            get { return isGameOver; }
        }

        public string WinningFaction
        {
            get { return winningFaction; }
        }

        public int Round
        {
            get { return round; }
        }

        public string GetMapDisplay()
        {
            return maparoo.GetMapDisplay();
        }

        public string GetUnitInfo()
        {
            string unitInfo = "";
            for (int i = 0; i < maparoo.Units.Length; i++)
            {
                unitInfo += maparoo.Units[i] + "\n";
            }

            for (int i = 0; i < maparoo.Buildings.Length; i++)
            {
                unitInfo += maparoo.Buildings[i] + "\n";
            }

            return unitInfo;
        }

        public void Reset(int numUnits, int numBuildings, int mapHeight, int mapWidth)//so it changes the map as customized by the user when map resets
        {
            this.numUnits = numUnits;
            this.numBuildings = numBuildings;
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;
            maparoo.Reset(numUnits, numBuildings, mapHeight, mapWidth);
            isGameOver = false;
            round = 0;
        }

        public void GameLoop()
        {
            double healthPercentage;

            for (int i = 0; i < maparoo.Units.Length; i++)//runs through every unit
            {
                if (maparoo.Units[i].IsDestroyed || round%maparoo.units[i].Speed != 0)
                {
                    continue;
                }

                Building closestBuilding = maparoo.Units[i].GetClosestBuilding(maparoo.Buildings);



                if (closestBuilding == null)//if there are no buildings then attack enemy
                {
                    Unit closestUnit = maparoo.Units[i].GetClosestUnit(maparoo.Units);
                    if (closestUnit == null)
                    {
                        isGameOver = true;
                        winningFaction = maparoo.Units[i].Faction;
                        maparoo.UpdateMap(numUnits, numBuildings, mapHeight, mapWidth);
                        return;
                    }
                    healthPercentage = maparoo.Units[i].Health / maparoo.Units[i].MaxHealth;
                    if (maparoo.Units[i].Symbol == 'W' && healthPercentage <= 0.50)//checks if the unit is a wizard and its health is = to to < 50% 
                    {
                        maparoo.Units[i].RunAway();
                    }
                    else if (healthPercentage <= 0.25)
                    {
                        maparoo.Units[i].RunAway();
                    }
                    else if (maparoo.Units[i].Symbol == 'W' && maparoo.Units[i].IsInRange(closestUnit))//if unit is wizard and closest unit is in range then attack 
                    {
                        for (int e = 0; e < maparoo.Units.Length; e++)
                        {
                            double distance = maparoo.Units[i].GetDistance(maparoo.Units[e]);
                            if (distance < 2 && distance > 0)//attack within a 1 block radius around me
                            {
                                maparoo.Units[i].Attack(maparoo.Units[e]);
                            }
                        }
                    }
                    else if (maparoo.Units[i].IsInRange(closestUnit))//attck if in range
                    {
                        maparoo.Units[i].Attack(closestUnit);
                    }
                    else
                    {
                        maparoo.Units[i].Move(closestUnit);//moves to if not in range
                    }
                }
                else//else if there are building with health then attack them before anything else
                {
                     healthPercentage = maparoo.Units[i].Health / maparoo.Units[i].MaxHealth;
                    if (healthPercentage <= 0.25)
                    {
                        maparoo.Units[i].RunAway();
                    }
                    else if (maparoo.Units[i].IsBuildingInRange(closestBuilding))//attck if in range
                    {
                        maparoo.Units[i].AttackBuilding(closestBuilding);
                    }
                    else
                    {
                        maparoo.Units[i].MoveBuilding(closestBuilding);//moves to if not in range
                    }
                }
                StayInBounds(maparoo.Units[i], maparoo.Size);
            }

            for (int i = 0; i < maparoo.Buildings.Length; i++)
            {
                if (round%maparoo.Buildings[i].Speed == 0)//logic for what buildings do
                {
                    Unit u = maparoo.Buildings[i].BuildingGen();//calls if it is its turn

                    if (u != null)
                    {
                        Array.Resize(ref maparoo.units, maparoo.Units.Length + 1);
                        maparoo.units[maparoo.Units.Length - 1] = u;
                    }
                }
            }

            maparoo.UpdateMap(numUnits, numBuildings, mapHeight, mapWidth);
            round++;
        }


        private void StayInBounds(Unit unit, int size)//moves units that moved off te map back onto the map
        {
            if (unit.X < 0)//if out of the map on the left then move to the first left collum
            {
                unit.X = 0;
            }
            else if (unit.X >= size)// on the right
            {
                unit.X = size - 1;
            }

            if (unit.Y < 0)// to the top
            {
                unit.Y = 0;
            }
            else if (unit.Y >= size)//to the bottom
            {
                unit.Y = size - 1;
            }
        }

        public void SaveUnits()
        {
            FileStream outFile = new FileStream("units.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);

            for (int i = 0; i < maparoo.Units.Length; i++)
            {
                writer.WriteLine(maparoo.Units[i].Save());
            }
            writer.Close();
            outFile.Close();
        }

        public void SaveBuildings()
        {
            FileStream outFile = new FileStream("buildings.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);

            for (int i = 0; i < maparoo.Buildings.Length; i++)
            {
                writer.WriteLine(maparoo.Buildings[i].Save());
            }
            writer.Close();
            outFile.Close();
        }

        public void LoadGame()
        {
            maparoo.LoadBuilding();
            maparoo.LoadUnits();
        }
    }
}
