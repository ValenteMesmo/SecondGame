using Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundFactory : MonoBehaviour
{
    private readonly Dictionary<Position, GameObject> CurrentGrounds =
        new Dictionary<Position, GameObject>();

    private readonly List<Position> GroundsToCreate =
        new List<Position>();

    void Start()
    {
        WorldComponent.Sandbox.GroundAdded.Subscribe(NewGroundAdded);
    }

    private void NewGroundAdded(Position dimension)
    {
        GroundsToCreate.Add(dimension);
    }

    void Update()
    {
        foreach (var position in GroundsToCreate.ToList())
        {
            GroundsToCreate.Remove(position);

            CurrentGrounds[position] =
                (GameObject)Instantiate(Resources.Load("Prefab/Ground"));

            CurrentGrounds[position].transform.position = 
                new Vector2(position.X, position.Y);

            CurrentGrounds[position].name =
                string.Format(
                    "Ground ({0},{1})",
                    position.X,
                    position.Y);
        }
    }
}
