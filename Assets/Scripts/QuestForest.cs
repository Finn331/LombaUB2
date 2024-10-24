using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestForest : MonoBehaviour
{
    public GameObject forest;
    public GameObject forestSekarat;

    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        forest.SetActive(active);
        forestSekarat.SetActive(!active);
    }

    void changeAcrive(){
        active = !active;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
