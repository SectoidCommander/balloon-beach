using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VisualDebugging
{
		public sealed class ExpolsionSpawner : MonoBehaviour
		{

				public GameObject explosionPF = null;
				public float timeBetwenMin = 0f;
				public float timeBetwenMax = 0.1f;

				private float explosionCD = 0f;

				private List<GameObject> explosion = new List<GameObject> (4);

				void Start ()
				{
						for (int i = 0; i < explosion.Capacity; i++) {
								explosion.Add ((GameObject)Instantiate (explosionPF));
						}
						explosionCD = Random.Range (timeBetwenMin, timeBetwenMax);
				}

				void Update ()
				{
						if (explosionCD > 0f)
								explosionCD -= Time.deltaTime;
						else {
								explosionCD = Random.Range (timeBetwenMin, timeBetwenMax);

								bool mustGrow = true;
								for (int i = 0; i < explosion.Count; i++) {
										if (explosion [i].activeSelf == false) {
												mustGrow = false;
												explosion [i].SetActive (true);
												break;
										}
								}
								if (mustGrow) {
										GameObject tempObject = (GameObject)Instantiate (explosionPF);
										explosion.Add (tempObject);
										tempObject.SetActive (true);
								}
						}
				}
		}
}