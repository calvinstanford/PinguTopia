using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkingManager : MonoBehaviour
{
    public static NetworkingManager instance;
    public static LogIn logIn;
    public string baseURL=@"https://pingutopiabackend20220829164959.azurewebsites.net/"; 

    public InputField emailInputField;
    public InputField passwordInputField;
    public InputField confirmPasswordInputField;

    public InputField loginEmailInputField;
    public InputField loginPasswordInputField;
    
    
    void Start()
    {
        instance = this;
    }

    
    void Update()
    {
        
    }

    public void RegistrationButton(){
        Register tempReg= new Register() {Email =emailInputField.text, Password= passwordInputField.text, password_confirmation=confirmPasswordInputField.text };
        StartCoroutine(Register(tempReg));
    }

    public void LoginButton(){
        StartCoroutine(LogIn());
    }

    public IEnumerator Register(Register register)
    {
      WWWForm form = new WWWForm();

        form.AddField("Email", emailInputField.text);
        form.AddField("username", emailInputField.text);
        form.AddField("password", passwordInputField.text);
        form.AddField("password_confirmation", confirmPasswordInputField.text);

        UnityWebRequest uwr = UnityWebRequest.Post(baseURL + "/api/Account/Register", form);

        
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error" + uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);
        }
    }

    public IEnumerator LogIn(){
        WWWForm form =  new WWWForm();

        form.AddField("grant_type","password");
        form.AddField("Email", emailInputField.text);
        form.AddField("username", loginEmailInputField.text);
        form.AddField("password", loginPasswordInputField.text);

        UnityWebRequest uwr = UnityWebRequest.Post(baseURL +"token", form);

        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError){
            Debug.Log("Error: "+ uwr.error);
        }
        else{
            Debug.Log(uwr.downloadHandler.text);
            logIn = JsonUtility.FromJson<LogIn>(uwr.downloadHandler.text);

            StartCoroutine(SaveData());
        }

    }
    
public IEnumerator SaveData(){                
       WWWForm form =  new WWWForm();

        form.AddField("Email", emailInputField.text);
        form.AddField("username", loginEmailInputField.text);
        form.AddField("UserData", "{score:15}");

        UnityWebRequest uwr = UnityWebRequest.Post(baseURL + "api/UserProfile", form);

        uwr.SetRequestHeader("Authorization", "Bearer " + logIn.access_token);

        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError){
            Debug.Log("Error: "+ uwr.error);
        }
        else{
            Debug.Log(uwr.downloadHandler.text);

        }
    }
    

}
