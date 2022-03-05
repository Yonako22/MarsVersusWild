using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claude : Ennemis
{
    void Start()
    {
        
    }
    
    void Update()
    {
       rb.AddForce(Vector2.down * speed * Time.deltaTime); 
    }
}
