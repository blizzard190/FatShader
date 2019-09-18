using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Renderer _Rend;
    private float _F = 0.09f;

    private void Start()
    {
        _Rend = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        if(_F >= -1f)
        {
            _F -= 0.001f;
            _Rend.material.SetFloat("_Amount", _F);
        }
    }

    public void Eat()
    {
        // _Rend.material.shader = Shader.Find("Tickner");
        _Rend.material.SetFloat("_Amount", _F);
        _F += 0.03f;
    }
}
