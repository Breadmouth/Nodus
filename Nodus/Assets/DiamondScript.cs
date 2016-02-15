using UnityEngine;
using System.Collections;

public class DiamondScript : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (transform.position.y < player.transform.position.y - 7)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 16, 0);
        }

	}
}
