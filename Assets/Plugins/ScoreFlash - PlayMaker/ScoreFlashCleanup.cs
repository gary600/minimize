/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  All rights reserved                             *
 ****************************************************/

using HutongGames.PlayMaker;

namespace NarayanaGames.ScoreFlashComponent.PlayMakerActions
{
    [ActionCategory("Score Flash")]
    [HutongGames.PlayMaker.Tooltip("Cleans up all ScoreFlash messages currently on screen.")]
    public class ScoreFlashCleanup : FsmStateAction {
        [Tooltip("If you want to clean up messages of a specific instance - otherwise, ScoreFlash.Instance will be used!")]
        public ScoreFlash scoreFlashInstance;

        public override void Reset() {
            scoreFlashInstance = null;
        }

        public override void OnEnter() {
            MyScoreFlash.Cleanup();

            Finish();
        }

        protected IScoreFlash MyScoreFlash {
            get {
                IScoreFlash scoreFlash = null;
                if (scoreFlashInstance == null) {
                    scoreFlash = ScoreFlash.Instance;
                } else {
                    scoreFlash = (IScoreFlash)scoreFlashInstance;
                }
                return scoreFlash;
            }
        }
    }
}