using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    public float distancia = 10f;
    private Transform Player;
    private CreatePrefab spawner;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        spawner = FindObjectOfType<CreatePrefab>();
    }

    void Update()
    {
        if (transform.position.x < Player.position.x - distancia)
        {
            float pos;
            if (gameObject.CompareTag("Platform"))
            {
                pos = spawner.anchoPlataforma * 3;
                spawner.CrearPlataforma(pos);
            }else if (gameObject.CompareTag("Obstacle"))
            {
                pos = spawner.anchoObstaculo * 4;
                spawner.CrearObstaculo(pos);
            }

                Destroy(gameObject);
        }
    }
}
