using System.Collections;
using NUnit.Framework;
using RegressionGames;
using RegressionGames.Types;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NavigateUITest
{

    [UnityTest]
    public IEnumerator TestLongHoldsInUI()
    {

        // ENABLE THIS ON MAC - Unity has a bug where errors are printed when taking screenshots
        // for recordings on Mac. This will suppress those errors so the test can pass properly.
        LogAssert.ignoreFailingMessages = true;

        // Define which bot sequence to use
        string sequencePath = "BotSequences/NavigateUI.json";

        // Wait for the scene
        SceneManager.LoadSceneAsync("Startup", LoadSceneMode.Single);
        yield return RGTestUtils.WaitForScene("MainMenu");

        // Start the sequence
        PlaybackResult sequenceResult = null;
        yield return RGTestUtils.StartBotSequence(sequencePath, result => sequenceResult = result);

        // Print out the recording path for viewing later
        RGDebug.LogInfo("Played back and recorded the bot sequence - saved to " + sequenceResult.saveLocation);
        Assert.IsNotNull(sequenceResult.saveLocation);

    }
}
