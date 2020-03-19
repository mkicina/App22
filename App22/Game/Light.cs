namespace App22.Game
{
    public class Light
    {
        private bool _isLightOn = false;
        public Light(bool state)
        {
            _isLightOn = state;
        }

        public void ChangeState()
        {
            if (_isLightOn)
            {
                _isLightOn = false;
                return;
            }

            _isLightOn = true;
        }
        
        public bool GetState()
        {
            return _isLightOn;
        }

        public void SetState(bool state)
        {
            if (state && !_isLightOn)
            {
                ChangeState();
            }
            else if (!state && _isLightOn)
            {
                ChangeState();
            }
        }
    }
}