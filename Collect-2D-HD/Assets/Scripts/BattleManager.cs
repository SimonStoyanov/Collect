using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public RectTransform turnBar;
    float barWidth; // used to get maximum position for turn icons
    public GameObject turnMeterPrefab;


    List<PlayerCharacter> player;

    private void Awake()
    {
        barWidth = turnBar.sizeDelta.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = new List<PlayerCharacter>();
        GameObject[] go = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject pl in go)
        {
            player.Add(pl.GetComponent<PlayerCharacter>());
        }

        GameObject tm = Instantiate(turnMeterPrefab);
        tm.GetComponent<ChangeEntitySprite>().ChangeSprite(player[0].turnSprite);
        //player[0].turnSprite;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(turnBar.sizeDelta.x);

        foreach (PlayerCharacter pl in player)
        {
            /*
            Debug.Log("name: "          +  pl.characterName             + " \n" +
                      "job: "           +  pl.currentJob.ToString()     + " \n" +
                      "hp: "            +  pl.hp                        + " \n" +
                      "mp: "            +  pl.physAttack                + " \n" +
                      "magAttack: "     +  pl.magAttack                 + " \n" +
                      "physDefense: "   +  pl.physDefense               + " \n" +
                      "magDefense: "    +  pl.magDefense                + " \n" +
                      "agility: "       +  pl.agility                   + " \n" +
                      "luck: "          +  pl.luck);
            */
        }
    }
}
