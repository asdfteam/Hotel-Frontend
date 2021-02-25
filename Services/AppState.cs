using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Frontend.Services
{
    public class AppState
    {
        public bool Toggled { get; private set; }

        public event Action OnChange;

        public void Toggle()
        {
            Toggled = !Toggled;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
