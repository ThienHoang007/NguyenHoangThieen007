using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance = null;
    public static LevelManager Instance => instance;

    [SerializeField] private Sprite levelLook;
    [SerializeField] private Sprite levelUplook;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance.GetInstanceID() != this.GetInstanceID()) Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        updateUILevels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateUILevels()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (i <= PlayerPrefs.GetInt("vel"))
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = levelUplook;
                this.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(loadScene);
                PlayerPrefs.SetInt("value", i);
            }
            else this.transform.GetChild(i).GetComponent<Image>().sprite = levelLook;
        }
    }
    private void loadScene() => SceneManager.LoadScene("Play", LoadSceneMode.Single);
}
