using System.Collections;
using NUnit.Framework;
using RegressionGames;
using RegressionGames.Types;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

[Category("E2ETests")]
public class NavigateUITest
{

    [UnityTest]
    public IEnumerator TestLongHoldsInUI()
    {

        // ENABLE THIS ON MAC - Unity has a bug where errors are printed when taking screenshots
        // for recordings on Mac. This will suppress those errors so the test can pass properly.
        LogAssert.ignoreFailingMessages = true;
        
        // Screen.SetResolution(640, 480, true);
        // yield return null;

        // Define which bot sequence to use
        string sequencePath = "BotSequences/NavigateUI.json";

        // Wait for the scene
        SceneManager.LoadSceneAsync("Startup", LoadSceneMode.Single);
        yield return RGTestUtils.WaitForScene("MainMenu");

        // Start the sequence
        PlaybackResult sequenceResult = null;
        yield return RGTestUtils.StartBotSequence(sequencePath, result => sequenceResult = result);

        // Print out the recording path for viewing later
        Assert.IsNotNull(sequenceResult);
        Assert.IsNotNull(sequenceResult.saveLocation);
        RGDebug.LogInfo("Played back and recorded the bot sequence - saved to " + sequenceResult.saveLocation);

    }
}
