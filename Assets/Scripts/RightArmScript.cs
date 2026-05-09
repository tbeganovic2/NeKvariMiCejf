using UnityEngine;

public class RightArmScript : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    private bool _MoveInAndStay=false;
    public bool MoveInAndStay { get { return _MoveInAndStay; }
                                set { _MoveInAndStay = value;
                                      if(value) animator.SetTrigger("MoveInAndStay");
                                } 
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
