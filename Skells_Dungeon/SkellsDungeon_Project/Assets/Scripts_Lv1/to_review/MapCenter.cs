using UnityEngine;
using System.Collections;

public class MapCenter : MonoBehaviour {

    [SerializeField]
    private Transform transMapCenter;
    [SerializeField]
    private Transform transPlayer;
    [SerializeField]
    private Transform transCamera;
    [SerializeField]
    private float fCloseUpDistance = 1.0f;

    enum Focus
    {
        MapCenter,
        Player,
    }

    [SerializeField]
    private Focus focus = Focus.MapCenter;

	void Update ()
    {
        CheckFocus();
        Controls();
	}

    private void ToggleFocus()
    {
        if(focus == Focus.MapCenter)
        {
            focus = Focus.Player;
            Zoom();
            return;
        }
        else if (focus == Focus.Player)
        {
            focus = Focus.MapCenter;
            Zoom();
            return;
        }
    }

    private void CheckFocus()
    {
        switch (focus)
        {
            case Focus.MapCenter:
                if (Vector3.Distance(transMapCenter.position, new Vector3(0.0f, transPlayer.position.y, 0.0f)) > 0.01f)
                {
                    transMapCenter.position = Vector3.Lerp(transMapCenter.position, new Vector3(0.0f, transPlayer.position.y, 0.0f), 0.1f);
                }
                break;

            case Focus.Player:
                if (Vector3.Distance(transMapCenter.position, transPlayer.position) > 0.01f)
                {
                    transMapCenter.position = Vector3.Lerp(transMapCenter.position, transPlayer.position, 0.1f);
                }
                break;
        }
    }

    private void Zoom()
    {
        switch (focus)
        {
            case Focus.MapCenter:
                transCamera.gameObject.GetComponent<CameraCTRL>().SetCamOffset(Vector3.zero);
                break;

            case Focus.Player:
                Vector3 playerToNewCamPos = -transCamera.forward.normalized * fCloseUpDistance + transform.position;
                Vector3 offset = transform.position - playerToNewCamPos;
                transCamera.gameObject.GetComponent<CameraCTRL>().SetCamOffset(offset);
                break; 
        }
    }

    private void Controls()
    {
        if(Input.GetKeyDown(KeyCode.CapsLock) || Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            ToggleFocus();
            return;
        }
    }
}
