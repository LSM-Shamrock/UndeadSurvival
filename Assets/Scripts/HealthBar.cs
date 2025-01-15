using UnityEngine;

public class HealthBar : WorldSpaceUI
{
    [SerializeField]
    private RectTransform _fill;

    private Vector3 _offsetVector =  Vector3.up * 2f;
    public Transform TargetTransform { get; private set; }
    public IDamageable TargetDamageable { get; private set; }

    protected override void Awake()
    {
        SetTarget(GameManager.Player, GameManager.Player.transform);
    }

    protected override void Update()
    {
        base.Update();

        transform.position = TargetTransform.position + _offsetVector;

        float fillValue;
        if (TargetDamageable.MaxHealth == 0)
            fillValue = 0;
        else
            fillValue = (float)TargetDamageable.CurHealth / TargetDamageable.MaxHealth;
        
        Vector3 scaleVec = Vector3.one;
        scaleVec.x = fillValue;
        _fill.localScale = scaleVec;
    }

    public void SetTarget(IDamageable damageable, Transform transform)
    {
        TargetDamageable = damageable;
        TargetTransform = transform;
    }
}
