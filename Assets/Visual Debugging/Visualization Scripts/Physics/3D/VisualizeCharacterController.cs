using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(CharacterController))]
    [ExecuteInEditMode]
    public sealed class VisualizeCharacterController : MonoBehaviour
    {
#if UNITY_EDITOR
        public Color debugColor = Color.green;

        private Vector3 Pos { get { return transform.position; } }
        private CharacterController Coll { get { return (CharacterController)GetComponent<Collider>(); } }

        void Update()
        {
            DebugViz3D.DrawCapsule(Pos + Coll.center, Coll.radius * 2f, Coll.height, debugColor);
        }
#else
	void Awake() {
		Destroy(this);
	}
#endif
    }
}