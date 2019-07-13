using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class VisualizeVelocity3D : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }
        private Vector3 Vel { get { return GetComponent<Rigidbody>().velocity; } }

        void Update()
        {
            DebugViz3D.DrawArrow(Pos, Vel, debugColor);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}