using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Player player;
    Fishing fishing;
    GameInput gameInput;
    [SerializeField] private GameObject reelingUI, escapeWarningUI, BreakingWarningUI, BreakedUI, EscapedUI, caughtUI,biteUI,clickCastUI,balanceUI;
    [SerializeField] private Image fishImageDisplay;
    [SerializeField] private TextMeshProUGUI fishName, fishRarity;

    private void Start()
    {
        reelingUI.SetActive(false);
        player = FindAnyObjectByType<Player>();
        gameInput = FindAnyObjectByType<GameInput>();
        fishing=FindAnyObjectByType<Fishing>();
    }

    private void Update()
    {
        switch (player.currentState)
        {
            case (Player.playerState.Idle):

                reelingUI.SetActive(false);
                escapeWarningUI.SetActive(false);
                BreakingWarningUI.SetActive(false);
                BreakingWarningUI.SetActive(false);
                BreakedUI.SetActive(false);
                EscapedUI.SetActive(false);
                caughtUI.SetActive(false);
                biteUI.SetActive(false);

                clickCastUI.SetActive(true);
                
                    break;
            case Player.playerState.Waiting:
                clickCastUI.SetActive(false);
                break;
            case Player.playerState.Bite:
                biteUI.SetActive(true);
                break;
            case Player.playerState.Reeling:
                balanceUI.SetActive(true);
                biteUI.SetActive(false);
                reelingUI.SetActive(true);

                if (fishing.needle.transform.localPosition.y > -210f && fishing.needle.transform.localPosition.y <= -70f)
                {
                    BreakingWarningUI.SetActive(false);
                    escapeWarningUI.SetActive(true);
                }
                else if (fishing.needle.transform.localPosition.y > -70f && fishing.needle.transform.localPosition.y <= 70f)
                {
                    BreakingWarningUI.SetActive(false);
                    escapeWarningUI.SetActive(false);
                }
                else
                {
                    escapeWarningUI.SetActive(false);
                    BreakingWarningUI.SetActive(true);
                }
                break;



            case Player.playerState.Result:
                balanceUI.SetActive(false);
                reelingUI.SetActive(false);
                BreakingWarningUI.SetActive(false);
                escapeWarningUI.SetActive(false);
                if (fishing.reelProgress > fishing.catchSuccessTimer)
                {
                    caughtUI.SetActive(true);
                    fishImageDisplay.sprite = fishing.currentFish.fishIcon;
                    fishName.text=fishing.currentFish.fishName;
                    fishRarity.text=fishing.currentFish.rarity.ToString();

                }
                else if (fishing.breakProgress > fishing.rodBreakTimer)
                {
                    BreakedUI.SetActive(true);

                }
                else if(fishing.escapeProgress>fishing.FishEscapeTimer)
                {
                    EscapedUI.SetActive(true);
                }
                break;

        }
    }


}
