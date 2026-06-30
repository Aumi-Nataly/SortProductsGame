using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] 
    private AudioClip goodSourceClip;

    [SerializeField]
    private AudioClip buttonSourceClip;

    [SerializeField]
    private AudioClip badSourceClip;

    [SerializeField]
    private AudioClip winSourceClip;

    [SerializeField]
    private AudioClip defeatSourceClip;
    public static SoundManager Instance { get; private set; }

    private AudioSource goodSource;
    private AudioSource buttonSource;
    private AudioSource badSource;
    private AudioSource winSource;
    private AudioSource defeatSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        goodSource = gameObject.AddComponent<AudioSource>();
        goodSource.clip = goodSourceClip;
        goodSource.volume = 1f;

        buttonSource = gameObject.AddComponent<AudioSource>();
        buttonSource.clip = buttonSourceClip;
        buttonSource.volume = 1f;

        badSource = gameObject.AddComponent<AudioSource>();
        badSource.clip = badSourceClip;
        badSource.volume = 1f;

        winSource = gameObject.AddComponent<AudioSource>();
        winSource.clip = winSourceClip;
        winSource.volume = 1f;

        defeatSource = gameObject.AddComponent<AudioSource>();
        defeatSource.clip = defeatSourceClip;
        defeatSource.volume = 1f;
    }


    public void PlayButtonSource()
    {
        if (buttonSource == null || buttonSourceClip == null)
            return;
        buttonSource.PlayOneShot(buttonSourceClip);
    }

    public void PlayGoodSource()
    {
        if (goodSource == null || goodSourceClip == null)
            return;
        goodSource.PlayOneShot(goodSourceClip);
    }

    public void PlayBadSource()
    {
        if (badSource == null || badSourceClip == null)
            return;
        badSource.PlayOneShot(badSourceClip);
    }

    public void PlayWinSource()
    {
        if (winSource == null || winSourceClip == null)
            return;
        winSource.PlayOneShot(winSourceClip);
    }

    public void PlayDefeatSource()
    {
        if (defeatSource == null || defeatSourceClip == null)
            return;
        defeatSource.PlayOneShot(defeatSourceClip);
    }
}
