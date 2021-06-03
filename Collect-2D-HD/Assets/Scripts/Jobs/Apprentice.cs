using System;
using UnityEngine;

public class Apprentice : ICharacterJob
{
    int hp = 5;
    int mp = 5;
    int physAttack = 5;
    int magAttack = 5;
    int physDefense = 5;
    int magDefense = 5;
    int agility = 5;
    int luck = 5;

    public int HP() { return hp; }
    public int MP() { return mp; }
    public int PhysAttack() { return physAttack; }
    public int MagAttack() { return magAttack; }
    public int PhysDefense() { return physDefense; }
    public int MagDefense() { return magDefense; }
    public int Agility() { return agility; }
    public int Luck() { return luck; }


    public void Attack()
    {
        // attack behaviour
    }

}
