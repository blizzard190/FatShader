using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject meal;
    private Transform[] _Transform;
    void Start()
    {
        /*for(int i = 0; i <= this.transform.GetChildCount)
        {

        }
        _Transform[] = this.transform.GetChild*/
        _Transform = new Transform[12];
        int i = 0;
        foreach (Transform child in transform)
        {
            _Transform[i] = child;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //_Transform[Random.Range(0, _Transform.Length)];
        Instantiate(meal, _Transform[Random.Range(0, 11)]);
    }
}
