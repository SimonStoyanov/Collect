using UnityEngine;

public class EnemyDisplay : Enemy, IDamageable<float>, IKillable
{
    public EnemySO enemy_so;

    private int agilityMod, randAgilityIncr;

    private void Awake()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = enemy_so.animator;
    }

    private void Start()
    {
        // Read values from Enemy Scriptable Object
        baseHP = enemy_so.hp;
        baseMP = enemy_so.mp;
        basePhysAttack = enemy_so.physAttack;
        baseMagAttack = enemy_so.magAttack;
        basePhysDefense = enemy_so.physDefense;
        baseMagDefense = enemy_so.magDefense;
        baseAgility = enemy_so.agility;
        baseLuck = enemy_so.luck;
        exp_given = enemy_so.exp_given;
        item_0 = enemy_so.item_1;
        item_1 = enemy_so.item_2;

        turnSprite = enemy_so.turnSprite;

        // agility modifier
        agilityMod = baseAgility;
        AgilityMod();
    }

    private void AgilityMod()
    {
        randAgilityIncr = Rng(0, 5);
        agilityMod += randAgilityIncr;

        _CurrentAgility = agilityMod;
    }

    public void Damage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void Kill()
    {
        throw new System.NotImplementedException();
    }
}
