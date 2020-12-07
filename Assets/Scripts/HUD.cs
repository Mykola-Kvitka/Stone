using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [SerializeField]
    private Text timePass;
    private float curentTime;
    private float curent;
    private bool stop = false;
    public void Stop() { 
      stop = true;   
    }
    // Start is called before the first frame update
    void Start()
    {
        timePass.text = curentTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        curent += Time.deltaTime;
        if (!stop && curent > 1)
        {
            curent = 0;
            curentTime += 1;
            timePass.text = curentTime.ToString();
        }
    }
}
