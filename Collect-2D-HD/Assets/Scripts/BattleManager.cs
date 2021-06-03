using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    PlayerCharacter player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("job: "             +  player.currentJob.ToString()   + " \n" +
                  "hp: "            +  player.hp           + " \n" +
                  "mp: "            +  player.mp           + " \n" +
                  "physAttack: "    +  player.physAttack   + " \n" +
                  "magAttack: "     +  player.magAttack    + " \n" +
                  "physDefense: "   +  player.physDefense  + " \n" +
                  "magDefense: "    +  player.magDefense   + " \n" +
                  "agility: "       +  player.agility      + " \n" +
                  "luck: "          +  player.luck);
    }
}
