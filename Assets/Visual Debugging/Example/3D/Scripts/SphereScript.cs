using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public sealed class SphereScript : MonoBehaviour
    {

        //cache components
        private Transform myTran = null;
        private Rigidbody myBody = null;
        private SphereCollider myColl = null;

        private Vector3 Pos { get { return myTran.position; } }
        private Quaternion Rot { get { return myTran.rotation; } }

        void Start()
        {
            myTran = this.transform;
            myBody = this.GetComponent<Rigidbody>();
            myColl = (SphereCollider)this.GetComponent<Collider>();

            if (myColl.material != null)
            {
                myColl.material.dynamicFriction = Random.value;
                myColl.material.bounciness = Random.value;
            }
        }

        void Update()
        {
#if UNITY_EDITOR
            DebugViz3D.DrawSphere(Pos + (Rot * myColl.center), myColl.radius * 2f, Rot, Color.green); //draw bounds of collider
            DebugViz3D.DrawArrow(Pos + (Rot * myColl.center), Vector3.ClampMagnitude(myBody.velocity, 10f), Color.magenta); //velocity
#endif
        }
    }
}