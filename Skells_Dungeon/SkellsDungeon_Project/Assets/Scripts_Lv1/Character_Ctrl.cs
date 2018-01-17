using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Character_Ctrl : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private float _Speed = 10.0f;
    [SerializeField]
    float _RotationSpeed = 40;
    private int AmountOfDice = 0;
    private int health = 100;
    private int lives = 3;
    [SerializeField]
    private float _maxDamageTime = 2.0f;
    [SerializeField]
    private float _damageTimer = 0.0f;
    [SerializeField]
    private Animator CharacterAnimator;
    private Vector3 _PrevPosition;
    private int _PowerGems = 0; //HAS TO BE ZERO
    bool _IsDamaged = false;
    bool _IsPlayerDead = false;
    Vector3 force = new Vector3(0, 0, 0);
    private float _deathTimer = 0;
    void Start ()
    {
        CharacterAnimator.SetTrigger("Idle");
        _PrevPosition = this.transform.position;
        _deathTimer = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(health <= 0)
        {
            CharacterAnimator.SetTrigger("Death");
            _IsPlayerDead = true;
        }
        if(_IsPlayerDead == false)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (Input.GetAxis("VerticalLStick") != 0)
            {
                force = new Vector3(h, 0.0f, v);
            }
            else
            {
                force = new Vector3(h, 0.0f, -v);
            }
                
            force = Camera.main.transform.TransformDirection(force);
            force.y = 0f;

            this.GetComponent<CharacterController>().SimpleMove(force * _Speed * Time.deltaTime);
            if (h != 0 || v != 0) //Input to move the player
            {
                //Move Player
                CharacterAnimator.SetTrigger("Running");

            }
            else
            {
                CharacterAnimator.SetTrigger("Idle");
            }
            Vector3 lookAt = this.transform.position - _PrevPosition;
            lookAt.y = 0;
            if (lookAt != new Vector3(0, 0, 0))
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(lookAt), Time.deltaTime * _RotationSpeed);
            }


            _PrevPosition = this.transform.position;

            if (_IsDamaged)
            {
                _damageTimer += Time.deltaTime;
                if (_damageTimer >= _maxDamageTime)
                {
                    _damageTimer = 0;
                    _IsDamaged = false;
                }
            }
        }
        else
        {
            _deathTimer += Time.deltaTime;
            if(_deathTimer > 4)
            {
                SceneManager.LoadScene("Level1");
            }
           
        }
   
    }

    public void AddDice(int add)
    {
        AmountOfDice += 1;
    }
    public void RemoveDice(int rem)
    {
        AmountOfDice -= 1;
    }
    public int GetDiceAmount()
    {
        return AmountOfDice;
    }
    public int GetRemainingLives()
    {
        return lives;
    }
    public void AddHealth(int add)
    {
        health += add;
        Debug.Log(health);
    }
    public void RemoveHealth(int rem)
    {
        if (_IsPlayerDead == false)
        {
            if (_IsDamaged)
            {
                return;
            }

            health -= rem;
            _IsDamaged = true;
        }
    }
    public int GetHealth()
    {
        return health;
    }

    public void AddPowerGem(int add)
    {
        if(_PowerGems <= 4)
        {
            _PowerGems += add;
            //CharacterAnimator.SetTrigger("Take_Item");
        }
        else
        {
            _PowerGems = 4;
        }
    }

    public void RemovePowerGem(int rem)
    {
        if (_PowerGems >= 0)
        {
            _PowerGems -= rem;
        }
        else
        {
            _PowerGems = 0;
        }
    }

    public int GetPowerGemTotal()
    {
        return _PowerGems;
    }

    public void SetSpeed(float sp)
    {
        _Speed = sp;
    }
    public float GetSpeed()
    {
        return _Speed;
    }

}
