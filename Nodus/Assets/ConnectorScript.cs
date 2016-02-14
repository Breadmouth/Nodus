using UnityEngine;
using System.Collections;

public class ConnectorScript : MonoBehaviour {

    LineRenderer mine;
    float height;

    void Awake()
    {
        mine = transform.GetComponent<LineRenderer>();
    }

    public void Init(Vector3 pos1, Vector3 pos2)
    {
        mine.SetPosition(0, pos1);
        mine.SetPosition(1, pos2);

        height = pos2.y;
    }

    public float GetHeight()
    {
        return height;
    }
}
