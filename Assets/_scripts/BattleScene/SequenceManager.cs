using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    public class Player
    {
        public string name { get; set; }
        public float current { get; set; }
        public float speed { get; set; }
        public float timeToMove { get; set; }
        public Player(string name, float current,float speed) {
            this.name = name;
            this.current = current;
            this.speed = speed;
            this.timeToMove = 100 / speed;
        }
    }
    float p1speed = 10f;
    float p2speed = 8f;
    float p3speed = 20f;
    List<Player> seq=new List<Player>();
    List<Player> players = new List<Player>();

    private void Start()
    {
        Player p1 = new Player("p1", 0f, 10f);
        Player p2 = new Player("p2", 0f, 8f);
        Player p3 = new Player("p3", 0f, 20f);
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        seqBaseOnSpeed();
    }
    private void Update()
    {
        for(var i =0; i < seq.Count; i++)
        {
            Debug.Log(i+" " + seq[i].name);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {

            dequeuAndEnqueue();
        }
    }
    private void InitialSeq()
    {
        players.Sort((p1, p2) =>p1.timeToMove.CompareTo(p2.timeToMove));
        foreach (Player p in players)
        {
            Debug.Log("init seq"+p.name);
        }
        float firstRoundTime = players[0].timeToMove;
        players[0].current = 100;
        foreach(Player p in players)
        {
            if (p.current == 100) continue;
            p.current = firstRoundTime * p.speed;
        }
        players[0].current = -0.01f;
        Player tmp= players[0];
        players.RemoveAt(0);
        players.Add(tmp); 

    }
    private void CalNextMoveSeq()
    {
        foreach(Player p in players)
        {
            p.timeToMove = (100 - p.current) / p.speed;
        }
        players.Sort((p1, p2) => p1.timeToMove.CompareTo(p2.timeToMove));
        float timeToTake = players[0].timeToMove;
        foreach (Player p in players)
        {
            p.current = timeToTake * p.speed+p.current;
            Debug.Log("seq " + p.name + " " + p.current);
        }
    }

    private void seqBaseOnSpeed()
    {
        players.Sort((p1,p2)=>p2.speed.CompareTo(p1.speed));
        foreach(Player p in players)
        {
            seq.Add(p);
        }
    }
    private void dequeuAndEnqueue()
    {
        Player tmp = seq[0];
        seq.RemoveAt(0);
        seq.Add(tmp);
    }
}
