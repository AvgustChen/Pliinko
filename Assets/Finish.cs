using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public GameObject finishPanel;
    public TMP_Text Name;
    public TMP_Text FinishText;
    public bool isPlayer;
    string[] names = {"Matt", "Oliver", "Jack", "Harry", "Jacob", "Charlie"};
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, names.Length);
        if(isPlayer)
        Name.text = "You";
        else{
            Name.text = names[rand];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            finishPanel.SetActive(true);
            FinishText.text = Name.text + " crossed the finish line first in " + ((BallMove.timer  * 100) / 100f).ToString() + " seconds";
        }
    }
}
