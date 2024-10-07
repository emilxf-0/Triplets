using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PointsEffect", menuName = "Pickups/Effects/PointsEffect")]
public class PointsEffect : ScriptableObject, IPickupEffect
{
    [SerializeField] int points;
    
    [SerializeField] private int defaultMultiplier = 3;
    private int multiplier = 0;

    void OnEnable()
    {
        multiplier = defaultMultiplier;
        EventManager.OnAddAvatar += UpdateMultiplier;
        EventManager.OnRestartGame += OnRestartGame;
    }

    void OnDisable()
    {
        EventManager.OnAddAvatar -= UpdateMultiplier;
        EventManager.OnRestartGame -= OnRestartGame;
    }

    void UpdateMultiplier()
    {
        multiplier++;
    }

    public void ApplyEffect(GameObject player)
    {   
        EventManager.AddScore(points * multiplier);
    }

    void OnRestartGame()
    {
        multiplier = defaultMultiplier;
    }
}