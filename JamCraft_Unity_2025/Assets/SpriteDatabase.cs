using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpriteDatabase", menuName = "Custom/Sprite Database")]
public class SpriteDatabase : ScriptableObject
{
    [System.Serializable]
    public class SpriteMapping
    {
        public string id;
        public Sprite sprite;
    }

    [SerializeField]
    private List<SpriteMapping> mappings = new List<SpriteMapping>();

    // Dictionary for quick lookups (built at runtime)
    private Dictionary<string, Sprite> spriteLookup;

    // Initialize the dictionary when first accessed
    private void BuildLookupIfNeeded()
    {
        if (spriteLookup == null)
        {
            spriteLookup = new Dictionary<string, Sprite>();
            foreach (var mapping in mappings)
            {
                if (!string.IsNullOrEmpty(mapping.id) && mapping.sprite != null)
                {
                    spriteLookup[mapping.id] = mapping.sprite;
                }
            }
        }
    }

    // Get a sprite by ID
    public Sprite GetSprite(string id)
    {
        BuildLookupIfNeeded();

        Sprite result;
        if (spriteLookup.TryGetValue(id, out result))
        {
            return result;
        }

        Debug.LogWarning($"Sprite with ID '{id}' not found in database.");
        return null;
    }

    // Check if a sprite exists for the given ID
    public bool HasSprite(string id)
    {
        BuildLookupIfNeeded();
        return spriteLookup.ContainsKey(id);
    }
}