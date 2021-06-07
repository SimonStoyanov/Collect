using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Action")]
public class ActionSO : ScriptableObject
{
    public new string name;
    public int probability;
    public int action_id;
}