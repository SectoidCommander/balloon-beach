using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(Camera))]
    [ExecuteInEditMode]
    public sealed class VisualizeCameraFrustum : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }
        private Vector3 nearClip { get { return Pos + (transform.forward * GetComponent<Camera>().nearClipPlane); } }
        private Vector3 farClip { get { return Pos + (transform.forward * GetComponent<Camera>().farClipPlane); } }

        void Update()
        {
            float halfFOV = (GetComponent<Camera>().fieldOfView / 2f) * Mathf.Deg2Rad;

            float nearHeight = GetComponent<Camera>().nearClipPlane * Mathf.Tan(halfFOV);
            float nearWidth = nearHeight * GetComponent<Camera>().aspect;

            float farHeight = GetComponent<Camera>().farClipPlane * Mathf.Tan(halfFOV);
            float farWidth = farHeight * GetComponent<Camera>().aspect;

            DebugViz3D.DrawPlane(nearClip, transform.rotation, new Vector2(nearWidth * 2f, nearHeight * 2f), debugColor); //near clip plane
            DebugViz3D.DrawPlane(farClip, transform.rotation, new Vector2(farWidth * 2f, farHeight * 2f), debugColor); //far clip plane

            Vector3 nearLowRight = (Pos + transform.right * nearWidth) - (transform.up * nearHeight) + (transform.forward * GetComponent<Camera>().nearClipPlane);
            Vector3 nearLowLeft = (Pos - transform.right * nearWidth) - (transform.up * nearHeight) + (transform.forward * GetComponent<Camera>().nearClipPlane);
            Vector3 nearUpRight = (Pos + transform.right * nearWidth) + (transform.up * nearHeight) + (transform.forward * GetComponent<Camera>().nearClipPlane);
            Vector3 nearUpLeft = (Pos - transform.right * nearWidth) + (transform.up * nearHeight) + (transform.forward * GetComponent<Camera>().nearClipPlane);

            Vector3 farLowRight = (Pos + transform.right * farWidth) - (transform.up * farHeight) + (transform.forward * GetComponent<Camera>().farClipPlane);
            Vector3 farLowLeft = (Pos - transform.right * farWidth) - (transform.up * farHeight) + (transform.forward * GetComponent<Camera>().farClipPlane);
            Vector3 farUpRight = (Pos + transform.right * farWidth) + (transform.up * farHeight) + (transform.forward * GetComponent<Camera>().farClipPlane);
            Vector3 farUpLeft = (Pos - transform.right * farWidth) + (transform.up * farHeight) + (transform.forward * GetComponent<Camera>().farClipPlane);

            Debug.DrawLine(nearLowRight, farLowRight, debugColor);
            Debug.DrawLine(nearLowLeft, farLowLeft, debugColor);
            Debug.DrawLine(nearUpRight, farUpRight, debugColor);
            Debug.DrawLine(nearUpLeft, farUpLeft, debugColor);

        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}
