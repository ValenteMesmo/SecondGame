using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColliderTouchBehaviour : MonoBehaviour
{
    void Start()
    {
        var touches = DetectsTouchOnAnyCollidersInScene.Instance;
        touches.OnStart += inputs_OnTouch;
        touches.OnEnd += inputs_OffTouch;
        touches.OnStay += inputs_OnTouchStay;
        touches.OnCancel += touches_OnCancel;
    }

    public virtual void OnStart(PointEventArgs e) { }
    public virtual void OnStay(PointEventArgs e) { }
    public virtual void OnCancel(PointEventArgs e) { }
    public virtual void OnEnd(PointEventArgs e) { }

    void touches_OnCancel(object sender, PointEventArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            OnCancel(e);
    }

    private void inputs_OffTouch(object sender, PointEventArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            OnEnd(e);
    }

    private void inputs_OnTouch(object sender, PointEventArgs e)
    {
        if (e.Transform.gameObject == gameObject)
        {
            WorldComponent.Sandbox.Log.Publish("touched " + e.Transform.gameObject.name);

            OnStart(e);
        }
    }

    private void inputs_OnTouchStay(object sender, PointEventArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            OnStay(e);
    }

    private class DetectsTouchOnAnyCollidersInScene : MonoBehaviour
    {
        private DetectsTouchOnAnyCollidersInScene() { }
        private static object lockObj = new object();

        //todo : use dinleton class
        private static DetectsTouchOnAnyCollidersInScene _instance;
        public static DetectsTouchOnAnyCollidersInScene Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObj)
                    {
                        var gameObj = new GameObject("Touch Detector");
                        _instance = gameObj.AddComponent<DetectsTouchOnAnyCollidersInScene>();
                    }
                }

                return _instance;
            }
        }

        private List<Collider2D> PreviousTouchs = new List<Collider2D>();
        private List<Collider2D> CurrentTouchs = new List<Collider2D>();

        public event EventHandler<PointEventArgs> OnStart;
        public event EventHandler<PointEventArgs> OnCancel;
        public event EventHandler<PointEventArgs> OnStay;
        public event EventHandler<PointEventArgs> OnEnd;

        void Update()
        {
            CurrentTouchs.Clear();

            for (var i = 0; i < Input.touchCount; ++i)
            {
                var touch = Input.GetTouch(i);

                RaycastHit2D hitInfo = Physics2D.Raycast(
                    Camera.main.ScreenToWorldPoint(touch.position),
                    Vector2.zero);

                if (hitInfo)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            FireEvent(OnStart, hitInfo.transform, touch.position);
                            CurrentTouchs.Add(hitInfo.collider);
                            break;

                        case TouchPhase.Moved:
                            if (PreviousTouchs.Any(f => f == hitInfo.collider))
                            {
                                FireEvent(OnStay, hitInfo.transform, touch.position);
                                CurrentTouchs.Add(hitInfo.collider);
                            }
                            else
                            {
                                FireEvent(OnStart, hitInfo.transform, touch.position);
                                CurrentTouchs.Add(hitInfo.collider);
                            }
                            break;

                        case TouchPhase.Stationary:
                            FireEvent(OnStay, hitInfo.transform, touch.position);
                            CurrentTouchs.Add(hitInfo.collider);
                            break;

                        case TouchPhase.Canceled:
                            FireEvent(OnCancel, hitInfo.transform, touch.position);
                            PreviousTouchs.Remove(hitInfo.collider);
                            break;

                        case TouchPhase.Ended:
                            FireEvent(OnEnd, hitInfo.transform, touch.position);
                            PreviousTouchs.Remove(hitInfo.collider);
                            break;
                    }
                }
            }

            foreach (var touch in PreviousTouchs)
            {
                if (CurrentTouchs.Any(f => f == touch) == false)
                    FireEvent(OnCancel, touch.transform, transform.position);
            }

            PreviousTouchs.Clear();
            PreviousTouchs.AddRange(CurrentTouchs);
        }

        private void FireEvent(EventHandler<PointEventArgs> eventHandler, Transform transform, Vector2 vector)
        {
            if (eventHandler != null)
                eventHandler(this, new PointEventArgs(vector, transform));
        }
    }
}

public class PointEventArgs : EventArgs
{
    public Transform Transform;
    public Vector2 Vector2;

    public PointEventArgs(Vector2 vector2, Transform transform)
    {
        Vector2 = vector2;
        Transform = transform;
    }
}