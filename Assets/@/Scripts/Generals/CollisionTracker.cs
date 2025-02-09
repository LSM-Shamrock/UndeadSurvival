using System.Collections.Generic;
using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    #region private members
    private HashSet<Collision> _onCollisionEnters = new();
    private HashSet<Collision> _onCollisionExits = new();
    private HashSet<Collision> _onCollisionStays = new();

    private HashSet<Collider> _onTriggerEnters = new();
    private HashSet<Collider> _onTriggerExits = new();
    private HashSet<Collider> _onTriggerStays = new();

    private HashSet<Collision2D> _onCollisionEnter2Ds = new();
    private HashSet<Collision2D> _onCollisionExit2Ds = new();
    private HashSet<Collision2D> _onCollisionStay2Ds = new();

    private HashSet<Collider2D> _onTriggerEnter2Ds = new();
    private HashSet<Collider2D> _onTriggerExit2Ds = new();
    private HashSet<Collider2D> _onTriggerStay2Ds = new();
    #endregion

    #region public methods
    public bool IsCollisionEnter(Collision collision)
    { return _onCollisionEnters.Contains(collision); }
    public bool IsCollisionExit(Collision collision)
    { return _onCollisionExits.Contains(collision); }
    public bool IsCollisionStay(Collision collision)
    { return _onCollisionStays.Contains(collision); }

    public bool IsTriggerEnter(Collider other)
    { return _onTriggerEnters.Contains(other); }
    public bool IsTriggerExit(Collider other)
    { return _onTriggerExits.Contains(other); }
    public bool IsTriggerStay(Collider other)
    { return _onTriggerStays.Contains(other); }

    public bool IsCollisionEnter2D(Collision2D collision)
    { return _onCollisionEnter2Ds.Contains(collision); }
    public bool IsCollisionExit2D(Collision2D collision)
    { return _onCollisionExit2Ds.Contains(collision); }
    public bool IsCollisionStay2D(Collision2D collision)
    { return _onCollisionStay2Ds.Contains(collision); }

    private bool IsTriggerEnter2D(Collider2D collision)
    { return _onTriggerEnter2Ds.Contains(collision); }
    private bool IsTriggerExit2D(Collider2D collision)
    { return _onTriggerExit2Ds.Contains(collision); }
    private bool IsTriggerStay2D(Collider2D collision)
    { return _onTriggerStay2Ds.Contains(collision); }
    #endregion

    #region unity lifecycle methods
    private void FixedUpdate()
    {
        _onCollisionEnters.Clear();
        _onCollisionExits.Clear();
        _onCollisionStays.Clear();

        _onTriggerEnters.Clear();
        _onTriggerExits.Clear();
        _onTriggerStays.Clear();

        _onCollisionEnter2Ds.Clear();
        _onCollisionExit2Ds.Clear();
        _onCollisionStay2Ds.Clear();

        _onTriggerEnter2Ds.Clear();
        _onTriggerExit2Ds.Clear();
        _onTriggerStay2Ds.Clear();
    }

    private void OnCollisionEnter(Collision collision)
    { _onCollisionEnters.Add(collision); }
    private void OnCollisionExit(Collision collision)
    { _onCollisionExits.Add(collision); }
    private void OnCollisionStay(Collision collision)
    { _onCollisionStays.Add(collision); }

    private void OnTriggerEnter(Collider other)
    { _onTriggerEnters.Add(other); }
    private void OnTriggerExit(Collider other)
    { _onTriggerExits.Add(other); }
    private void OnTriggerStay(Collider other)
    { _onTriggerStays.Add(other); }

    private void OnCollisionEnter2D(Collision2D collision)
    { _onCollisionEnter2Ds.Add(collision); }
    private void OnCollisionExit2D(Collision2D collision) 
    { _onCollisionExit2Ds.Add(collision); }
    private void OnCollisionStay2D(Collision2D collision) 
    { _onCollisionStay2Ds.Add(collision); }

    private void OnTriggerEnter2D(Collider2D collision) 
    { _onTriggerEnter2Ds.Add(collision); }
    private void OnTriggerExit2D(Collider2D collision) 
    { _onTriggerExit2Ds.Add(collision); }
    private void OnTriggerStay2D(Collider2D collision) 
    { _onTriggerStay2Ds.Add(collision); }
    #endregion
}
