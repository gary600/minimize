/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  All rights reserved                             *
 ****************************************************/

using HutongGames.PlayMaker;

using NarayanaGames.ScoreFlashComponent;

namespace NarayanaGames.ScoreFlashComponent.PlayMakerActions
{
    [ActionCategory("Score Flash")]
    [Tooltip("Shows a message on screen using ScoreFlash.")]
    public class ScoreFlashPushCustomRenderer : FsmStateAction {
        [RequiredField]
        [Tooltip("A prefab that has your custom implementation of ScoreFlashRendererBase attached, e.g. for achievements.")]
        public ScoreFlashRendererBase renderer;

        [Tooltip("If you want to drag and drop a specific ScoreFlash instance into the action - use this!")]
        public ScoreFlash scoreFlashInstance;

        public override void Reset() {
            renderer = null;
            scoreFlashInstance = null;
        }

        public override void OnEnter() {
            DoSendMessage();

            Finish();
        }

        void DoSendMessage() {
            ScoreFlashRendererBase customRendererInstance = (ScoreFlashRendererBase)UnityEngine.Object.Instantiate(renderer);
            MyScoreFlash.PushLocal(customRendererInstance);
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