using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite turnSprite;

    public AnimatorController animator;
    public AnimationClip idle_animation;
    public AnimationClip attack_animation;
    public AnimationClip death_animation;

    public int hp;
    public int mp;
    public int physAttack;
    public int magAttack;
    public int physDefense;
    public int magDefense; 
    public int agility;
    public int luck;

    public int exp_given;
    public ItemSO item_1;
    public ItemSO item_2;

    public List<ActionSO> actions;
}