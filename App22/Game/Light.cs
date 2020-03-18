namespace App22
{
    public class Light
    {
        private bool isLightOn = false;
        public Light(bool state)
        {
            isLightOn = state;
        }

        public void changeState()
        {
            if (isLightOn)
            {
                isLightOn = false;
                return;
            }

            isLightOn = true;
        }
        
        public bool getState()
        {
            return isLightOn;
        }

        public void setState(bool state)
        {
            if (state && !isLightOn)
            {
                changeState();
            }
            else if (!state && isLightOn)
            {
                changeState();
            }
        }
    }
}