using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(Renderer))]
    [ExecuteInEditMode]
    public sealed class VisualizeMeshBounds : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color AABB_Color = Color.green;
        public Color AABS_Color = Color.yellow;

        private Vector3 Pos { get { return GetComponent<Renderer>().bounds.center; } }
        private Vector3 AABBScale { get { return GetComponent<Renderer>().bounds.size; } }
        private float Radius { get { return GetComponent<Renderer>().bounds.extents.magnitude; } }

        void Update()
        {
            DebugViz3D.DrawCuboid(Pos, AABBScale, AABB_Color);
            DebugViz3D.DrawSphere(Pos, Radius * 2f, AABS_Color);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}
