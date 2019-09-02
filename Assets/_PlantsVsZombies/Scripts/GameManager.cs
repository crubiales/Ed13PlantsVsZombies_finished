using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static GameManager Instance
    {
        get
        {
            return ((GameManager)mInstance);
        }
        set
        {
            mInstance = value;
        }
    }

    void Start()
    {        
    }

    void Update()
    {        
    }

    public void AddSun(int sun)
    {
    }
}
