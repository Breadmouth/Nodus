using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

    float xBoundary = 1.0f;

    Vector3 targetPos;

    public GameObject spawnerObject;
    SpawnerScript spawnerScript;

	void Start () {

        targetPos = new Vector3(0, -3, 0);

        spawnerScript = spawnerObject.GetComponent<SpawnerScript>();

	}

	void Update () {

        if ((transform.position - targetPos).magnitude < 0.02f)
        {
            transform.position = targetPos;
            if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -xBoundary)
            {
                //move left
                targetPos = new Vector3(transform.position.x - 1.0f, transform.position.y + 2.0f, 0);
                if (xBoundary == 2.0f)
                    xBoundary = 1.0f;
                else
                    xBoundary = 2.0f;

                spawnerScript.SpawnNextRow();
            }
            else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < xBoundary)
            {
                //move right
                targetPos = new Vector3(transform.position.x + 1.0f, transform.position.y + 2.0f, 0);
                if (xBoundary == 2.0f)
                    xBoundary = 1.0f;
                else
                    xBoundary = 2.0f;

                spawnerScript.SpawnNextRow();
            }
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, 0.12f);

	}
}
