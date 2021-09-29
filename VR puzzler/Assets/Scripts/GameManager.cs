using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] ISensor[] sensors;

    [SerializeField] int nextSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        sensors = GameObject.FindObjectsOfType<Sensor>();

        Valve.VR.InteractionSystem.Player[] playerInstance = GameObject.FindObjectsOfType<Valve.VR.InteractionSystem.Player>();
        if (playerInstance.Length > 1)
        {
            playerInstance[1].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(ISensor s in sensors)
        {
            if (!s.Activated())
            {
                return;
            }
        }
        LevelCleared();
    }

    void LevelCleared()
    {
        Debug.Log("Yay! cleared level!");
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
