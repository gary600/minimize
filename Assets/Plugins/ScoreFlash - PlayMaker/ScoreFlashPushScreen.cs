/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  All rights reserved                             *
 ****************************************************/

using HutongGames.PlayMaker;

namespace NarayanaGames.ScoreFlashComponent.PlayMakerActions
{
    [ActionCategory("Score Flash")]
    [Tooltip("Shows a message on screen using screen coordinates, with an optional color, optionally using a specific ScoreFlash instance (if you have more than one).")]
    public class ScoreFlashPushScreen : ScoreFlashPush {
        [UIHint(UIHint.FsmVector2)]
        [Tooltip("Location on the screen where the message shall be shown.")]
        public FsmVector3 screenPosition;

        public override void Reset() {
            text = "Hello World!";
            color = null;
            scoreFlashInstance = null;
            if (screenPosition != null) {
                screenPosition.Value = new UnityEngine.Vector2(UnityEngine.Screen.width * 0.5F, UnityEngine.Screen.height * 0.5F);
            }
        }

        public override void OnEnter() {
            DoSendMessage();

            Finish();
        }

        void DoSendMessage() {
            if (color.IsNone) {
                MyScoreFlash.PushScreen(screenPosition.Value, text.Value);
            } else {
                MyScoreFlash.PushScreen(screenPosition.Value, text.Value, color.Value);
            }
        }
    }
}