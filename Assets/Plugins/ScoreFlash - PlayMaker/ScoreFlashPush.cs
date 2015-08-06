/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  All rights reserved                             *
 ****************************************************/

using HutongGames.PlayMaker;

namespace NarayanaGames.ScoreFlashComponent.PlayMakerActions
{
    [ActionCategory("Score Flash")]
    [HutongGames.PlayMaker.Tooltip("Shows a message on screen using ScoreFlash, with an optional color, optionally using a specific ScoreFlash instance (if you have more than one).")]
    public class ScoreFlashPush : FsmStateAction {
        [RequiredField]
        [UIHint(UIHint.TextArea)]
        [Tooltip("The message you want to show with this action.")]
        public FsmString text;

        [UIHint(UIHint.FsmColor)]
        [Tooltip("An optional color; if you don't set this, colors are managed by ScoreFlash (which should be the default).")]
        public FsmColor color;

        [Tooltip("If you want to drag and drop a specific ScoreFlash instance into the action - use this!")]
        public ScoreFlash scoreFlashInstance;

        public override void Reset() {
            text = "Hello World!";
            color = null;
            scoreFlashInstance = null;
        }

        public override void OnEnter() {
            DoSendMessage();

            Finish();
        }

        void DoSendMessage() {
            if (color.IsNone) {
                MyScoreFlash.PushLocal(text.Value);
            } else {
                MyScoreFlash.PushLocal(text.Value, color.Value);
            }
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