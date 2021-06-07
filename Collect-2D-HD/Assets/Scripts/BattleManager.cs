using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    GameObject turnBar;
    float barWidth; // used to get maximum position for turn icons
    public GameObject turnMeterPrefab;
    public GameObject currentTurn;
    List<Entity> entities;
    bool initiateBattleHUD = false;

    Stack<GameObject> turnSpriteObjects;

    private void Awake()
    {
        turnSpriteObjects = new Stack<GameObject>();
        entities = new List<Entity>();
        turnBar = GameObject.FindGameObjectWithTag("turnBar");
        barWidth = turnBar.GetComponent<RectTransform>().sizeDelta.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] _entities = GameObject.FindGameObjectsWithTag("Entity");

        foreach (GameObject go in _entities)
        {
            entities.Add(go.GetComponent<Entity>());
        }

        entities.Sort();

        SortEntities();
    }

    void FixedUpdate()
    {
        /*if (entities[0].isPlayer && initiateBattleHUD)
        {


            initiateBattleHUD = false;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (PlayerCharacter pl in player)
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
            
        }
        */
    }

    public void NextTurn()
    {
        Entity[] temp = new Entity[entities.Count - 1];
        Entity pop = entities[0];
        entities.CopyTo(1, temp, 0, entities.Count-1);
        entities.Clear();

        entities.AddRange(temp);
        entities.Add(pop);

        SortEntities();
    }

    private void SortEntities()
    {
        while (turnSpriteObjects.Count > 0)
        {
            Destroy(turnSpriteObjects.Pop());
        }

        int num_entities = entities.Count - 1;
        float it = barWidth / num_entities;
        float currentTurnPos = 0;
        bool first = true;

        foreach (Entity a in entities)
        {
            if (first)
            {
                currentTurn.GetComponent<ChangeEntitySprite>().ChangeSprite(a.turnSprite);
                first = false;
                continue;
            }

            GameObject tm = Instantiate(turnMeterPrefab, turnBar.transform);
            tm.GetComponent<ChangeEntitySprite>().ChangeSprite(a.turnSprite);
            tm.GetComponent<RectTransform>().anchoredPosition = new Vector3(currentTurnPos, 0, 0);
            
            currentTurnPos += it;

            turnSpriteObjects.Push(tm);
        }
    }

    public Entity ReturnCurrentTurnEntity()
    {
        return entities[0];
    }
}
