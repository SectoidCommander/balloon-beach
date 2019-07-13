using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(CapsuleCollider))]
    [ExecuteInEditMode]
    public sealed class VisualizeCapsuleCollider : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }
        private Quaternion Rot { get { return transform.rotation; } }
        private CapsuleCollider Coll { get { return (CapsuleCollider)GetComponent<Collider>(); } }

        void Update()
        {
            if (Coll.direction == 0)
                DebugViz3D.DrawCapsule(Pos + (Rot * Coll.center), Coll.radius * 2f, Rot * Quaternion.Euler(0f, 0f, 90f), Coll.height, debugColor);
            else if (Coll.direction == 1)
                DebugViz3D.DrawCapsule(Pos + (Rot * Coll.center), Coll.radius * 2f, Rot, Coll.height, debugColor);
            else if (Coll.direction == 2)
                DebugViz3D.DrawCapsule(Pos + (Rot * Coll.center), Coll.radius * 2f, Rot * Quaternion.Euler(90f, 0f, 0f), Coll.height, debugColor);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}