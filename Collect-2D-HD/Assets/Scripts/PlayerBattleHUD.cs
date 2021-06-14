using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerBattleHUD : MonoBehaviour
{
    public PlayerCharacter pc; // implement actions
    public Button attack, abilities, defend, items;
    public BattleManager battleManager;

    PlayerInput playerInput;

    [HideInInspector]
    public bool isAttackStart = false;
    [HideInInspector]
    public bool selectEnemyStarted = false;
    [HideInInspector]
    public bool isSelecting = false;
    [HideInInspector]
    public bool isAbility = false;

    [HideInInspector]
    public int selectedTargetIndex = 0;
    [HideInInspector]
    public bool targetSelectionChanged = false;

    EventSystem evt;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.UI.Cancel.started += Cancel;
        playerInput.UI.Navigate.started += context => Movement(context);
        playerInput.UI.Submit.started += Submit;
        playerInput.Enable();
    }

    private void Start()
    {
        evt = EventSystem.current;
        //attack.Select();
    }

    private void FixedUpdate()
    {
        /*
        Debug.Log(evt.currentSelectedGameObject);*/
    }

    public void SetActive(bool _value)
    {
        gameObject.SetActive(_value);

        if (_value == true)
        {
            attack.Select();
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
        isAttackStart = true;
        isSelecting = false;
    }

    private void Abilities()
    {
        Debug.Log("Abilities");
        isAbility = true;
    }

    private void Defend()
    {
        Debug.Log("Defend");
    }

    private void Items()
    {
        Debug.Log("Items");
    }

    private void Movement(InputAction.CallbackContext context)
    {
        if (isSelecting)
        {
            Vector2 input = context.ReadValue<Vector2>();

            if (input.x == 1)
            {
                Cancel(context);
                return;
            }

            if (input.y == 1)
            {
                selectedTargetIndex++;
            }
            else if (input.y == -1)
            {
                selectedTargetIndex--;
            }

            targetSelectionChanged = true;
        }
    }

    public void Cancel(InputAction.CallbackContext context)
    {
        if (isSelecting)
        {
            CancelTarget();
            battleManager.selectEnemyGO.SetActive(false);
            isSelecting = false;
        }
    }

    private void Submit(InputAction.CallbackContext context)
    {
        if (gameObject.activeSelf)
        {
            if (evt.currentSelectedGameObject == attack.gameObject)
            {
                Debug.Log("Start Enemy Selection");

                selectEnemyStarted = true;
                isSelecting = true;
            }
            else if (isSelecting)
            {
                Debug.Log("Start Attack at Selected Target");
                Attack();
            }
        }
    }

    public void CancelTarget()
    {
        isAttackStart = false;
        selectEnemyStarted = false;
        targetSelectionChanged = false;
        selectedTargetIndex = 0;

        attack.Select();
    }
}
