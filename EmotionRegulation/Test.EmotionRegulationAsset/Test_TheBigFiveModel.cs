using BigFiveModel;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.EmotionRegulationAsset
{
    [TestClass]
    public class Test_TheBigFiveModel
    {
        [TestMethod]
        public void Test_SituationSelection()
        {
            // Arrange
            BigFiveModelAsset bfm_openness = new BigFiveModelAsset(openness: 99, conscientiousness: 10, extraversion: 20, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_conscientiousness = new BigFiveModelAsset(openness: 10, conscientiousness: 99, extraversion: 20, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_extraversion = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 99, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_agreeableness = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 99, neuroticism: 20);
            BigFiveModelAsset bfm_neuroticism = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 20, neuroticism: 99);
            List<string> TestingSituationSelection(BigFiveModelAsset personality) { return personality.StrategiesForce(); }
            // Act
            var openness = TestingSituationSelection(bfm_openness);
            var conscientiousness = TestingSituationSelection(bfm_conscientiousness);
            var extraversion = TestingSituationSelection(bfm_extraversion);
            var agreeableness = TestingSituationSelection(bfm_agreeableness);
            var neuroticism = TestingSituationSelection(bfm_neuroticism);
            // Print outputs
            Debug.Print($"{bfm_openness.Dominant} -> {openness}");
            Debug.Print($"{bfm_conscientiousness.Dominant} -> {conscientiousness}");
            Debug.Print($"{bfm_extraversion.Dominant} -> {extraversion}");
            Debug.Print($"{bfm_agreeableness.Dominant} -> {agreeableness}");
            Debug.Print($"{bfm_neuroticism.Dominant} -> {neuroticism}");
            // Assert
            Assert.IsTrue(openness.Contains("Weak"));
            Assert.IsTrue(conscientiousness.Contains("Strong"));
            Assert.IsTrue(extraversion.Contains("Weak"));
            Assert.IsTrue(agreeableness.Contains("Weak"));
            Assert.IsTrue(neuroticism.Contains("Strong"));
        }
        [TestMethod]
        public void Test_SituationModification()
        {
            // Arrange
            BigFiveModelAsset bfm_openness = new BigFiveModelAsset(openness: 99, conscientiousness: 10, extraversion: 20, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_conscientiousness = new BigFiveModelAsset(openness: 10, conscientiousness: 99, extraversion: 20, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_extraversion = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 99, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_agreeableness = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 99, neuroticism: 20);
            BigFiveModelAsset bfm_neuroticism = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 20, neuroticism: 99);
            List<string> TestingSituationModification(BigFiveModelAsset personality){ return personality.StrategiesForce(); }
            // Act
            var openness = TestingSituationModification(bfm_openness);
            var conscientiousness = TestingSituationModification(bfm_conscientiousness);
            var extraversion = TestingSituationModification(bfm_extraversion);
            var agreeableness = TestingSituationModification(bfm_agreeableness);
            var neuroticism = TestingSituationModification(bfm_neuroticism);
            // Print outputs
            Debug.Print($"{bfm_openness.Dominant} -> {openness}");
            Debug.Print($"{bfm_conscientiousness.Dominant} -> {conscientiousness}");
            Debug.Print($"{bfm_extraversion.Dominant} -> {extraversion}");
            Debug.Print($"{bfm_agreeableness.Dominant} -> {agreeableness}");
            Debug.Print($"{bfm_neuroticism.Dominant} -> {neuroticism}");
            // Assert
            Assert.IsTrue(openness.Contains("Strong"));
            Assert.IsTrue(conscientiousness.Contains("Strong"));
            Assert.IsTrue(extraversion.Contains("Strong"));
            Assert.IsTrue(agreeableness.Contains("Weak") || agreeableness.Contains("Slight"));
            Assert.IsTrue(neuroticism.Contains("Weak")  || neuroticism.Contains("Slight"));
        }
        [TestMethod]
        public void Test_AttentionalDeployment()
        {
            // Arrange
            BigFiveModelAsset bfm_openness = new BigFiveModelAsset(openness: 99, conscientiousness: 10, extraversion: 20, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_conscientiousness = new BigFiveModelAsset(openness: 10, conscientiousness: 99, extraversion: 20, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_extraversion = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 99, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_agreeableness = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 99, neuroticism: 20);
            BigFiveModelAsset bfm_neuroticism = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 20, neuroticism: 99);
            List<string> TestingAttentionalDeployment(BigFiveModelAsset personality) { return personality.StrategiesForce(); }
            // Act
            var openness = TestingAttentionalDeployment(bfm_openness);
            var conscientiousness = TestingAttentionalDeployment(bfm_conscientiousness);
            var extraversion = TestingAttentionalDeployment(bfm_extraversion);
            var agreeableness = TestingAttentionalDeployment(bfm_agreeableness);
            var neuroticism = TestingAttentionalDeployment(bfm_neuroticism);
            // Print outputs
            Debug.Print($"{bfm_openness.Dominant} -> {openness}");
            Debug.Print($"{bfm_conscientiousness.Dominant} -> {conscientiousness}");
            Debug.Print($"{bfm_extraversion.Dominant} -> {extraversion}");
            Debug.Print($"{bfm_agreeableness.Dominant} -> {agreeableness}");
            Debug.Print($"{bfm_neuroticism.Dominant} -> {neuroticism}");
            // Assert
            Assert.IsTrue(openness.Contains("Strong"));
            Assert.IsTrue(extraversion.Contains("Strong"));
            Assert.IsTrue(agreeableness.Contains("Strong"));
            Assert.IsTrue(conscientiousness.Contains("Strong"));
            Assert.IsTrue(neuroticism.Contains("Weak") || neuroticism.Contains("Slight"));
        }
        [TestMethod]
        public void Test_CognitiveChange()
        {
            // Arrange
            BigFiveModelAsset bfm_openness = new BigFiveModelAsset(openness: 99, conscientiousness: 10, extraversion: 20, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_conscientiousness = new BigFiveModelAsset(openness: 10, conscientiousness: 99, extraversion: 20, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_extraversion = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 99, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_agreeableness = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 99, neuroticism: 20);
            BigFiveModelAsset bfm_neuroticism = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 20, neuroticism: 99);
            List<string> TestingCognitiveChange(BigFiveModelAsset personality) { return personality.StrategiesForce(); }
            // Act
            var openness = TestingCognitiveChange(bfm_openness);
            var conscientiousness = TestingCognitiveChange(bfm_conscientiousness);
            var extraversion = TestingCognitiveChange(bfm_extraversion);
            var agreeableness = TestingCognitiveChange(bfm_agreeableness);
            var neuroticism = TestingCognitiveChange(bfm_neuroticism);
            // Print outputs
            Debug.Print($"{bfm_openness.Dominant} -> {openness}");
            Debug.Print($"{bfm_conscientiousness.Dominant} -> {conscientiousness}");
            Debug.Print($"{bfm_extraversion.Dominant} -> {extraversion}");
            Debug.Print($"{bfm_agreeableness.Dominant} -> {agreeableness}");
            Debug.Print($"{bfm_neuroticism.Dominant} -> {neuroticism}");
            // Assert
            Assert.IsTrue(openness.Contains("Strong"));
            Assert.IsTrue(extraversion.Contains("Strong"));
            Assert.IsTrue(agreeableness.Contains("Strong"));
            Assert.IsTrue(conscientiousness.Contains("Strong"));
            Assert.IsTrue(neuroticism.Contains("Weak") || neuroticism.Contains("Slight"));
        }
        [TestMethod]
        public void Test_ResponseModulation()
        {
            // Arrange
            BigFiveModelAsset bfm_openness = new BigFiveModelAsset(openness: 1, conscientiousness: 10, extraversion: 20, agreeableness: 10, neuroticism: 20);
            BigFiveModelAsset bfm_conscientiousness = new BigFiveModelAsset(openness: 10, conscientiousness: 1, extraversion: 20, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_extraversion = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 1, agreeableness: 30, neuroticism: 20);
            BigFiveModelAsset bfm_agreeableness = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 9, neuroticism: 20);
            BigFiveModelAsset bfm_neuroticism = new BigFiveModelAsset(openness: 10, conscientiousness: 20, extraversion: 30, agreeableness: 20, neuroticism: 1 );
            List<string> TestingCognitiveChange(BigFiveModelAsset personality) { return personality.StrategiesForce(); }
            // Act
            var openness = TestingCognitiveChange(bfm_openness);
            var conscientiousness = TestingCognitiveChange(bfm_conscientiousness);
            var extraversion = TestingCognitiveChange(bfm_extraversion);
            var agreeableness = TestingCognitiveChange(bfm_agreeableness);
            var neuroticism = TestingCognitiveChange(bfm_neuroticism);
            // Print outputs
            Debug.Print($"{bfm_openness.Dominant} -> {openness}");
            Debug.Print($"{bfm_conscientiousness.Dominant} -> {conscientiousness}");
            Debug.Print($"{bfm_extraversion.Dominant} -> {extraversion}");
            Debug.Print($"{bfm_agreeableness.Dominant} -> {agreeableness}");
            Debug.Print($"{bfm_neuroticism.Dominant} -> {neuroticism}");
            // Assert
            Assert.IsTrue(openness.Contains("Strong"));
            Assert.IsTrue(extraversion.Contains("Strong"));
            Assert.IsTrue(agreeableness.Contains("Strong"));
            Assert.IsTrue(conscientiousness.Contains("Strong"));
            Assert.IsTrue(neuroticism.Contains("Strong"));
        }
        [TestMethod]
        public void Test_Plots()
        {
            BigFiveModelAsset personality = new BigFiveModelAsset(openness: 1, conscientiousness: 10, extraversion: 20, agreeableness: 10, neuroticism: 20);
            personality.Plot();
        }
    }
}