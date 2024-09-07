using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicaDeFundo;
    public static MusicManager instance;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        musicaDeFundo.Play();
        
    }

  
}
