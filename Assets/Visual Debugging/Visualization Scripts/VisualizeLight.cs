using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(Light))]
    [ExecuteInEditMode]
    public sealed class VisualizeLight : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }

        void Update()
        {
            if (GetComponent<Light>().type == LightType.Point)
                DebugViz3D.DrawSphere(Pos, GetComponent<Light>().range * 2f, debugColor);
            else if (GetComponent<Light>().type == LightType.Spot)
                DebugViz3D.DrawFOV(Pos, transform.rotation, GetComponent<Light>().spotAngle * Mathf.Deg2Rad, GetComponent<Light>().range, debugColor);
            else if (GetComponent<Light>().type == LightType.Area)
            {
                DebugViz3D.DrawPlane(Pos, transform.rotation, GetComponent<Light>().areaSize, debugColor);
                Debug.DrawRay(Pos, transform.forward, debugColor);
            }
            else if (GetComponent<Light>().type == LightType.Directional)
                DebugViz3D.DrawArrow(Pos, transform.forward, debugColor);
        }
#else
	void Awake() 
    {
	    Destroy(this);
	}
#endif
    }
}
