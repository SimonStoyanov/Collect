using UnityEngine;

namespace Player.Commands
{
    abstract class Command
    {
        public string name = "";
        public string description = "";
        public abstract void Action();
    }

    class Attack : Command
    {
        GameObject enemy;

        public Attack(GameObject _enemy)
        {      
            name = "Attack";
            description = "Attacks an enemy";
            enemy = _enemy;
        }

        public override void Action()
        {
            Debug.Log("Attack Action\nname:" + name + "\ndescription:" + description);
        }
    }
}
