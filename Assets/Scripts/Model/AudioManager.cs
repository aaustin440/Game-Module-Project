using UnityEngine.Audio;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{
	[SerializeField] playerScript playerScript2;
	public Sound[] sounds;
	public GameObject AudioManager2;
	public static AudioManager Instance  = null; //singleton Instance
		
	 public enum AudioSounds
    {
        walk_SFX = 0,
        jump_SFX = 1,
        land_SFX = 2,
		hit_SFX = 3,
    }
	
	// Initialize the singleton Instance.
	 public void Awake()
	{
		//base.Awake();
		// Sound s = new Sound();
		//s.source = gameObject.AddComponent<AudioSource>();
	
		 foreach (Sound s  in sounds)
		{
			s.source = AudioManager2.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			//playerScript2.audioManagerScript.s.source.loop = s.source.loop;
			//s.source.loop = s.loop;
			//s.source.name = s.name;
			
			//print("sound name= " + s.source.name);
		}
	}
	


	public void Play(string name)

    {
		print("playing");
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		        // var s = FindAudioClip(name);
		}else{
				s.source.PlayOneShot(s.clip, s.volume);
				print("playing sound" + name);
		}
	

        // if (s != null)
        // {
        //     if (!s.source.isPlaying)
        //     {
        //         s.source.Play();
        //     }
        // }
    }

	// public void StopPlaying (string sound)
	// {
	// 	Sound s = Array.Find(sounds, item => item.name == sound);
	// 	if (s == null)
	// 	{
	// 	Debug.LogWarning("Sound: " + name + " not found!");
	// 	return;
 	//  }

	  private Sound FindAudioClip(AudioSounds name)
    {
        return Array.Find(sounds, sound => sound.name == Enum.GetName(typeof(AudioSounds), name));
    }
	// public void Play(string name)
	// {
		
	// 	Sound s = Array.Find(sounds, sound => sound.name == name);
	// 	if(name == null)
	// 	{
	// 		print("null");
	// 	}else
	// 	{
	// 		print(name);
	// 		print(s.source.name);
			
	// 	}
	// 	s.source.Play();
	// 	return;


		//   var s = FindAudioClip(name);

        // if (s != null)
        // {
        //     if (!s.source.isPlaying)
        //     {
        //         s.source.Play();
		// 		print("playing sound");
		// 	}
		// }
	
}

