using Tatelier.Score.Component.NoteSystem;

namespace Tatelier.Play
{
    interface INoteText
    {
        void Draw(float xf, float yf, NoteTextType noteTextType);
    }
}