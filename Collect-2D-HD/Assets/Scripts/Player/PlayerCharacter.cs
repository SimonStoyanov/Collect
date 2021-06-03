namespace Player
{
    public enum class_enum
    {
        warrior,
        mage,
        healer,
        martial,

        apprentice
    }
}


public class PlayerCharacter : Character, IDamageable<float>, IKillable
{
    public ICharacterJob currentJob;
    job_enum _currentJobEnum = job_enum.apprentice;

    public int hp { get { return currentJob.HP() + baseHP; } }
    public int mp { get { return currentJob.MP() + baseMP; } }
    public int physAttack { get { return currentJob.PhysAttack() + basePhysAttack;  } }
    public int magAttack { get { return currentJob.MagAttack() + baseMagAttack;  } }
    public int physDefense { get { return currentJob.PhysDefense() + basePhysDefense;  } }
    public int magDefense { get { return currentJob.MagDefense() + baseMagDefense;  } }
    public int agility { get { return currentJob.Agility() + baseAgility;  } }
    public int luck { get { return currentJob.Luck() + baseLuck;  } }

    void Awake()
    {
        SwitchJob();
    }

    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (_currentJobEnum != job)
        {
            SwitchJob();
        }
    }

    private void SwitchJob()
    {
        switch (job)
        {
            case job_enum.apprentice:
                currentJob = new Apprentice();
                break;
            case job_enum.warrior:
                currentJob = new Warrior();
                break;
        }

        _currentJobEnum = job;
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
