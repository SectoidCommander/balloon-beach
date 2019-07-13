using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(BoxCollider))]
    [ExecuteInEditMode]
    public sealed class VisualizeBoxCollider : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }
        private Quaternion Rot { get { return transform.rotation; } }
        private BoxCollider Coll { get { return (BoxCollider)GetComponent<Collider>(); } }

        void Update()
        {
            DebugViz3D.DrawCuboid(Pos + (Rot * Coll.center), Vector3.Scale(transform.localScale, Coll.size), Rot, debugColor);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}