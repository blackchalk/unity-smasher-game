using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualLevelUnlock : MonoBehaviour {

    public SpriteRenderer LevelObject;//Level object renderer in the scene (assign from hierarchy panel);
    public SpriteRenderer Stats;                //Level stats renderer in the scene (assign from hierarchy panel);
    public int LevelIndex;                      //Level index, can be found in the build settings;
    public bool unlocked;                       //Is level unlocked? you can unlock it as default;
    public bool isFinished;                     //Is level finished?
    public int starsCount;

    public Sprite LevelUnlocked;                //Unlocked level sprite;
    public Sprite LevelLocked;                  //Locked level sprite;
                                                //Stars;
    public Sprite OneStar;
    public Sprite TwoStars;
    public Sprite ThreeStars;

    private Vector2 touchPos;
    private CameraControls cam;         // Camera controls reference;
    private float touchTime;            // How long touch time;
    private float reactTime = 0.25F;		// Fixed touch time to level loading happens;

    public GameObject go_NextLevel;
    private ManualLevelUnlock mnl;
    void Awake()
    {
        cam = Camera.main.GetComponent<CameraControls>();
        mnl = go_NextLevel.GetComponent<ManualLevelUnlock>();
        if (PlayerPrefs.HasKey("currentCamPos") && cam.cameraPosition == CameraControls.CameraPosition.SaveCurrent)
        {
            cam.defaultPosition = PlayerPrefsX.GetVector3("currentCamPos");
        }
        //Check if player prefs have any data with levels indexes, if so - assign;

        if (PlayerPrefs.HasKey("isFinished" + LevelIndex.ToString()))
        {
            isFinished = PlayerPrefsX.GetBool("isFinished" + LevelIndex.ToString());
        }
        if (PlayerPrefs.HasKey("startsCount" + LevelIndex.ToString()))
        {
            starsCount = PlayerPrefs.GetInt("startsCount" + LevelIndex.ToString());
        }
        //draw stats depends on how much stars we gained;
        if (starsCount == 1) { Stats.sprite = OneStar; }
        if (starsCount == 2) { Stats.sprite = TwoStars; }
        if (starsCount == 3) { Stats.sprite = ThreeStars; }

        //unlock next level;
        if (starsCount >= 1) {
            mnl.unlocked = true;
        }

        //draw unlock level sprite if level is unlocked and conversely;
        if (unlocked)
        {
            Stats.gameObject.SetActive(true);
            LevelObject.sprite = LevelUnlocked;
        }
        else
        {
            Stats.gameObject.SetActive(false);
            LevelObject.sprite = LevelLocked;
        }
    }


    // Update is called once per frame
    void Update () {
        //Detecting if LevelObject sprite contains touch position and if so, load it if unlocked;

        if (Input.GetMouseButton(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
     //       for (int i = 0; i < levelList.Count; i++)
           // {
                if (unlocked && LevelObject.bounds.Contains(touchPos) && touchTime < reactTime)
                {
                    SceneManager.LoadScene(LevelIndex);
                    PlayerPrefsX.SetVector3("currentCamPos", cam.transform.position);
                }
           // }
            touchTime = 0;
        }
    }
}
