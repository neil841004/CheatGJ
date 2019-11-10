using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VideoA : MonoBehaviour
{
    VideoPlayer videoA;
    public int sceneNumber;
    // Use this for initialization
    void Start()
    {
        videoA = this.GetComponent<VideoPlayer>();
        videoA.loopPointReached += EndReached;	
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	void EndReached(UnityEngine.Video.VideoPlayer vp){
		Application.LoadLevel(sceneNumber);
	}
	
}
