using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public Vector3 playerPosition;
    public int point;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        //singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        FindPlayerOnTheCurrentScene();//after new scene loaded GameManager finds players on the current scene 
    }
    public void PlayerShapeChange(string tag)
    {
        for (int i = 0; i < player.transform.childCount; i++)
        {
            if (player.transform.GetChild(i).gameObject.CompareTag(tag))//call new shape with tag paramater
            {
                player.transform.GetChild(i).position = playerPosition;//match new shape with player's current position after change
                player.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    #region Player finder
    void FindPlayerOnTheCurrentScene()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("Player");
    }
    #endregion
}
