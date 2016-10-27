using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FetchName : MonoBehaviour  
{
    private string username;
    private LeaderboardUIHandler uiHandler;
    private SqlSet sql;
	private SqlGet sqlGet;
    [SerializeField]private InputField inputField;
    [SerializeField]private Button confirm;
    private void Start()
    {
        uiHandler = GetComponent<LeaderboardUIHandler>();
        sql = GetComponent<SqlSet>(); 
		sqlGet = GetComponent<SqlGet>();
        confirm.onClick.AddListener(delegate(){GetInput();});
    }
    private void GetInput()
    {
        username=inputField.text;
        uiHandler.deleteInputUI();
        sql.SetScore(username);
		sqlGet.GetScore();
    }
    public string GetName
    {
        get
        { 
            return username;
        }
    }
}
