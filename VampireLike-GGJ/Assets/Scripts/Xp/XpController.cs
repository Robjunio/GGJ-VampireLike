using System;
using System.Collections.Generic;
using UnityEngine;

// O GameController deve ter uma instancia dessa classe para que ela possa ser chamada por outros scripts
public class XpController
{
    private float _totalXp;
    private int _currentLevel;
    private float xpNeededToLevelUp;

    public void Start()
    {
        // Reseting all value
        _totalXp = 0;
        _currentLevel = 1;
        
        NewLevelXpNeeded();
        
        GameController.Instance.Interface.UpdateXpText();
    }

    public void AddXp(int value)
    {
        _totalXp += value;
        
        if (_totalXp >= xpNeededToLevelUp)
        {
            _currentLevel++;
            
            // Call level Up function
            GameController.Instance.Interface.ActivateLevelUpPanel();
            
            // Reset total Xp
            var _extraXp = _totalXp - xpNeededToLevelUp;
            _totalXp = _extraXp > 0 ? _extraXp : 0;
            
            // Calculates the new xp pool needed
            NewLevelXpNeeded();
        }
        
        GameController.Instance.Interface.UpdateXpText();
    }

    private void NewLevelXpNeeded()
    {
        // Was utilized the level exp function of this site https://oldschool.runescape.wiki/w/Experience
        float newXpPool = 0;
        for (int i = 1; i <= _currentLevel; i++)
        {
            newXpPool += (float) Math.Floor(_currentLevel + 300 * Math.Pow(2, _currentLevel / 7));
        }

        newXpPool = (float) (newXpPool * 0.25);

        xpNeededToLevelUp = newXpPool;
    }

    public List<float> GetXpInfo()
    {
        var list = new List<float>
        {
            _currentLevel,
            _totalXp,
            xpNeededToLevelUp
        };

        return list;
    }
}
