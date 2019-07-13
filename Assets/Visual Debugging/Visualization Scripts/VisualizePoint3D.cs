using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [ExecuteInEditMode]
    public sealed class VisualizePoint3D : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;
        public float markerSize = 1f;

        private Vector3 Pos { get { return transform.position; } }

        void Update()
        {
            DebugViz3D.DrawMarker(Pos, markerSize, debugColor);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}
