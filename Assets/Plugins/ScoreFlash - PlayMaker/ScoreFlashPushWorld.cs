/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  All rights reserved                             *
 ****************************************************/

using HutongGames.PlayMaker;

namespace NarayanaGames.ScoreFlashComponent.PlayMakerActions
{
    [ActionCategory("Score Flash")]
    [Tooltip("Shows a message on screen using world coordinates, with an optional color, optionally using a specific ScoreFlash instance (if you have more than one).")]
    public class ScoreFlashPushWorld : ScoreFlashPush {
        [UIHint(UIHint.FsmVector3)]
        [Tooltip("Position in world space.")]
        public FsmVector3 worldPosition;

        [UIHint(UIHint.FsmVector2)]
        [Tooltip("Offset in screen space.")]
        public FsmVector2 screenOffset;

        public override void Reset() {
            text = "Hello World!";
            color = null;
            scoreFlashInstance = null;
            worldPosition = null;
            screenOffset = null;
        }

        public override void OnEnter() {
            DoSendMessage();

            Finish();
        }

        void DoSendMessage() {
            if (color.IsNone) {
                MyScoreFlash.PushWorld(worldPosition.Value, screenOffset.Value, text.Value);
            } else {
                MyScoreFlash.PushWorld(worldPosition.Value, screenOffset.Value, text.Value, color.Value);
            }
        }
    }
}