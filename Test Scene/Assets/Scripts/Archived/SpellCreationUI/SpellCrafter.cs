using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCrafter : MonoBehaviour
{
    //public List<SpellInfo> spellList;

    private void Awake()
    {
        //spellList = new List<SpellInfo>();
        //SPELL LIST BEING MOVED TO SPELLSCROLLLIST

        //Add spells to a list somehow that 
        //spellList.Add(//)

        //TO DO
        // - Add a compareto in SpellInfo so that List.sort() can be used

        /*
        Need to make a way for each spell to store:
            How many tiers it has
            What materials / how much of each per tier
            Damage, dooldown, etc per tier
            Allowed modifiers
        

        IDEA 1:
        Might need to make a new Object that can store this for every spell

            public SpellInfo (Spell spellInQuestion,
                                 bool unlocked,
                                 materialsRequired[tier][amount],
                                 stats[tier][value],
                                 allowedModifiers)

        Notes:
        - materialsRequired is a 2d array where the first dimension is which tier is in question and the second
          dimension is how much of each material is required
            - the index of the second dimension determines which material is requirerd. Therefore, the length 
              of the second dimension is how many materials exist in the game and if there is a 0 in that dim
              then that material wont be displayed in the material creation screen
        - stats is very similar in that 1stD is tier and 2ndD is value of that stat. Each stat has it's own index 
          in 2ndD


        IDEA 2:
        Very similar to idea 1

            public SpellInfo (Spell spellInQuestion,
                                 bool unlocked,
                                 materialsRequired[tier][matIndex, amount],
                                 stats[tier][statIndex, value],
                                 allowedModifiers[tier][modIndex])

        Notes:
        - a lot cleaner than idea 1 in the sense that materialsRequired, stats, and allowedModifiers dont all 
          have to be the same length as however many mats/stasts/modifiers there are
            - seems like it would also be decently less resource intensive even though the arrays all have an 
              extra dimension
                - Fact checked this and it's true a [a,b] array takes up a*b*8 bytes

        Gen Notes:
        - spellList may end up taking up a decent bit of memory (~.5MB * spellList.Count) as it will be a list 
          whose length is the amount of spells and each of their respective SpellInfo's will have several 
          multidimensional/jagged arrays in them

        */
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
