using UnityEngine;


[CreateAssetMenu(fileName = "NewFishData", menuName = "Fishing/Fish Data")]
public class FishData : ScriptableObject
{
    public string fishName;

    public enum Rarity { Common, Uncommon, Rare }
    public Rarity rarity;

    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty difficulty;

    public Sprite fishIcon;
}
