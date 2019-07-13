using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(CircleCollider2D))]
    [ExecuteInEditMode]
    public sealed class VisualizeCircleCollider : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }
        private Quaternion Rot { get { return transform.rotation; } }
        private float Angle { get { return Rot.eulerAngles.z * Mathf.Deg2Rad; } }
        private CircleCollider2D Coll { get { return (CircleCollider2D)GetComponent<Collider2D>(); } }

        void Update()
        {
            DebugViz2D.DrawCircle(Pos + (Rot * Coll.offset), Coll.radius * 2f, Angle, debugColor);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}