using System;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [Header("Fish Data Pools")]
    [SerializeField] FishData[] fishPool;
    private List<FishData> commonPool=new List<FishData>();
    private List<FishData> uncommonPool = new List<FishData>();
    private List<FishData> rarePool = new List<FishData>();
    public FishData currentFish;

    public float fishCatchTimeWindow=1.5f, reelProgress=0f,breakProgress=0f,escapeProgress=0f;
    public GameObject needle;

    public float rodBreakTimer = 10f, catchSuccessTimer = 10f, FishEscapeTimer=10f;

    
    [SerializeField] float fishBiteTimer;
    [SerializeField] float timer = 0f;
    [SerializeField] private GameObject fishingRod;
    [SerializeField] GameInput gameInput;

    
    [SerializeField] private float needleForce=5f;
    private Rigidbody2D needleRb;
    Player player;

    public event EventHandler<string> OnFishCaught;
    private bool hasTriggeredResult=false;

    private void Start()
    {
        needleRb = needle.GetComponent<Rigidbody2D>();
        fishBiteTimer = UnityEngine.Random.Range(2f, 10f);
        fishingRod.SetActive(false);
        player = GetComponent<Player>();
        foreach(FishData fish in fishPool)
        {
            if (FishData.Rarity.Common==fish.rarity)
            {
                commonPool.Add(fish);
            }
            else if (FishData.Rarity.Rare == fish.rarity)
            {
                rarePool.Add(fish);
            }
            else
            {
                uncommonPool.Add(fish);
            }
        }
    }
    private void Update()
    {
        if (player.currentState == Player.playerState.Idle)
        {
            if (fishingRod.activeInHierarchy)
            {
                fishingRod.SetActive(false);
            }
        }
        if (player.currentState == Player.playerState.Waiting)
        {
            

            fishingRod.SetActive (true);
            timer += Time.deltaTime;
            if (timer > fishBiteTimer)
            {
                float fishPicker = UnityEngine.Random.Range(0f, 100f);
                if (fishPicker < 10f)
                {
                    currentFish = rarePool[UnityEngine.Random.Range(0, rarePool.Count)];
                    rodBreakTimer = 4f;
                    FishEscapeTimer = 6f;
                    catchSuccessTimer = 15f;
                }
                else if (fishPicker < 30f)
                {
                    currentFish = uncommonPool[UnityEngine.Random.Range(0, uncommonPool.Count)];
                    rodBreakTimer = 7f;
                    FishEscapeTimer = 8f;
                    catchSuccessTimer = 10f;
                }
                else
                {
                    currentFish = commonPool[UnityEngine.Random.Range(0, commonPool.Count)];
                    rodBreakTimer = 10f;
                    FishEscapeTimer = 10f;
                    catchSuccessTimer = 7f;
                }
                    Debug.Log(currentFish.name+currentFish.rarity);
                fishBiteTimer = UnityEngine.Random.Range(2f, 10f);
                timer = 0f;
                player.currentState = Player.playerState.Bite;

                
            }
        }
        if (player.currentState == Player.playerState.Bite)
        {
            timer += Time.deltaTime;
            if (timer > fishCatchTimeWindow)
            {
                timer = 0f;
                player.currentState = Player.playerState.Idle;
                
            }
            if (gameInput.IsSpacePressed())
            {
                timer = 0f;
                player.currentState = Player.playerState.Reeling;
                
            }
            
        }

        if (player.currentState == Player.playerState.Reeling)
        {
            if (gameInput.IsSpacePressed())
            {
                needleRb.AddForce(new Vector2(0f, needleForce), ForceMode2D.Impulse);
            }
            timer+= Time.deltaTime;
            
           if(needle.transform.localPosition.y>-210f&& needle.transform.localPosition.y <= -70f)
            {
                escapeProgress += Time.deltaTime;
                reelProgress -= Time.deltaTime;
                breakProgress-= Time.deltaTime;
            }
           else if(needle.transform.localPosition.y > -70f && needle.transform.localPosition.y <= 70f)
            {
                reelProgress += Time.deltaTime;
                escapeProgress -= Time.deltaTime;
                breakProgress-=Time.deltaTime;
            }
            else
            {
                reelProgress -= Time.deltaTime;
                escapeProgress -= Time.deltaTime;
                breakProgress += Time.deltaTime;
            }
            if (reelProgress > catchSuccessTimer || breakProgress > rodBreakTimer || escapeProgress > FishEscapeTimer)
            {
                player.currentState = Player.playerState.Result;
            }
            
            reelProgress = Mathf.Max(0, reelProgress);
            escapeProgress = Mathf.Max(0, escapeProgress);
            breakProgress = Mathf.Max(0, breakProgress);
        }

        if (player.currentState == Player.playerState.Result)
        {
            if (reelProgress > catchSuccessTimer)
            {
                if (!hasTriggeredResult)
                {

                    OnFishCaught?.Invoke(this, currentFish.fishName);
                    timer = 0;
                    player.currentState = Player.playerState.Result;
                    hasTriggeredResult = true;
                }
             
            }
            if (escapeProgress > FishEscapeTimer)
            {
                timer = 0;

                player.currentState = Player.playerState.Result;
                
            }
            if (breakProgress > rodBreakTimer)
            {
                timer = 0;
                Debug.Log("Rode Broke");
                player.currentState = Player.playerState.Result;
                
            }
            if (gameInput.IsSpacePressed())
            {
                hasTriggeredResult = false;
                reelProgress = 0;
                escapeProgress = 0;
                breakProgress = 0;
                needle.transform.localPosition = new Vector3(needle.transform.localPosition.x, 0f, needle.transform.localPosition.z);
                player.blockCast = true;
                player.currentState = Player.playerState.Idle;
            }
        }

        
        
    }
}
