using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject player;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void LateUpdate()
    {
        if (player.transform.position.y > 0)
            transform.position = new Vector3(0, player.transform.position.y, -10);
    }
}
