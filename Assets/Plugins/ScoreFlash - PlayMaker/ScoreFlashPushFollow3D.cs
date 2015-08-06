/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  All rights reserved                             *
 ****************************************************/

using HutongGames.PlayMaker;

namespace NarayanaGames.ScoreFlashComponent.PlayMakerActions
{
    [ActionCategory("Score Flash")]
    [Tooltip("Shows a message on screen based on ScoreFlashFollow3D, with an optional color, optionally using a specific ScoreFlash instance (if you have more than one).")]
    public class ScoreFlashPushFollow3D : ScoreFlashPush {
        [UIHint(UIHint.FsmGameObject)]
        [Tooltip("The game object to follow.")]
        [CheckForComponent(typeof(ScoreFlashFollow3D))]
        public FsmOwnerDefault follow3D;

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
            ScoreFlashFollow3D myFollow3D = Fsm.GetOwnerDefaultTarget(follow3D).GetComponent<ScoreFlashFollow3D>();
            if (color.IsNone) {
                myFollow3D.Push(text.Value);
            } else {
                myFollow3D.Push(text.Value, color.Value);
            }
        }
    }
}