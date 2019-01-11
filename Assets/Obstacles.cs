using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    public GameObject triangleObj;


	void Start () {
        initObstacles();
	}

    void initObstacles()
    {
        foreach(Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        int rand = Random.Range(-4, 5);
        int rand2 = Random.Range(-4, 5);
        int rand3 = Random.Range(-4, 5);
        for (int i = -4; i < 5; i++)
        {
            if (i == rand || i == rand2 || rand3 == i) continue;
            GameObject flagObj = Instantiate(triangleObj, new Vector2(transform.position.x + .4f, i), Quaternion.identity);
            flagObj.transform.SetParent(transform);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        initObstacles();
    }
}

