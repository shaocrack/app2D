using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nubeSpwaner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject nubePreFab;
    //para el tiempo que apareceran
    private float spawnTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = spawnTime - Time.deltaTime;
        if(spawnTime <= 0) 
        {
            Instantiate(nubePreFab,GetSpawnPosition(),Quaternion.identity);
            spawnTime = 1.5f;
        
        }
    }

    private Vector3 GetSpawnPosition()
    {
        Vector2 limitePantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float aleatorioVertical = Random.Range(-limitePantalla.y,limitePantalla.y);
        float aleatorioHorizontal = Random.Range(0,2)==0 ?-limitePantalla.x-1 : limitePantalla.x+1;
       
        return new Vector3(aleatorioHorizontal, aleatorioVertical, 0);


    }
}
