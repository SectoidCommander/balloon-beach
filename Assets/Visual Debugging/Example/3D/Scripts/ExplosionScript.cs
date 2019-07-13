using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VisualDebugging
{
    public sealed class ExplosionScript : MonoBehaviour
    {

        public float explosionForce = 10f;
        public float explosionRadius = 4f;

        private Vector3 exploPos = new Vector3();

        private Collider[] explodedObjects;

        void OnEnable()
        {
            //restart the particle system
            this.GetComponent<ParticleSystem>().Play();

            //move new explosion
            exploPos.Set(Random.Range(-24.5f, 24.5f), 0f, Random.Range(-24.5f, 24.5f));
            //		exploPos = new Vector3(Random.Range(-24.5f, 24.5f), 0f, Random.Range(-24.5f, 24.5f));
            transform.position = exploPos;

            explodedObjects = Physics.OverlapSphere(exploPos, explosionRadius);

            Rigidbody tempBody = null;
            foreach (Collider coll in explodedObjects)
            {
                tempBody = coll.GetComponent<Rigidbody>();
                if (tempBody != null)
                    tempBody.AddExplosionForce(explosionForce, exploPos, explosionRadius, 0.5f, ForceMode.Impulse);
            }
        }

        void Awake()
        {
            gameObject.SetActive(false);
        }

        void Update()
        {
#if UNITY_EDITOR
            DebugViz3D.DrawSphere(exploPos, explosionRadius * 2f, Color.blue);
#endif

            if (this.GetComponent<ParticleSystem>().isPlaying == false) gameObject.SetActive(false);
        }
    }
}
