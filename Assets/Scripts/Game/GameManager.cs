using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    /// <summary>
    /// A holder for game events
    /// </summary>
    public class EventManager
    {
        public event Action OnUpdateEvent;
        public event Action OnFixedUpdateEvent;
        public event Action OnLateUpdateEvent;

        public void OnUpdate()
        {
            if(OnUpdateEvent != null)
                OnUpdateEvent();
        }
        public void OnLateUpdate()
        {
            if(OnFixedUpdateEvent != null)
                OnLateUpdateEvent();
        }
        public void OnFixedUpdate()
        {
            if(OnFixedUpdateEvent != null)
                OnFixedUpdateEvent();
        }
    }
    //A static holder of the current GameManager
    public static GameManager INSTANCE { get; private set; }
    public EventManager Events { get; private set; }
    public bool InGui { get; private set; }

    public Canvas gui;

	// Use this for preinitialization
	void Awake () {
        //Endure there is only ever 1 GameManager Active
        if (INSTANCE != null)
        {
            Destroy(this);
            return;
        }
        //Create Static Accessor to avoid FindGameObject calls
        INSTANCE = this;
        Events = new EventManager();
	}
	
	// Update is called once per frame
	void Update () {
        Events.OnUpdate();
	}
    // LateUpdate is called at the end of every frame
    void LateUpdate()
    {
        Events.OnLateUpdate();
    }
    //Called every fixed time setp
    void FixedUpdate()
    {
        Events.OnFixedUpdate();
    }

    public void SetGui(Canvas gui)
    {
        if (this.gui != null)
            CloseGui();
        gui.gameObject.SetActive(true);
        this.gui = gui;
        InGui = true;
    }
    public void CloseGui()
    {
        gui.gameObject.SetActive(false);
        gui = null;
        InGui = false;
    }

    //Called when the gamemanager is destoryed (Is called after game ends)
    void OnDestroy()
    {
        if (INSTANCE == this)
            INSTANCE = null;
    }
}
