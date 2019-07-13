using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class VisualizeVelocity2D : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }
        private Vector3 Vel { get { return GetComponent<Rigidbody2D>().velocity; } }

        void Update()
        {
            DebugViz2D.DrawArrow(Pos, Vel, debugColor);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}