using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public enum GameState { StartMenu,Playing,GameOver,Victory}

    public GameState state=GameState.StartMenu;

    [SerializeField]
    public RightArmScript rightArmScript;

    private float GameTime;
    public static GameManagerScript Instance { get; private set; }
    public void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        GameTime = -1f;
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Time.time - GameTime > 5 && GameTime>=0)
        {
            UIManagerScript.Instance.AddToSlider(1f);
        }
    }

    public void StartGameFromMenu()
    {
        rightArmScript.MoveInAndStay = true;
        GameTime = Time.time;
    }
}
