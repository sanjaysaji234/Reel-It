using TMPro;
using UnityEngine;

public class FishCounter : MonoBehaviour
{
    Fishing fishing;
    [SerializeField] TextMeshProUGUI goldenFish, redFish, catFish;
    private int catFishCount = 0, goldenFishCount = 0, redFishCount = 0;
    private void Start()
    {
        fishing = GetComponent<Fishing>();
        fishing.OnFishCaught += Fishing_OnFishCaught;
    }

    private void Fishing_OnFishCaught(object sender, string e)
    {
        if(e=="Coastal CatFish")
        {
            catFishCount++;
            catFish.text="X"+catFishCount.ToString();
        }
        else if (e == "Majili Snapper")
        {
            redFishCount++;
            redFish.text = "X" + redFishCount.ToString();
        }
        else
        {
            goldenFishCount++;
            goldenFish.text="X"+goldenFishCount.ToString();
        }
    }

   

    private void Update()
    {
      
    }
}
