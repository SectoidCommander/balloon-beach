using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class CubeScript : MonoBehaviour
    {

        //cache components
        private Transform myTran = null;
        private Rigidbody myBody = null;
        private BoxCollider myColl = null;

        private Vector3 Pos { get { return myTran.position; } }
        private Quaternion Rot { get { return myTran.rotation; } }

        void Start()
        {
            myTran = this.transform;
            myBody = this.GetComponent<Rigidbody>();
            myColl = this.GetComponent<Collider>() as BoxCollider;

            if (myColl.material != null)
            {
                myColl.material.dynamicFriction = Random.value;
                myColl.material.bounciness = Random.value;
            }
        }

        void Update()
        {
#if UNITY_EDITOR
            DebugViz3D.DrawCuboid(Pos + (Rot * myColl.center), myTran.localScale, Rot, Color.green);//collider
            DebugViz3D.DrawArrow(Pos + (Rot * myColl.center), Vector3.ClampMagnitude(myBody.velocity, 10f), Color.magenta);//velocity
#endif
        }
    }
}
