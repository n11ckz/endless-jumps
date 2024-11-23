using System;
using Zenject;

namespace Project
{
    public class ScoreCounter : IInitializable, IDisposable
    {
        private readonly Score _score;
        private readonly ICharacterMovement _characterMovement;

        public ScoreCounter(Score score, ICharacterMovement characterMovement)
        {
            _score = score;
            _characterMovement = characterMovement;
        }

        public void Initialize() => _characterMovement.Jumped += Increase;

        public void Dispose() => _characterMovement.Jumped -= Increase;

        private void Increase() => _score.Increase();
    }
}
