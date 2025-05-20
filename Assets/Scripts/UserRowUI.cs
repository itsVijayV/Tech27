using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UserRowUI : MonoBehaviour
{
    public Text nameText, dobText, ageText, addressText;
    public Button deleteButton, updateButton;

    private UserData userData;
    private UserDataInput userDataInput;

    public void Initialize(UserData data, UserDataInput manager)
    {
        if (nameText == null) Debug.LogError("nameText is null!");
        if (dobText == null) Debug.LogError("dobText is null!");
        if (ageText == null) Debug.LogError("ageText is null!");
        if (addressText == null) Debug.LogError("addressText is null!");
        if (deleteButton == null) Debug.LogError("deleteButton is null!");
        if (updateButton == null) Debug.LogError("updateButton is null!");


        userData = data;
        userDataInput = manager;

        nameText.text = data.Name;
        dobText.text = data.DOB;
        ageText.text = data.Age;
        addressText.text = data.Address;

        deleteButton.onClick.RemoveAllListeners();
        deleteButton.onClick.AddListener(() => userDataInput.DeleteButton(userData));

        updateButton.onClick.RemoveAllListeners();
        updateButton.onClick.AddListener(() => userDataInput.UpdateButton(userData));
    }

}

