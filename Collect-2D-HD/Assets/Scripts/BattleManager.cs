using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class BattleManager : MonoBehaviour
{
    GameObject turnBar;
    float barWidth; // used to get maximum position for turn icons
    public GameObject turnMeterPrefab;
    public GameObject currentTurn;
    public GameObject selectEnemyGO;
    List<Entity> entities;
    List<Entity> enemies;
    bool initiateBattleHUD = false;
    Entity selectedEnemy = null;

    Stack<GameObject> turnSpriteObjects;
    PlayerBattleHUD battleHUD;

    public Transform playerAttackPosition;

    public VisualEffect hit;

    Camera camera;

    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        turnSpriteObjects = new Stack<GameObject>();
        entities = new List<Entity>();
        enemies = new List<Entity>();
        turnBar = GameObject.FindGameObjectWithTag("turnBar");
        barWidth = turnBar.GetComponent<RectTransform>().sizeDelta.x;
        battleHUD = GameObject.FindGameObjectWithTag("BattleHUD").GetComponent<PlayerBattleHUD>();
        battleHUD.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] _entities = GameObject.FindGameObjectsWithTag("Entity");

        int i = 0;
        foreach (GameObject go in _entities)
        {
            entities.Add(go.GetComponent<Entity>());

            if (!entities[i].isPlayer)
            {
                enemies.Add(entities[i]);
            }

            i++;
        }

        entities.Sort();

        SortEntities();
    }

    void FixedUpdate()
    {
        if (entities[0].isPlayer && initiateBattleHUD)
        {
            battleHUD.SetActive(true);

            initiateBattleHUD = false;
        }

        if (battleHUD.isAttackStart)
        {
            StartAttack();
        }

        if (battleHUD.isAbility)
        {
            RemoveEnemy(enemies[0]);


            battleHUD.isAbility = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (battleHUD.selectEnemyStarted)
        {
            selectEnemyGO.SetActive(true);

            battleHUD.selectedTargetIndex = 0;
            SelectEnemy(enemies[0]);

            battleHUD.selectEnemyStarted = false;
        }
        else if (battleHUD.isSelecting)
        {
            ChangeEnemySelection();
        }
    }

    private void ChangeEnemySelection()
    {
        if (battleHUD.targetSelectionChanged)
        {
            int i = battleHUD.selectedTargetIndex;

            if (i < 0) battleHUD.selectedTargetIndex = (enemies.Count - 1);
            else if (i >= enemies.Count) battleHUD.selectedTargetIndex = 0;

            SelectEnemy(enemies[battleHUD.selectedTargetIndex]);

            battleHUD.targetSelectionChanged = false;
        }

        if (battleHUD.isSelecting == false)
        {
            selectEnemyGO.SetActive(false);
        }
    }

    private void SelectEnemy(Entity _select)
    {
        selectedEnemy = _select;
        _select.GetComponentInChildren<Selectable>().Select();
        Vector3 pos = camera.WorldToScreenPoint(_select.GetComponentInChildren<Selectable>().transform.position);
        selectEnemyGO.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    private void RemoveEnemy(Entity _enemy)
    {
        _enemy.gameObject.SetActive(false);
        entities.Remove(_enemy);
        enemies.Remove(_enemy);

        SortEntities();
    }

    public void NextTurn()
    {
        if (ReturnCurrentTurnEntity().isPlayer)
        {
            ReturnCurrentTurnEntity().IsMoving = true;
            ReturnCurrentTurnEntity()._TargetPosition = ReturnCurrentTurnEntity()._LastPosition;
        }

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

        ToggleBattleHUD();
    }

    private void ToggleBattleHUD()
    {
        if (entities[0].isPlayer)
        {
            battleHUD.pc = (PlayerCharacter)entities[0];
            initiateBattleHUD = true;

            ReturnCurrentTurnEntity().IsMoving = true;
            ReturnCurrentTurnEntity()._TargetPosition = playerAttackPosition.position;
        }
        else
        {
            battleHUD.pc = null;
            battleHUD.SetActive(false);
        }
    }

    public Entity ReturnCurrentTurnEntity()
    {
        return entities[0];
    }

    public void StartAttack()
    {
        // Do Attack Animations
        hit.gameObject.transform.position = selectedEnemy.transform.position;
        hit.Play();
        selectedEnemy._Enemy.Damage(5);

        if (selectedEnemy.isDead)
        {
            RemoveEnemy(selectedEnemy);
        }

        // Next Turn
        battleHUD.CancelTarget();
        selectEnemyGO.SetActive(false);
        NextTurn();
    }
}
