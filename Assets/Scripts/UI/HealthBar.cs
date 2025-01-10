using UnityEngine;

public class HealthBar : WorldSpaceUI
{
    [SerializeField]
    private RectTransform fill;

    private Player player;
    private Vector3 offsetVector =  Vector3.up * 2f;

    protected override void Awake()
    {
        base.Awake();

        player = GameManager.Player;
    }

    protected override void Update()
    {
        base.Update();

        transform.position = player.transform.position + offsetVector;

        float _value;
        if (player.MaxHealth != 0)
        {
            _value = (float)player.CurHealth / player.MaxHealth;
        } 
        else
        {
            _value = 0;
        }
        Vector3 _scaleVec = Vector3.one;
        _scaleVec.x = _value;
        fill.localScale = _scaleVec;
    }
}
