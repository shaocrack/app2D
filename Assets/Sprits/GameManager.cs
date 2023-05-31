using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instancia { get; private set; }
    private MaquinaDeEstados maquinaDeEstados ;
    private void Awake()
    {
        if( Instancia != null) Destroy( gameObject); 
        else Instancia = this;
        
    }
    public Renderer fondo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.05f, 0)*Time.deltaTime;
    }

    public void ActualizarMaquinaDeEstados(MaquinaDeEstados nuevoEstado) 
    {
    switch( nuevoEstado) 
        {
            case MaquinaDeEstados.Jugando:
                break;
            case MaquinaDeEstados.JuegoTerminado:
                Debug.Log("PERDISTE EL JUEGO");
                break;
            case MaquinaDeEstados.JuegoGanado:
                Debug.Log("JUEGO GANADO");
                break;
            default:
                break;
        
        }
    }
}
public enum MaquinaDeEstados 
{
Jugando,
JuegoTerminado,
JuegoGanado,

}
