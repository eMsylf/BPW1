using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PillarsOn : MonoBehaviour
{

    public bool allPillarsOn;
    int pillarTotal;
    public bool levelComplete;
    public bool gameComplete;

    public GameObject levelCompleteText;
    public GameObject gameCompleteText;


    int theNumberOfPillarsThatAreSwitchedOnAtTheMoment;

    public List<PillarScript> children;

    public int numberOfScenes;
    
	// Use this for initialization
	void Start ()
    {
        children = new List<PillarScript>();
        children.AddRange(FindObjectsOfType<PillarScript>());
        pillarTotal = children.Count;

        numberOfScenes = SceneManager.sceneCountInBuildSettings;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelComplete && !gameComplete)
        {
            StartCoroutine(LoadNextLevel());
            return;
        }

        theNumberOfPillarsThatAreSwitchedOnAtTheMoment = 0;

        foreach (PillarScript pillar in children)
        {
            if (pillar.pillarIsOn)
            {
                theNumberOfPillarsThatAreSwitchedOnAtTheMoment++;
            }
        }

        levelCompleteText.SetActive(levelComplete = theNumberOfPillarsThatAreSwitchedOnAtTheMoment == pillarTotal);

        if (gameComplete = SceneManager.GetActiveScene().buildIndex == numberOfScenes - 1 && levelComplete)
        {
            gameCompleteText.SetActive(true);
        }

        if (gameComplete && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
            {
                RestartGame();
            }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(4f);
        if (SceneManager.GetActiveScene().buildIndex + 1 < numberOfScenes) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
