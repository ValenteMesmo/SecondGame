using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace UnitySolution.InputComponents
{
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

    //TODO: implement abstraction ....     uses mouse on pc
    //estava pensando em deletar todos esses handlers que eu criei... deixar apenas as interfaces
    public class DetectsTouchOnAnyCollidersInScene : MonoBehaviour
    {
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