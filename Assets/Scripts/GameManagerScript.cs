using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public enum GameState { StartMenu,Playing,GameOver,Victory}

    public GameState state=GameState.StartMenu;


    public enum PlayState { Idle, DrinkingCoffee,PouringCoffee,Pointing}

    public PlayState playState = PlayState.Idle;

    [SerializeField]
    public RightArmScript rightArmScript;

    [SerializeField]
    public CoffeeSetScript coffeeSetScript;

    [SerializeField]
    public float CejfLossRate = 1f;

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
            UIManagerScript.Instance.AddToSlider(CejfLossRate);
        }
        if (UIManagerScript.Instance.CejfSlider.value < 0)
        {
            state = GameState.GameOver; //IMPLEMENT THIS
        }
    }

    public void StartGameFromMenu()
    {
        rightArmScript.MoveInAndStay = true;
        GameTime = Time.time;
    }

    public float lastCoffeeDrinkTime = -1f;

    [SerializeField]
    public float CoffeeDrinkWaitTime = 10f;
    [SerializeField]
    public float TooSoonCoffeeDrinkLoss = -10f;
    public void DrinkCoffee()
    {
        playState = PlayState.DrinkingCoffee;
        if(lastCoffeeDrinkTime < 0)
        {
            lastCoffeeDrinkTime = Time.time;
        }
        if (Time.time - lastCoffeeDrinkTime > CoffeeDrinkWaitTime)
        {
            //Coffee drunk too soon
            UIManagerScript.Instance.AddToSlider(TooSoonCoffeeDrinkLoss);
        }
    }

}
