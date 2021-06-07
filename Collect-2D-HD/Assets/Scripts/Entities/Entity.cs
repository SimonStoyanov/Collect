using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum job_enum
{
    apprentice,
    warrior
}

public enum enemy_enum
{
    slime
}

public enum item_enum
{
    potion,
    eter,

    nothing
}

public class Entity : MonoBehaviour, IComparable<Entity>
{
    public Sprite turnSprite;

    [HideInInspector]
    public int baseHP;
    [HideInInspector]
    public int baseMP;
    [HideInInspector]
    public int basePhysAttack;
    [HideInInspector]
    public int baseMagAttack;
    [HideInInspector]
    public int basePhysDefense;
    [HideInInspector]
    public int baseMagDefense;
    [HideInInspector]
    public int baseAgility;
    [HideInInspector]
    public int baseLuck;

    public bool isPlayer { get; set; }

    // private variables
    private Character character;
    private Enemy enemy;
    private int currentAgility;

    public Character _Character { get => character; set => character = value; }
    public Enemy _Enemy { get => enemy; set => enemy = value; }
    public int _CurrentAgility { get => currentAgility; set => currentAgility = value; }

    public int CompareTo(Entity other)
    {
        if (currentAgility > other.currentAgility) { return -1; }
        else if (currentAgility < other.currentAgility) { return 1; }

        // if agility is equal toss a coin
        if (Random.Range(0, 1) == 1) return 1;

        return -1;
    }

    public void Log(string text)
    {
        Debug.Log(text);
    }

    public int Rng(int min, int max)
    {
        return Random.Range(min, max);
    }
}

public class Character : Entity
{
    public Character() { _Character = this; isPlayer = true; }

    public string characterName;
    public job_enum job;

    public static int level;
    public static int exp;
    public static int exp_next;
}

public class Enemy : Entity //, IStealable
{
    public Enemy() { _Enemy = this; isPlayer = false; }

    public string enemyName;
    public enemy_enum enemy_type;

    public static int exp_given;
    public static item_enum item_0;
    public static item_enum item_1;
}