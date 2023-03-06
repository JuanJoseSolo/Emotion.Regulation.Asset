using EmotionRegulation;
using BigFiveModel;
using System.Diagnostics;

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
            string TestingSituationSelection(BigFiveModelAsset personality) { return personality.SituationSelection(); }
            // Act
            string openness = TestingSituationSelection(bfm_openness);
            string conscientiousness = TestingSituationSelection(bfm_conscientiousness);
            string extraversion = TestingSituationSelection(bfm_extraversion);
            string agreeableness = TestingSituationSelection(bfm_agreeableness);
            string neuroticism = TestingSituationSelection(bfm_neuroticism);
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
            string TestingSituationModification(BigFiveModelAsset personality){ return personality.SituationModification(); }
            // Act
            string openness = TestingSituationModification(bfm_openness);
            string conscientiousness = TestingSituationModification(bfm_conscientiousness);
            string extraversion = TestingSituationModification(bfm_extraversion);
            string agreeableness = TestingSituationModification(bfm_agreeableness);
            string neuroticism = TestingSituationModification(bfm_neuroticism);
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
            string TestingAttentionalDeployment(BigFiveModelAsset personality) { return personality.AttentionalDeployment(); }
            // Act
            string openness = TestingAttentionalDeployment(bfm_openness);
            string conscientiousness = TestingAttentionalDeployment(bfm_conscientiousness);
            string extraversion = TestingAttentionalDeployment(bfm_extraversion);
            string agreeableness = TestingAttentionalDeployment(bfm_agreeableness);
            string neuroticism = TestingAttentionalDeployment(bfm_neuroticism);
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
            string TestingCognitiveChange(BigFiveModelAsset personality) { return personality.CongnitiveChange(); }
            // Act
            string openness = TestingCognitiveChange(bfm_openness);
            string conscientiousness = TestingCognitiveChange(bfm_conscientiousness);
            string extraversion = TestingCognitiveChange(bfm_extraversion);
            string agreeableness = TestingCognitiveChange(bfm_agreeableness);
            string neuroticism = TestingCognitiveChange(bfm_neuroticism);
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
            string TestingCognitiveChange(BigFiveModelAsset personality) { return personality.ResponseModulation(); }
            // Act
            string openness = TestingCognitiveChange(bfm_openness);
            string conscientiousness = TestingCognitiveChange(bfm_conscientiousness);
            string extraversion = TestingCognitiveChange(bfm_extraversion);
            string agreeableness = TestingCognitiveChange(bfm_agreeableness);
            string neuroticism = TestingCognitiveChange(bfm_neuroticism);
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
    }
}