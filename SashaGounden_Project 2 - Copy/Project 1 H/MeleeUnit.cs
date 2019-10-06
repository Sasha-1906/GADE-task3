﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1_H
{
    class MeleeUnit : Unit
    {
        public MeleeUnit(int x, int y, string faction) : base(x, y, 100, 1, 10, 1, faction, 'M', "Swordsman")
        {

        }

        public override int X
        {
            get { return x; }
            set { x = value; }
        }
        public override int Y
        {
            get { return y; }
            set { y = value; }
        }
        public override int Health
        {
            get { return health; }
            set { health = value; }
        }
        public override int MaxHealth
        {
            get { return maxHealth; }
        }
        public override string Faction
        {
            get { return faction; }
            set { faction = value; }
        }
        public override char Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        public override bool IsDestroyed
        {
            get { return isDestroyed; }
        }
        public override string Name
        {
            get { return name; }
        }
        public override bool IsInRange(Unit otherUnit)
        {
            return GetDistance(otherUnit) <= attackRange;
        }
        public override bool IsBuildingInRange(Building building)
        {
            return GetBuildingDistance(building) <= attackRange;
        }
        public override int Speed
        {
            get { return speed; }
        }


        public override void Destroy()//if a ranged or melee unit is destoyed they will be replaced by a 'X' symbol
        {
            isDestroyed = true;
            isAttacking = false;
            symbol = 'X';
        }

        public override Unit GetClosestUnit(Unit[] units)//finds closest unit to targeted unit
        {
            double closestDistance = int.MaxValue;//new unit set to really big number 
            Unit closestUnit = null;

            for (int i = 0; i < units.Length; i++)
            {
                if (units[i].Faction == faction || units[i].IsDestroyed)//if the unit your checking is on te same team or if that unit is dead then skip that unit and move in the next one  
                {
                    continue;
                }

                double distance = GetDistance(units[i]);
                if (distance < closestDistance)//if distance is smaller than closestdistance then make that distance the new closestdistance 
                {
                    closestDistance = distance;
                    closestUnit = units[i];
                }
            }
            return closestUnit;// will move to or attack that unit
        }

        public override Building GetClosestBuilding(Building[] building)//finds closest unit to targeted unit
        {
            double closestDistance = int.MaxValue;//new unit set to really big number 
            Building closestBuilding = null;

            for (int i = 0; i < building.Length; i++)
            {
                if (building[i].Faction == faction || building[i].IsDestroyed)//if the unit your checking is on te same team or if that unit is dead then skip that unit and move in the next one  
                {
                    continue;
                }

                double distance = GetBuildingDistance(building[i]);
                if (distance < closestDistance)//if distance is smaller than closestdistance then make that distance the new closestdistance 
                {
                    closestDistance = distance;
                    closestBuilding = building[i];
                }
            }
            return closestBuilding;// will move to or attack that unit
        }

        public override void Attack(Unit targetUnit)
        {
            isAttacking = false;
            targetUnit.Health -= attack;//subtracts the attack damage from the targed units health

            if (targetUnit.Health <= 0)//checks if units health is below 0 and if it is then it is killed
            {
                targetUnit.Destroy();
            }

        }

        public override void AttackBuilding(Building building)
        {
            isAttacking = false;
            building.Health -= attack;

            if (building.Health <= 0)
            {
                building.Destroy();
            }
        }

        public override void Move(Unit closestUnit)
        {
            isAttacking = false;
            int xDistance = closestUnit.X - X;
            int yDistance = closestUnit.Y - Y;

            if (Math.Abs(xDistance) > Math.Abs(yDistance))
            {
                x += Math.Sign(xDistance);
            }
            else
            {
                y += Math.Sign(yDistance);
            }
        }

        public override void MoveBuilding(Building closestBuilding)
        {
            isAttacking = false;
            int xDistance = closestBuilding.X - X;
            int yDistance = closestBuilding.Y - Y;

            if (Math.Abs(xDistance) > Math.Abs(yDistance))
            {
                x += Math.Sign(xDistance);
            }
            else
            {
                y += Math.Sign(yDistance);
            }
        }

        public override void RunAway()
        {
            isAttacking = false;
            int direction = rnd.Next(0, 4);// runs away in a random direction
            if (direction == 0)
            {
                x += 1;//right
            }
            else if (direction == 1)
            {
                x -= 1;//left
            }
            else if (direction == 2)
            {
                y += 1;//down
            }
            else
            {
                y -= 1;//up
            }
        }

        public override string Save()
        {
            string unitSave = x + "," + y + "," + health + "," + faction + "," + symbol;
            return unitSave;
        }
    }
}
