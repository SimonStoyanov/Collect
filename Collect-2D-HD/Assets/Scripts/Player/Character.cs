using UnityEngine;

public enum job_enum
{
    apprentice,
    warrior
}

public class Character : MonoBehaviour
{
    public string characterName;
    public job_enum job;
    public Sprite turnSprite;

    public static int level;
    public static int exp;
    public static int exp_next;

    public int baseHP;
    public int baseMP;
    public int basePhysAttack;
    public int baseMagAttack;
    public int basePhysDefense;
    public int baseMagDefense;
    public int baseAgility;
    public int baseLuck;

    public void Log(string text)
    {
        Debug.Log(text);
    }
}
