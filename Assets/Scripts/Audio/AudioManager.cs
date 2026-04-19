using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Fishing fishing;
    Player player;
    [SerializeField] private AudioSource fishBiteAudio,reelCastAudio,reelingAudio,failAudio,caughtAudio;
    private bool playedBiteAudio = false,playedCastAudio=false,playedReelingAudio=false,playedResultAudio=false;


    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        fishing = FindAnyObjectByType<Fishing>();
    }
    private void Update()
    {
        switch (player.currentState)
        {
            case Player.playerState.Waiting:
                if (!playedCastAudio)
                {
                    reelCastAudio.Play();
                    playedCastAudio = true;
                }
                playedBiteAudio = false;
                break;

            case Player.playerState.Bite:
                if (!playedBiteAudio)
                {
                    fishBiteAudio.Play();
                    playedBiteAudio = true;
                }
                playedCastAudio = false;
                break;
            case Player.playerState.Reeling:
                if (!playedReelingAudio)
                {
                    reelingAudio.loop = true;
                    reelingAudio.Play();
                    playedReelingAudio = true;
                }
                playedBiteAudio = false;
                break;

            case Player.playerState.Idle:
                playedBiteAudio = false;
                playedCastAudio = false;
                playedReelingAudio=false;
                playedResultAudio = false;
                break;

            case Player.playerState.Result:
                if (reelingAudio.isPlaying)
                {
                    reelingAudio.Stop();
                }

                if (!playedResultAudio)
                {
                    if (fishing.breakProgress >= fishing.rodBreakTimer || fishing.escapeProgress >= fishing.FishEscapeTimer)
                    {
                        failAudio.Play();
                    }
                    else
                    {
                        caughtAudio.Play();
                    }
                    playedResultAudio = true; // Lock it so it doesn't play every frame
                }
                break;
        }
    }
}
