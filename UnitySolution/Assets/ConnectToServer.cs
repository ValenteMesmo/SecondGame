using ClientSide;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToServer : MonoBehaviour
{
    public string Ip = "192.168.0.8";
    public int Port = 8001;
    private GameClient game;
    private Dictionary<string, Thing> things = new Dictionary<string, Thing>();

    void Start()
    {
        game = new GameClient(SomethingChanged);
        game.Connect(Ip,Port);        
    }

    void SomethingChanged(string thingId, Thing thing)
    {
        things[thingId] = thing;
    }

    void OnDestroy()
    {
        game.Dispose();
    }

    void adasdsa()
    {
        if (newThing is Player)
        {
            var go = Instantiate(PlayerPrefab);
            var comp = go.AddComponent<PositionComponent>();
            comp.Get_X = () => newThing.X.GetValue();
            comp.Get_Y = () => newThing.Y.GetValue();

            var anim = go.AddComponent<AnimatorComponent>();
            anim.GetTriggerName = () =>
            {
                if ((newThing as Player).IsTouchingTheGround() == false)
                {
                    return "MidAir";
                }
                //TODO: use speed! not velocity
                else if (newThing.Velocity_X.GetValue() > 0 || newThing.Velocity_X.GetValue() < 0)
                {
                    return "Walk";
                }

                return "Iddle";
            };

            go.GetComponent<FlipSprite>().ShouldFlipSprite = () =>
            {
                //TODO: change! use speed... not velocity
                return newThing.Velocity_X.GetValue() < 0 /*&& (newThing as Player).IsTouchingTheGround()*/;
            };
        }
        else if (newThing is Block)
        {
            var go = Instantiate(BlockPrefab);
            var comp = go.AddComponent<PositionComponent>();
            comp.Get_X = () => newThing.X.GetValue();
            comp.Get_Y = () => newThing.Y.GetValue();
        }
    }
}
