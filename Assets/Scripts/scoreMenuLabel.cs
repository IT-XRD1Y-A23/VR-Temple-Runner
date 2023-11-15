
using UnityEngine;
using TMPro;

public class scoreMenuLabel : MonoBehaviour
{
    public scoreObj score;
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    
    
    void Start()
    {
        textMeshPro.text = "Score: " + score.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
