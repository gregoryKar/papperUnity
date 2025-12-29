
using paper;
using paper.effects;
using UnityEngine;

public class spriteBodyPart : bodyPart, IRend, IGraphic
{

    SpriteRenderer _rend;
    spriteGraphic _graphic;
    public override void init(enemy user)
    {
        //Debug.Log("spriteBodyPart init");
        _rend = GetComponent<SpriteRenderer>();
        _graphic = new spriteGraphic(_rend);

        base.init(user);
    }

    public SpriteRenderer getRend() => _rend;

    public graphicBase getGraphicFather() => _graphic;

}

