using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CreatePrefab : MonoBehaviour
{
    public GameObject[] plataformas;
    public GameObject[] obstaculos;
    public GameObject glow;
    public GameObject flower;

    public float anchoPlataforma = 10f;
    public float anchoObstaculo = 3f;

    private float posicionXPlataforma = 0f;
    private float posicionXObstaculo = 0f;

    public int minY = -2;
    public int maxY = 2;

    public float timerGlow = 0f;
    
    public float timerFlower = 0f;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            CrearPlataforma(posicionXPlataforma);
            posicionXPlataforma += anchoPlataforma;
            
        }
        for (int i = 0;i < 8; i++)
        {
            CrearObstaculo(posicionXObstaculo);
            posicionXObstaculo += anchoObstaculo;
        }
    }

    private void Update()
    {
        timerGlow += Time.deltaTime;
        if (timerGlow >= 60f)
        {
            float posY = Random.Range(minY, maxY);

            Instantiate(glow, new Vector3(30f, posY, 0), Quaternion.identity);
            timerGlow = 0f;
        }

        timerFlower += Time.deltaTime;
        if (timerFlower >= 5f)
        {
            float posY = Random.Range(-3.4f, 3.4f);
            Vector3 init = new Vector3(20f, posY, 0);
            CrearFlores(init);
        }

    }

    public void CrearPlataforma(float posicionX)
    {
        float posicionY = Random.Range(minY, maxY);

        int i = Random.Range(0, plataformas.Length);
        GameObject Plataforma = plataformas[i];

        Vector3 posicion = new Vector3(posicionX, posicionY, 0);
        Instantiate(Plataforma, posicion, Quaternion.identity);

        if(i == 0)
        {
            Vector3 init = posicion + new Vector3(-2.2f, 0.7f, 0);
            CrearFlores(init);
        }
    }

    public void CrearObstaculo(float posiconX)
    {
        int i = Random.Range(0, obstaculos.Length);
        float posicionY = i == 0 ? -3.65f : 3.79f;

        GameObject obstaaculo = obstaculos[i];

        Vector3 posicion = new Vector3(posiconX, posicionY, 0);
        Instantiate(obstaaculo, posicion, Quaternion.identity);
    }

    public void CrearFlores(Vector3 init)
    {
        for(int i = 0; i < 10; i++)
        {
            Vector3 posicion = init + new Vector3(i * 0.5f, 0, 0);
            if (!EspacioBloqueado(posicion))
            {
                Instantiate(flower, posicion, Quaternion.identity);
            }
        }
        timerFlower = 0f;
    }

    bool EspacioBloqueado(Vector3 pos)
    {
        Collider2D col = Physics2D.OverlapCircle(pos, 0.2f);
        if (col !=null && (col.CompareTag("Platform") || col.CompareTag("Obstacle")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
