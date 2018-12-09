using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent( typeof( Image ) )]
public class ButtonHoverImageChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image { get { return GetComponent<Image>(); } }

	public Sprite normalImage;
	public Sprite hoverImage;

    public void OnPointerEnter( PointerEventData eventData )
    {
        image.sprite = hoverImage;
        AudioPlayer.PlaySE(SEType.Cheer1);
    }

    public void OnPointerExit( PointerEventData eventData )
    {
		image.sprite = normalImage;
    }
}