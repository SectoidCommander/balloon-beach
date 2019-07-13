using UnityEngine;
using System.Collections;

namespace VisualDebugging
{
    public sealed class ObjectSpawner : MonoBehaviour
    {

        public enum CubeNum
        {
            Max = 1,
            High = 2,
            Medium = 3,
            low = 4
        }

        public CubeNum totalSpawn = CubeNum.High;
        public GameObject objectPF = null;

        // Use this for initialization
        void Awake()
        {
            GameObject tempObject = null;
            Vector3 tempPos = new Vector3();

            float i, j;
            for (i = -24.5f; i < 25.5f; i += (float)totalSpawn)
            {
                for (j = -24.5f; j < 25.5f; j += (float)totalSpawn)
                {
                    tempPos.Set(i, 0f, j);
                    tempObject = (GameObject)Instantiate(objectPF, tempPos, Quaternion.identity);
                }
            }
            //this is just to get rid of the warning
            //about assinged variable not being used
            tempObject.SetActive(true);
        }
    }
}