using System;

// O GameController deve ter uma instancia dessa classe para que ela possa ser chamada por outros scripts
public class XpController
{
    private float _totalXp;
    private float _currentLevel;
    private float xpNeededToLevelUp;

    private void Start()
    {
        // Reseting all value
        _totalXp = 0;
        _currentLevel = 1;
        
        NewLevelXpNeeded();
    }

    public void AddXp(float value)
    {
        _totalXp += value;
        if (_totalXp >= xpNeededToLevelUp)
        {
            // Call level Up function
            
            
            // Reset total Xp
            _currentLevel++;
            var _extraXp = _totalXp - xpNeededToLevelUp;
            _totalXp = _extraXp > 0 ? _extraXp : 0;
            
            // Calculates the new xp pool needed
            NewLevelXpNeeded();
        }
    }

    private void NewLevelXpNeeded()
    {
        // Was utilized the level exp function of this site https://oldschool.runescape.wiki/w/Experience

        var newXpPool = (float) (0.25 * Math.Floor(_currentLevel + 300 * Math.Pow(2, (_currentLevel) / 7)));

        xpNeededToLevelUp = newXpPool;
    }
}
