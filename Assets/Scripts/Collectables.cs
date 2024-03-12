using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
            return;
        string color = gameObject.GetComponent<MeshRenderer>().material.name;
        if (color == "Yellow (Instance)")
            GameManager.inst.IncrementHP();
        else if(gameObject.transform.position.y==4.5f)
        {
            if (other.gameObject.GetComponent<MeshRenderer>().material.name == gameObject.GetComponent<MeshRenderer>().material.name)
                GameManager.inst.DecrementScore();
            else
                GameManager.inst.IncrementScore();
        }
        else
        {
            if (other.gameObject.GetComponent<MeshRenderer>().material.name == gameObject.GetComponent<MeshRenderer>().material.name)
                GameManager.inst.IncrementScore();
            else
                GameManager.inst.DecrementScore();
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
