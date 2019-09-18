using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Renderer _Rend;
    private float _F = 0.07f;

    private void Start()
    {
        _Rend = GetComponent<Renderer>();
    }
    public void Eat()
    {
        _Rend.material.shader = Shader.Find("Tickner");
        _Rend.material.SetFloat("_Amout", _F);
    }
}
