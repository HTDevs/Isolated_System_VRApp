using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Sirenix.OdinInspector;

public class TaskController : MonoBehaviour
{
    [ReadOnly]
	[SerializeField]
    [BoxGroup("Test Info")]
    private int oxigenTanks = 0;
    [ReadOnly]
	[SerializeField]
    [BoxGroup("Test Info")]
    private float oxigen = 120f;
    [ReadOnly]
	[SerializeField]
    [BoxGroup("Test Info")]
    private float reserves = 60f;
    [Space]
    [ReadOnly]
    [SerializeField]
    [BoxGroup("Test Info")]
    private bool[] taskStatements = new bool[5];
    [Space]
    [ReadOnly]
    [SerializeField]
    [BoxGroup("Test Info")]
    private bool[] itemsCollected = new bool[5];
    
    [Title("User Interface")]
    [SerializeField]
    private Slider oxygenSlider;
    [SerializeField]
    private Slider reservesSlider;
    [SerializeField]
    private Text oxygenTankText;
    [SerializeField]
    private Animator gameOverAnim;

    [Title("Emergency Statate Values")]
    [SerializeField]
    private GameObject warning;
    [SerializeField]
    private GameObject alarms;
    [SerializeField]
    private Animator emergencyVolumeAnimator;
    [ReadOnly]
	[SerializeField]
    private bool isEmergencyState = false;

    public int OxigenTanks { get { return oxigenTanks; } set { oxigenTanks = value; } }
    public bool[] TaskStatements { get { return taskStatements; } set { taskStatements = value; } }
    public bool[] ItemsCollected { get { return itemsCollected; } set { itemsCollected = value; } }
    public static TaskController Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        oxigen -= Time.deltaTime;

        if (isEmergencyState)
        {
            if (oxigen < 0f)
            {
                oxigen = 0f;
                reserves -= Time.deltaTime;

                if (reserves < 0f)
                {
                    if (oxigenTanks > 0)
                    {
                        oxigenTanks--;
                        reserves = 30f;
                    }
                    else
                    {
                        reserves = 0f;
                        enabled = false;
                        gameOverAnim.SetTrigger("Lost");
                        Invoke("LoadMenu", 5f);
                    }
                }
            }
        }
        else
        {
            if (oxigen < 60f)
            {
                AudioController.Instance.PlayAudio(3);
                warning.SetActive(true);
                alarms.SetActive(true);
                emergencyVolumeAnimator.SetTrigger("EmergencySwitcher");
                isEmergencyState = true;
            }
        }

        oxygenSlider.value = oxigen;
        reservesSlider.value = reserves;
        oxygenTankText.text = "x" + oxigenTanks;
    }

    private void LoadMenu()
    {
        GameController.Instance.LoadScene(0);
    }

    public void TaskComplete(int index)
    {
        taskStatements[index] = true;

        foreach (bool item in taskStatements)
        {
            if (!item)
            {
                return;
            }
        }

        if (isEmergencyState)
        {
            SolveEmergency();
        }
        
        enabled = false;
        gameOverAnim.SetTrigger("Win");
        Invoke("LoadMenu", 5f);
    }

    public void SolveEmergency()
    {
        AudioController.Instance.StopAudio(3);
        warning.SetActive(false);
        alarms.SetActive(false);
        emergencyVolumeAnimator.SetTrigger("EmergencySwitcher");
        isEmergencyState = false;
    }
}