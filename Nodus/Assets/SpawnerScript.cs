using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnerScript : MonoBehaviour {

    public GameObject node;
    public GameObject connector;

    List<GameObject> nodeGrid;
    List<GameObject> connectors;

    int nextSpawnCount = 2;
    int nextRowHeight = 7;

	void Start () {

        nodeGrid = new List<GameObject>();
        connectors = new List<GameObject>();

        //create grid seen on screen
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(0, -3, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(-1, -1, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(1, -1, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(-2, 1, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(0, 1, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(2, 1, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(-1, 3, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(1, 3, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(-2, 5, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(0, 5, 0), transform.rotation));
        nodeGrid.Add((GameObject)Instantiate(node, new Vector3(2, 5, 0), transform.rotation));

        for (int i = 0; i < 15; ++i)
        {
            connectors.Add((GameObject)Instantiate(connector, Vector3.zero, transform.rotation));
        }
        connectors[0].GetComponent<ConnectorScript>().Init(nodeGrid[0].transform.position, nodeGrid[1].transform.position);
        connectors[1].GetComponent<ConnectorScript>().Init(nodeGrid[0].transform.position, nodeGrid[2].transform.position);
        connectors[2].GetComponent<ConnectorScript>().Init(nodeGrid[1].transform.position, nodeGrid[3].transform.position);
        connectors[3].GetComponent<ConnectorScript>().Init(nodeGrid[1].transform.position, nodeGrid[4].transform.position);
        connectors[4].GetComponent<ConnectorScript>().Init(nodeGrid[2].transform.position, nodeGrid[4].transform.position);
        connectors[5].GetComponent<ConnectorScript>().Init(nodeGrid[2].transform.position, nodeGrid[5].transform.position);
        connectors[6].GetComponent<ConnectorScript>().Init(nodeGrid[3].transform.position, nodeGrid[6].transform.position);
        connectors[7].GetComponent<ConnectorScript>().Init(nodeGrid[4].transform.position, nodeGrid[6].transform.position);
        connectors[8].GetComponent<ConnectorScript>().Init(nodeGrid[4].transform.position, nodeGrid[7].transform.position);
        connectors[9].GetComponent<ConnectorScript>().Init(nodeGrid[5].transform.position, nodeGrid[7].transform.position);
        connectors[10].GetComponent<ConnectorScript>().Init(nodeGrid[6].transform.position, nodeGrid[8].transform.position);
        connectors[11].GetComponent<ConnectorScript>().Init(nodeGrid[6].transform.position, nodeGrid[9].transform.position);
        connectors[12].GetComponent<ConnectorScript>().Init(nodeGrid[7].transform.position, nodeGrid[9].transform.position);
        connectors[13].GetComponent<ConnectorScript>().Init(nodeGrid[7].transform.position, nodeGrid[10].transform.position);
        connectors[14].GetComponent<ConnectorScript>().Init(new Vector3(0, -5, 0), nodeGrid[0].transform.position);

    }

	public void SpawnNextRow()
    {
        float xpos;
        if (nextSpawnCount == 2)
            xpos = -1;
        else
            xpos = -2;

        for (int i = 0; i < nextSpawnCount; ++i)
        {
            nodeGrid.Add((GameObject)Instantiate(node, new Vector3(xpos + (i * 2), nextRowHeight, 0), transform.rotation));
        }

        nextRowHeight += 2;

        for (int i = 0; i < 4; ++i)
        {
            connectors.Add((GameObject)Instantiate(connector, Vector3.zero, transform.rotation));
        }

        int connectorCount = connectors.Count;
        int nodeCount = nodeGrid.Count;

        if (nextSpawnCount == 2)
        {
            connectors[connectorCount - 1].GetComponent<ConnectorScript>().Init(nodeGrid[nodeCount - 5].transform.position, nodeGrid[nodeCount - 2].transform.position);
            connectors[connectorCount - 2].GetComponent<ConnectorScript>().Init(nodeGrid[nodeCount - 4].transform.position, nodeGrid[nodeCount - 2].transform.position);
            connectors[connectorCount - 4].GetComponent<ConnectorScript>().Init(nodeGrid[nodeCount - 4].transform.position, nodeGrid[nodeCount - 1].transform.position);
            connectors[connectorCount - 3].GetComponent<ConnectorScript>().Init(nodeGrid[nodeCount - 3].transform.position, nodeGrid[nodeCount - 1].transform.position);
        }
        else
        {
            connectors[connectorCount - 1].GetComponent<ConnectorScript>().Init(nodeGrid[nodeCount - 5].transform.position, nodeGrid[nodeCount - 3].transform.position);
            connectors[connectorCount - 2].GetComponent<ConnectorScript>().Init(nodeGrid[nodeCount - 5].transform.position, nodeGrid[nodeCount - 2].transform.position);
            connectors[connectorCount - 3].GetComponent<ConnectorScript>().Init(nodeGrid[nodeCount - 4].transform.position, nodeGrid[nodeCount - 2].transform.position);
            connectors[connectorCount - 4].GetComponent<ConnectorScript>().Init(nodeGrid[nodeCount - 4].transform.position, nodeGrid[nodeCount - 1].transform.position);
        }

        if (nextSpawnCount == 2)
            nextSpawnCount = 3;
        else
            nextSpawnCount = 2;

        //delete any node and connector too far down
        for (int i = nodeCount - 1; i >= 0; --i)
        {
            if (nodeGrid[i] != null)
            {
                if (nodeGrid[i].transform.position.y < nextRowHeight - 14)
                {
                    Destroy(nodeGrid[i]);
                }
            }
        }

        for (int i = connectorCount - 1; i >= 0; --i)
        {
            if (connectors[i] != null)
            {
                if (connectors[i].GetComponent<ConnectorScript>().GetHeight() < nextRowHeight - 14)
                {
                    Destroy(connectors[i]);
                }
            }
        }

    }
}
