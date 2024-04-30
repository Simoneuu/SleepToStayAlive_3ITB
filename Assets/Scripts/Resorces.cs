using UnityEngine;
using System;
using TMPro;

public sealed class Resorces : MonoBehaviour
{
    private static Resorces _instance;
    public static Resorces Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Resorces>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<Resorces>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    [SerializeField]
    private TMP_Text koliktamje;
    public static int gold;
    public static int stone;
    public static int numBuildings;

    // Interval pro aktualizaci zdroj� (v sekund�ch)
    private float updateInterval = 5f;
    private float timeSinceLastUpdate = 0f;

    private void Start()
    {
        InitResources();
    }

    private void Update()
    {
        koliktamje.text = "Gold:" + gold + "  Stone:" + stone;
        // P�i��t� zdroje v dan�m intervalu
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= updateInterval)
        {
            timeSinceLastUpdate = 0f;
            UpdateResources();
        }
    }

    private void InitResources()
    {
        gold = 20;
        stone = 10;
        numBuildings = 0;
    }

    public void AddStone()
    {
        stone++;
    }

    public static bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool SpendStone(int amount)
    {
        if (stone >= amount)
        {
            stone -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateResources()
    {
        // P�i��t� zdroje na z�klad� po�tu budov
        gold += numBuildings * 4;
        DisplayResources();
    }

    public void DisplayResources()
    {
        Debug.Log("Gold: " + gold);
        Debug.Log("Stone: " + stone);
    }
}
