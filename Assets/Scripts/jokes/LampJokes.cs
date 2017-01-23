using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LampJokes : MonoBehaviour {

    [SerializeField]
    string pathToFile = "";
    [SerializeField]
    float minVel;
    
    string[] jokes;
    Text jokesDisplay;

	// Use this for initialization
	void Start () {
        jokes = File.ReadAllLines(pathToFile);

        jokesDisplay = GameObject.FindGameObjectWithTag("JokesDisplay").GetComponent<Text>();
    }

    void OnCollisionEnter(Collision col) {
        if(col.relativeVelocity.magnitude > minVel) {
            string joke = jokes[Random.Range(0, jokes.Length)];
            jokesDisplay.text = joke.Replace("<br>", "\n\n");
            print(joke);
        }
    }
}
