public class EnemyDisplay : Enemy, IDamageable<float>, IKillable
{
    public EnemySO enemy_so;

    public int hp;
    public int mp;
    public int physAttack;
    public int magAttack;
    public int physDefense;
    public int magDefense;
    public int agility;
    public int luck;

    private int randAgilityIncr;

    private void Start()
    {
        hp = enemy_so.hp;
        mp = enemy_so.mp;
        physAttack = enemy_so.physAttack;
        magAttack = enemy_so.magAttack;
        physDefense = enemy_so.physDefense;
        magDefense = enemy_so.magDefense;
        agility = enemy_so.agility;
        luck = enemy_so.luck;


        randAgilityIncr = Rng(0, 5);
        agility += randAgilityIncr;

        _CurrentAgility = agility;
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
