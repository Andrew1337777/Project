using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform following;

        void Update()
        {
            transform.position = new Vector3(following.position.x,
                                             transform.position.y, transform.position.z);
        }

}
