using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public TMP_InputField UsernameField;
    public Toggle Toggle;

    string[] adjs = new string[] {  "Amazing", "Awesome", "Blithesome", "Excellent", "Fabulous", "Fantastic", "Favorable", "Fortuitous", "Great", "Incredible", "Ineffable", "Mirthful", "Outstanding", "Perfect", "Propitious", "Remarkable", "Smart", "Spectacular",
                                    "Splendid", "Stellar", "Stupendous", "Super", "Ultimate", "Unbelievable", "Wondrous", "adaptable", "adventurous", "affable", "affectionate", "agreeable", "ambitious", "amiable", "amicable", "amusing", "brave", "bright", "broad-minded", "calm", "careful", "charming", "communicative", "compassionate", "conscientious", "considerate", "convivial", "courageous", "courteous", "creative", "decisive", "determined", "diligent", "diplomatic", "discreet", "dynamic", "easygoing", "emotional", "energetic", "enthusiastic", "exuberant", "fair-minded", "faithful", "fearless", "forceful", "frank", "friendly", "funny", "generous", "gentle", "good", "gregarious", "hard-working", "helpful", "honest", "humorous", "imaginative", "impartial", "independent", "intellectual", "intelligent", "intuitive", "inventive", "kind", "loving", "loyal", "modest", "neat", "nice", "optimistic", "passionate" };
    string[] names = new string[] { "bounderby","honeythunder","rosa","barbara","sharp","berry","pott","squod","fladdock","barley","limpkins","norris","tiny","dombey","arabella","turveydrop","lambert","filer","morris","present","chopkins","leeford","strong","major","bobster","cleaver","borum","pugstyles",
                                    "may","edmund","aunt","children","jenkins","chicken","tobias","dot","fanny","marion","scadder","whimple","biddy","trabb","pip","fagin","johnson","simon","phib","horatio","bradley","miss","simmonds","young","avenger","drood","priscilla","wegg","tupman","flintwinch","copperfield","alfred","snewkes","kenwigs","plornish","bart","single","jobling","smauker","charley","sydney","caroline","gills","bodgers","ann","harry","pawkins","shepherd","gazingi","beadwood","mortimer","drummle","richard","tungay","tomkins","defarge","weevle","slowboy","britain","rugg","bevan","childers","lady","fielding","clickett","parent","chestle","emily","gregsbury","donny","hannibal","tutor","soldier","sheriff","critic","artiste","agent","subaltern","estimator","director","realtor","ranchers","judge","traveler","sailor","brewer","chemist","undertaker","trainer","merchant","millwright","engineer","acrobat","robber","singer","auditor","cook","mortician" };

    void Start()
    {
        if(Toggle) {
            if(PlayerPrefs.HasKey("Fullscreen")) {
                if(PlayerPrefs.GetInt("Fullscreen") == 0) {
                   Toggle.isOn = false; 
                } else {
                    Toggle.isOn = true;
                }
            } else {
                Toggle.isOn = false;
                PlayerPrefs.SetInt("Fullscreen", 0);
            }
        }

        var rnd = new System.Random();
        if(UsernameField != null && PlayerPrefs.HasKey("Username")) {
            UsernameField.text = PlayerPrefs.GetString("Username");
        }
        else if(UsernameField != null && !PlayerPrefs.HasKey("Username")) {
            UsernameField.text = $"{adjs[rnd.Next(0, adjs.Length)]} {names[rnd.Next(0, names.Length)]}";
        }
    }

    void Update()
    {
        
    }

    // TODO: refactor CreditsButtonClick and BackToMenu to a unified scene changer
    public void CreditsButtonClick()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveButtonClick()
    {
        if(UsernameField.text.Length > 0) {
            PlayerPrefs.SetString("Username", UsernameField.text);
        }
        Screen.fullScreen = Toggle.isOn;
        Debug.Log(Toggle.isOn);
        PlayerPrefs.SetInt("Fullscreen", Toggle.isOn ? 1 : 0);
    }
}