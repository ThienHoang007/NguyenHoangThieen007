using UnityEngine;

public class CreatMatrix : MonoBehaviour
{
    public GameObject elementOne;
    public GameObject elementTwo;   
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    GameObject g = Instantiate(elementOne, this.transform);
                    g.name = $"element{i}{j}";
                    g.transform.position = new Vector3(i, j, 0);
                }
                else
                {
                    GameObject g = Instantiate(elementTwo, this.transform);
                    g.name = $"element{i}{j}";
                    g.transform.position = new Vector3(i, j, 0);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
