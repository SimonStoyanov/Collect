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
    [HideInInspector]
    public Sprite turnSprite;

    [HideInInspector]
    public int baseHP, baseMP, basePhysAttack, baseMagAttack, basePhysDefense, baseMagDefense, baseAgility, baseLuck;

    public bool isPlayer { get; set; }
    public bool isDead { get; set; }

    // private variables
    private Character character;
    private Enemy enemy;
    private int currentAgility;

    // Movement
    private bool isMoving = false;
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    private Vector3 lastPosition;
    public Vector3 _LastPosition { get => lastPosition; set => lastPosition = value; }
    private Vector3 targetPosition;
    public Vector3 _TargetPosition { get => targetPosition; set => targetPosition = value; }

    // Entity
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

    float t = 0;
    float lerpTime = 7.5f;
    public void MoveTowards(Vector3 targetPos)
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpTime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);

        if (t > 0.9999f)
        {
            t = 0;
            isMoving = false;
            GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}

public class Character : Entity
{
    public Character() { _Character = this; isPlayer = true; isDead = false; }

    public string characterName;
    public job_enum job;

    public static int level;
    public static int exp;
    public static int exp_next;
}

public class Enemy : Entity, IDamageable<int> //, IStealable
{
    public Enemy() { _Enemy = this; isPlayer = false; isDead = false; }

    [HideInInspector]
    public string enemyName;
    [HideInInspector]
    public enemy_enum enemy_type;

    public static int exp_given;
    public static ItemSO item_0;
    public static ItemSO item_1;

    public void Damage(int damage)
    {
        baseHP -= damage;

        if (baseHP <= 0)
        {
            baseHP = 0;
            isDead = true;
        }
    }
}