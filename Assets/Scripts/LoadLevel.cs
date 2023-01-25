using UnityEngine;

[System.Serializable]
public struct LevelData
{
    public string id;
    public string name;
    public int defaultWall;
    public int defaultGround;
    public int width;
    public int height;
    public int[] gridstr;
}

public class LoadLevel : MonoBehaviour
{
    public GameObject[] prefabsWall;
    public GameObject[] prefabsGround;
    public GameObject[] prefabsDoor;
    public GameObject[] prefabsBadGuy;
    public GameObject[] prefabsGenerator;
    public GameObject[] prefabsSwitches;
    public GameObject[] prefabsCollectible;
    public GameObject player;

    private LevelData data;
    private string file;

    // Start is called before the first frame update
    void Start()
    {
        string level = PlayerPrefs.GetString("level", "1");
        file = "json/level-" + level;

        TextAsset textAsset = Resources.Load<TextAsset>(file);
        data = JsonUtility.FromJson<LevelData>(textAsset.text);

        Debug.Log(data);
        Debug.Log(data.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
