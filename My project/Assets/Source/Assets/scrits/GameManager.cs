using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    public int PuntosTotales { get { return PuntosTotales;}}
    private int puntosTotales;
    private int vidas = 1;

    public void SumarPuntos (int puntosASumar){
        puntosTotales += puntosASumar;
    }

    void Awake(){
        if(Instance == null) {
            Instance = this;
        }else {
            Debug.Log("Mas de un game manager en esnena!");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerderVida(){
        vidas -=1;
        if (vidas <= 0)
        {
            
        }
    }


}
