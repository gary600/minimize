/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  All rights reserved                             *
 ****************************************************/

using HutongGames.PlayMaker;

namespace NarayanaGames.ScoreFlashComponent.PlayMakerActions
{
    [ActionCategory("Score Flash")]
    [Tooltip("Shows a message on screen based on ScoreFlashLayout, with an optional color.")]
    public class ScoreFlashPushLayout : FsmStateAction {
        [RequiredField]
        [UIHint(UIHint.TextArea)]
        [Tooltip("The message you want to show with this action.")]
        public FsmString text;

        [UIHint(UIHint.FsmColor)]
        [Tooltip("An optional color; if you don't set this, colors are managed by ScoreFlash (which should be the default).")]
        public FsmColor color;

        [RequiredField]
        [Tooltip("The layout instance to use.")]
        public ScoreFlashLayout layout;

        public override void Reset() {
            text = "Hello World!";
            color = null;
            layout = null;
        }

        public override void OnEnter() {
            DoSendMessage();

            Finish();
        }

        void DoSendMessage() {
            if (color.IsNone) {
                layout.Push(text.Value);
            } else {
                layout.Push(text.Value, color.Value);
            }
        }
    }
}