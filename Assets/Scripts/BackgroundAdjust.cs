using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAdjust : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float alturaCamara = Camera.main.orthographicSize * 2;
        float anchoCamara = alturaCamara * Screen.width / Screen.height;

        Vector2 tamañoSprite = sr.sprite.bounds.size;

        transform.localScale = new Vector3(
            anchoCamara / tamañoSprite.x,
            alturaCamara / tamañoSprite.y,
            1
        );
    }
}
