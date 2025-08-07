using System;
using Pattern.Factory;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private MonsterFactory currentFactory;
    private Monster currentMonster;

    private GoblinFactory goblinFactory;
    private OrcFactory orcFactory;

    private void Awake()
    {
        goblinFactory = new GoblinFactory();
        orcFactory = new OrcFactory();
    }

    void Start()
    {
        currentFactory = goblinFactory;
        currentMonster = currentFactory.CreateMonster("Normal");
        currentMonster = currentFactory.CreateMonster("Warrior");
        currentMonster = currentFactory.CreateMonster("Archer");
        
        currentFactory = orcFactory;
        currentMonster = currentFactory.CreateMonster("Normal");
        currentMonster = currentFactory.CreateMonster("Warrior");
        currentMonster = currentFactory.CreateMonster("Archer");
    }
}
