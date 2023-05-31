using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nubeIA : MonoBehaviour
{
    [SerializeField] private Transform naveSprite;
    private int dir = 1;
    private float tamano;
    Vector2 limitePantalla;

   [SerializeField]private float speed=1.5f;
    // Start is called before the first frame update
    void Start()
    {
        //para saber donde aparecio
        limitePantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        if (transform.position.x <=limitePantalla.x/2) 
        {
            dir = 1;
            naveSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else 
        {
            dir = -1;
            naveSprite.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        //tama�o aleatorio
        float tamanoAleatorio=Random.Range(0.5f, 2.5f);
        tamano = tamanoAleatorio;
        transform.localScale = new Vector3(tamanoAleatorio, tamanoAleatorio, tamanoAleatorio);
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento con ia
        transform.position = transform.position + (Vector3.right*dir*Time.deltaTime*speed);
        //limites para el npc
         

        //para eliminarlo a lo que salga
        if (transform.position.x <= -limitePantalla.x-2 || transform.position.x > limitePantalla.x+2)
        {
            Destroy(gameObject);
        }
    }
    public float GetTamano() 
    {
        return tamano;
    }
}
