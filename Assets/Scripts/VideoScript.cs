using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoScript : MonoBehaviour
{
    [SerializeField] [Tooltip("Video a reproducir")]
    private VideoPlayer video;

    // UI
    [SerializeField]
    private Image imageCanvas;
    [SerializeField]
    private Sprite imagePlay;
    [SerializeField]
    private Sprite imageStop;
    [SerializeField]
    private Button btn;
    [SerializeField]
    private Text textBtn;

    // Anims
    [SerializeField]
    [Tooltip("Animator de la palanca")]
    private Animator leverAnimator;


    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
    }

    private void Start()
    {
        video.source = VideoSource.Url;
        video.url = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"; // URL remota
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            videoManager();
        }
    }

    private void OnMouseDown()
    {
        videoManager();
    }

    public void videoManager() 
    {
        if (video.isPlaying)
        {
            pauseVideo();
        }
        else
        {
            playVideo();
        }
    }

    private void playVideo()
    {
        leverAnimator.SetBool("Up", true);
        textBtn.text = "STOP";
        btn.image.color = Color.red;
        imageCanvas.sprite = imageStop;
        video.Play();
    }
    private void pauseVideo()
    {
        leverAnimator.SetBool("Up", false);
        btn.image.color = Color.green;
        textBtn.text = "PLAY";
        imageCanvas.sprite = imagePlay;
        video.Pause();
    }
}
