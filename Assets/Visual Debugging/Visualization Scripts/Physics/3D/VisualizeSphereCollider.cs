using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(SphereCollider))]
    [ExecuteInEditMode]
    public sealed class VisualizeSphereCollider : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }
        private Quaternion Rot { get { return transform.rotation; } }
        private SphereCollider Coll { get { return (SphereCollider)GetComponent<Collider>(); } }

        void Update()
        {
            DebugViz3D.DrawSphere(Pos + (Rot * Coll.center), Coll.radius * 2f, Rot, debugColor);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}