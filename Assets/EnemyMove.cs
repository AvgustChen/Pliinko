using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            HoreseMove();
            Debug.Log("Horse Move");
        }
    }

    void HoreseMove(){
        float rand = Random.Range(1,4);
        rand = rand / 10;
        Debug.Log(rand);
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + rand, transform.position.y), 1);
        timer = 2;
    }
}
