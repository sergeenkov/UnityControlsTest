using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Fader : MonoBehaviour {
    [HideInInspector]
	public bool start = false;
    [HideInInspector]
    public float fadeDamp = 0.0f;
    [HideInInspector]
    public string fadeScene;
    [HideInInspector]
    public float alpha = 0.0f;
    [HideInInspector]
    public Color fadeColor;
    [HideInInspector]
    public bool isFadeIn = false;    

    private Image _image;
    private GameObject _fadeCanvas;

    //Set callback
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    //Remove callback
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void Start()
    {     
        _image = gameObject.GetComponent<Image>();
        _fadeCanvas = transform.parent.gameObject;
    }

    void Update()
    {        
        //Fallback check
        if (!start)
            return;

        if (_image == null)
            return;

        //Fade in and out control
        if (isFadeIn)
            alpha = Mathf.Lerp(alpha, -0.1f, fadeDamp * Time.deltaTime);
        else
            alpha = Mathf.Lerp(alpha, 1.1f, fadeDamp * Time.deltaTime);

        _image.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);

        //Load scene
        if (alpha >= 1 && !isFadeIn)
        {
            DontDestroyOnLoad(_fadeCanvas);
            SceneManager.LoadScene(fadeScene);            
        }
        else
        if (alpha <= 0 && isFadeIn)
        {
            Destroy(_fadeCanvas);
        }
    }    

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //We can now fade in
        isFadeIn = true;
    }

}
