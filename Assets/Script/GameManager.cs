using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int count;
    public Text countText;
    public Text winText;
    public int numPickups;

    public GameObject player;
    public List<GameObject> playerShapes;
    public Vector3 playerPosition;
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
    }
    public void Start()
    {
        playerShapes = new List<GameObject>();
        for (int i = 0; i < player.transform.childCount; i++)
        {
            playerShapes.Add(player.transform.GetChild(i).gameObject);
        }
    }
    public void PlayerShapeChange(string tag)
    {
        for (int i = 0; i < player.transform.childCount; i++)
        {
            if (player.transform.GetChild(i).gameObject.CompareTag(tag))
            {
                player.transform.GetChild(i).position = playerPosition;
                player.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    public void IncreasePoint()
    {
        count++;
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= numPickups)
        {
            winText.text = "You win!";
        }
    }
}
