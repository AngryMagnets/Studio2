using System.Xml.Serialization;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinPrefab;
    [SerializeField] private Transform pinPosition;
    [SerializeField] private InputManager inputManager;

    private GameObject pinObject;

    private FallTrigger[] pins = null;
    void Start()
    {
        setTriggers();
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }
    void IncrementScore ()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
    private void HandleReset ()
    {
        ball.ResetBall();
        SetPins();
    }
    private void SetPins ()
    {
        if (pinObject)
        {
            foreach (Transform child in pinObject.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObject);
        }
        pinObject = Instantiate(pinPrefab, pinPosition.position, Quaternion.identity, transform);

        setTriggers();

    }
    private void setTriggers ()
    {

        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }
}
