using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAudio : MonoBehaviour 
{
	private AudioSource source;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text volumeValue;

	private void Start () 
    {
		source = GameObject.FindObjectOfType<AudioSource>();
		if (!PlayerPrefs.HasKey ("volume"))
		{
			PlayerPrefs.SetFloat ("volume", 0.5f);
		} 
		else
		{
			volumeSlider.value = PlayerPrefs.GetFloat ("volume");
		}
	}

    void Update()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        source.volume = volumeSlider.value = PlayerPrefs.GetFloat("volume");
        volumeValue.text = "Volume: "+Mathf.Round(volumeSlider.value * 100);
    }

    public void PlayAudio(AudioClip newClip, bool loop)
    {
        if (source != null)
        {
            if (source.clip != newClip)
            {
                source.Stop();
                source.clip = newClip;
                source.loop = loop;
                source.Play();
            }
        }
    }
}
