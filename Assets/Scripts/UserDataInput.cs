using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UserDataInput : MonoBehaviour
{
    public InputField nameFeild, dobFeild, ageFeild, addressFeild;
    public UnityEngine.UI.Button addButton, deleteButton, updateButton;

    public Transform contentPanel;
    public GameObject userRowPrefab;

    private List<UserData> users = new List<UserData>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // add data
    public void AddButton()
    {
        string name = nameFeild.text;
        string dob = dobFeild.text;
        string age = ageFeild.text;
        string address = addressFeild.text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(address))
        {
            Debug.LogWarning("All fields must be filled before adding!");
            return;
        }

        UserData newUser = new UserData(name, dob, age, address);
        users.Add(newUser);

        RefreshUserGrid();
    }

    // delete the row

    public void DeleteButton(UserData user)
    {
        users.Remove(user);
        RefreshUserGrid();
    }

    // update values
    public void UpdateButton(UserData user)
    {
        user.Name = nameFeild.text;
        user.DOB = dobFeild.text;
        user.Age = ageFeild.text;
        user.Address = addressFeild.text;

        RefreshUserGrid();
    }



    // update and delete and add relect
    private void RefreshUserGrid()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (UserData user in users)
        {

            GameObject rowObj = Instantiate(userRowPrefab, contentPanel);
            UserRowUI rowUI = rowObj.GetComponent<UserRowUI>();
            rowUI.Initialize(user, this);
        }
    }
}


// Store all the data in the class to pass the values
public class UserData
{
    public string Name;
    public string DOB;
    public string Age;
    public string Address;

    public UserData(string name, string dob, string age, string address)
    {
        Name = name;
        DOB = dob;
        Age = age;
        Address = address;
    }
}
