using Common;
using Common.GameComponents.MonsterComponents;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    Dictionary<Monster, GameObject> CurrentMonsters = new Dictionary<Monster, GameObject>();
    List<Monster> MonstersToCreate = new List<Monster>();

    void Start()
    {
        WorldComponent.Sandbox.MonsterCreated.Subscribe(MonsterCreated);
    }

    private void MonsterCreated(Monster monster)
    {
        MonstersToCreate.Add(monster);
    }

    void Update()
    {
        foreach (var monster in MonstersToCreate.ToList())
        {
            MonstersToCreate.Remove(monster);
            CurrentMonsters[monster] = (GameObject)Instantiate(Resources.Load("Prefab/Monster"));
            CurrentMonsters[monster].name = monster.Collider.Name;
            CurrentMonsters[monster].transform.position = new Vector2(monster.Collider.X, monster.Collider.Y);
        }
    }
}
