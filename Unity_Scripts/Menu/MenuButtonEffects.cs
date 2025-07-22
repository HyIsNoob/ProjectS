using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ProjectS.Menu
{
    public class MenuButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Visual Effects")]
        public float hoverScale = 1.1f;
        public float pressScale = 0.95f;
        public float animationSpeed = 5f;
        
        [Header("Color Effects")]
        public Color normalColor = Color.white;
        public Color hoverColor = Color.yellow;
        public Color pressColor = Color.gray;
        
        [Header("Shadow Effect")]
        public bool enableShadow = true;
        public Vector2 shadowOffset = new Vector2(5, -5);
        
        private Vector3 originalScale;
        private Vector3 targetScale;
        private Image buttonImage;
        private Text buttonText;
        private AudioManager audioManager;
        
        private void Start()
        {
            originalScale = transform.localScale;
            targetScale = originalScale;
            
            buttonImage = GetComponent<Image>();
            buttonText = GetComponentInChildren<Text>();
            audioManager = FindObjectOfType<AudioManager>();
            
            // Set initial color
            if (buttonImage != null)
                buttonImage.color = normalColor;
        }
        
        private void Update()
        {
            // Smooth scale animation
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.unscaledDeltaTime * animationSpeed);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            // Scale up on hover
            targetScale = originalScale * hoverScale;
            
            // Change color
            if (buttonImage != null)
                buttonImage.color = hoverColor;
            
            // Play hover sound
            if (audioManager != null)
                audioManager.PlayButtonHover();
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            // Return to normal scale
            targetScale = originalScale;
            
            // Return to normal color
            if (buttonImage != null)
                buttonImage.color = normalColor;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            // Scale down on press
            targetScale = originalScale * pressScale;
            
            // Change to press color
            if (buttonImage != null)
                buttonImage.color = pressColor;
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            // Return to hover scale
            targetScale = originalScale * hoverScale;
            
            // Return to hover color
            if (buttonImage != null)
                buttonImage.color = hoverColor;
            
            // Play click sound
            if (audioManager != null)
                audioManager.PlayButtonClick();
        }
        
        // Call this to add glowing effect
        public void AddGlowEffect()
        {
            // This can be expanded with Outline component or custom shader
            Outline outline = GetComponent<Outline>();
            if (outline == null)
                outline = gameObject.AddComponent<Outline>();
                
            outline.effectColor = Color.white;
            outline.effectDistance = new Vector2(2, 2);
        }
        
        // Call this to remove glowing effect
        public void RemoveGlowEffect()
        {
            Outline outline = GetComponent<Outline>();
            if (outline != null)
                Destroy(outline);
        }
    }
}
