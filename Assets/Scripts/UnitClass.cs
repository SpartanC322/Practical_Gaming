using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClass : MonoBehaviour
{
    //Attributes that make up a class
    private int health;
    private string className;
    private int damage;
    private int distanceCanMove;
    private int minDistanceToAttack;

    public UnitClass()
    {
        health = 1;
        className = "deprived";
        damage = 1;
        distanceCanMove = 1;
        minDistanceToAttack = 1;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void setHealth(int health)
    {
        this.health = health;
    }

    private void setClassName(string name)
    {
        this.className = name;
    }

    private void setDamage(int damage)
    {
        this.damage = damage;
    }

    private void setDistanceCanMove(int distanceCanMove)
    {
        this.distanceCanMove = distanceCanMove;
    }

    private void setMinDistanceToAttack(int minDistanceToAttack)
    {
        this.minDistanceToAttack = minDistanceToAttack;
    }

    public int getHealth()
    {
        return health;
    }

    public string getClassName()
    {
        return className;
    }

    public int getDamage()
    {
        return damage;
    }

    public int getDistanceCanMove()
    {
        return distanceCanMove;
    }

    public int GetMinDistanceToAttack()
    {
        return minDistanceToAttack;
    }
}