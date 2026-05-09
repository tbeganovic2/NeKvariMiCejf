using UnityEngine;
using UnityEngine.UI; 

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript Instance { get; private set; }

    [SerializeField]
    public Slider CejfSlider;

    [SerializeField]
    public GameObject StartMenuPanel;




    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        CejfSlider.gameObject.SetActive(false);
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void StartGame()
    {
        StartMenuPanel.SetActive(false);
        GameManagerScript.Instance.state = GameManagerScript.GameState.Playing;
        GameManagerScript.Instance.StartGameFromMenu();
        CejfSlider.value = CejfSlider.maxValue;
    }

    public void AddToSlider(float value)
    {
        if (CejfSlider.value + value > CejfSlider.maxValue)
            CejfSlider.value = CejfSlider.maxValue;
        else if (CejfSlider.value + value < 0)
            CejfSlider.value = 0;

        CejfSlider.value += value;
    }
}
