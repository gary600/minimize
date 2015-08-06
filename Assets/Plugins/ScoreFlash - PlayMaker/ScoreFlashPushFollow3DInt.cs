/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  All rights reserved                             *
 ****************************************************/

using HutongGames.PlayMaker;

namespace NarayanaGames.ScoreFlashComponent.PlayMakerActions
{
    [ActionCategory("Score Flash")]
    [Tooltip("Shows a number (int) on screen based on ScoreFlashFollow3D, with an optional color, optionally using a specific ScoreFlash instance (if you have more than one).")]
    public class ScoreFlashPushFollow3DInt : FsmStateAction { // can't inherit from ScoreFlashPush because we don't need "text" here :-/
        [RequiredField]
        [UIHint(UIHint.FsmInt)]
        [Tooltip("A number you want to show.")]
        public FsmInt number;

        [UIHint(UIHint.FsmColor)]
        [Tooltip("An optional color; if you don't set this, colors are managed by ScoreFlash (which should be the default).")]
        public FsmColor color;

        [Tooltip("If you want to drag and drop a specific ScoreFlash instance into the action - use this!")]
        public ScoreFlash scoreFlashInstance;

        [UIHint(UIHint.FsmGameObject)]
        [Tooltip("The game object to follow.")]
        [CheckForComponent(typeof(ScoreFlashFollow3D))]
        public FsmOwnerDefault follow3D;

        public override void Reset() {
            number = 1;
            color = null;
            scoreFlashInstance = null;
        }

        public override void OnEnter() {
            DoSendMessage();

            Finish();
        }

        void DoSendMessage() {
            ScoreFlashFollow3D myFollow3D = Fsm.GetOwnerDefaultTarget(follow3D).GetComponent<ScoreFlashFollow3D>();
            if (color.IsNone) {
                MyScoreFlash.PushWorld(myFollow3D, number.Value);
            } else {
                MyScoreFlash.PushWorld(myFollow3D, number.Value, color.Value);
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