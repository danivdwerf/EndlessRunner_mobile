using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SqlSet : MonoBehaviour
{
    private string secretKey = "Mustard";
	private string addScoreURL = "http://freetimedev.com/Highscores/setScore.php?";
    private md5 md5script;

    void Start()
    {
        md5script = GetComponent<md5>();
    }
    public void SetScore(string playerName)
    {
        StartCoroutine(PostScores(playerName,PlayerPrefs.GetInt("curScore")));
    }

    IEnumerator PostScores(string name, int score)
    {
        string hash = md5script.Md5Sum(name + score + secretKey);
        string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
        WWW hs_post = new WWW(post_url);
        yield return hs_post;

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }
}