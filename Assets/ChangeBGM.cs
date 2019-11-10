using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGM : MonoBehaviour
{
    public AudioClip end;
    bool i = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CM(){
        if(!i){
        this.GetComponent<AudioSource>().PlayOneShot(end);
        }
        i=true;
    }
}
