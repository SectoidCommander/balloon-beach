using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(BoxCollider2D))]
    [ExecuteInEditMode]
    public sealed class VisualizeBoxCollider2D : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }
        private Quaternion Rot { get { return transform.rotation; } }
        private float Angle { get { return Rot.eulerAngles.z * Mathf.Deg2Rad; } }
        private BoxCollider2D Coll { get { return (BoxCollider2D)GetComponent<Collider2D>(); } }

        void Update()
        {
            DebugViz2D.DrawRectangle(Pos + (Rot * Coll.offset), Vector2.Scale(transform.localScale, Coll.size), Angle, debugColor);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}