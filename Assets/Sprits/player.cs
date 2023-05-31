using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class player : MonoBehaviour
{
    //estas variables se ven en unity
    [SerializeField] private Transform naveSprite;
    float velocidad = 3;
    //tamaño para perder
    private float tamano ;
    //para ganar puntos
    private int nubesComidos = 0;
    // Start is called before the first frame update
    void Start()
    {
        tamano = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //para detectar los valores de la teclas en movimiento
        float inputVertical = Input.GetAxis("Vertical")*Time.deltaTime *velocidad;
        float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime*velocidad;
        //el movimiento
        
        transform.position = transform.position + new Vector3 (inputHorizontal,inputVertical, 0);

        //LIMITES
        Vector2 limitePantalla =Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, limitePantalla.x * -1,limitePantalla.x),
            Mathf.Clamp(transform.position.y, limitePantalla.y * -1, limitePantalla.y),
            0
            ) ;

        //las rotaciones
        if (inputHorizontal == 0) return;
        

        if (inputHorizontal <0) 
        {
        naveSprite.rotation = Quaternion.Euler(new Vector3(0,180,0));

        }
        else 
        {

            naveSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

    }
    //otra funcion para colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nube"))     
        {
           nubeIA nubeIA = collision.gameObject.GetComponent<nubeIA>();
            if (tamano >=nubeIA.GetTamano()) 
            {
                nubesComidos++;
                transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
                tamano = transform.localScale.x;
                Destroy(collision.gameObject);
                if (nubesComidos >=1) 
                {
                    GameManager.Instancia.ActualizarMaquinaDeEstados(MaquinaDeEstados.JuegoGanado);
                    velocidad = 0;
                
                }
            }
            else 
            {
                GameManager.Instancia.ActualizarMaquinaDeEstados(MaquinaDeEstados.JuegoTerminado);
                Destroy(gameObject);
            
            }
            
        }
    }
}
