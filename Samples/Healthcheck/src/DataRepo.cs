using System;

namespace FP.DotnetInTheBox.Healthcheck
{
    public class DataRepo
    {
        public DataRepo()
        {
            LastChangeUtc = DateTime.UtcNow;
            IsHealthy = true;
        }

        private bool _isHealthy;

        public bool IsHealthy
        {
            get => _isHealthy;
            set
            {
                _isHealthy = value;
                LastChangeUtc = DateTime.UtcNow;
            }
        }

        public DateTime LastChangeUtc { get; private set; }
    }
}
